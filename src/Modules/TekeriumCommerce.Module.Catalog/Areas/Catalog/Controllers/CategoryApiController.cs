using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using TekeriumCommerce.Infrastructure;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Infrastructure.Localization;
using TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Catalog.Services;
using TekeriumCommerce.Module.Core.Extensions;
using TekeriumCommerce.Module.Core.Models;
using TekeriumCommerce.Module.Core.Services;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    [Authorize(Roles = "admin")]
    [Route("api/categories")]
    public class CategoryApiController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMediaService _mediaService;
        private readonly IRepository<ProductSeason> _productSeasonRepository;
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<Culture, string> _cultureRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<LocalizedProperty> _localizedPropertyRepository;

        public CategoryApiController(IRepository<Category> categoryRepository,
                                    ICategoryService categoryService,
                                    IMediaService mediaService,
                                    IRepository<ProductSeason> productSeasonRepository,
                                    IWorkContext workContext,
                                    IRepositoryWithTypedId<Culture, string> cultureRepository,
                                    ILocalizationService localizationService,
                                    IRepository<LocalizedProperty> localizedPropertyRepository)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
            _mediaService = mediaService;
            _productSeasonRepository = productSeasonRepository;
            _workContext = workContext;
            _cultureRepository = cultureRepository;
            _localizationService = localizationService;
            _localizedPropertyRepository = localizedPropertyRepository;
        }

        public async Task<IActionResult> Get()
        {
            var gridData = await _categoryService.GetAll();
            return Json(gridData);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var category = await _categoryRepository.Query().Include(x => x.ThumbnailImage)
                .Include(x => x.Locales)
                .FirstOrDefaultAsync(x => x.Id == id);

            category.Name = category.GetLocalized<Category>("Name", _workContext);

            var model = new CategoryForm
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                MetaTitle = category.MetaTitle,
                MetaKeywords = category.MetaKeywords,
                MetaDescription = category.MetaDescription,
                DisplayOrder = category.DisplayOrder,
                Description = category.Description,
                IncludeInMenu = category.IncludeInMenu,
                IsPublished = category.IsPublished,
                ThumbnailImageUrl = _mediaService.GetThumbnailUrl(category.ThumbnailImage),
            };

            model.Locales = PrepareCategoryLocalization(category, model);

            return Json(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post(CategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.Name,
                    Slug = model.Slug,
                    MetaTitle = model.MetaTitle,
                    MetaKeywords = model.MetaKeywords,
                    MetaDescription = model.MetaDescription,
                    DisplayOrder = model.DisplayOrder,
                    Description = model.Description,
                    IncludeInMenu = model.IncludeInMenu,
                    IsPublished = model.IsPublished
                };

                // locales store
                var nameLocalizedProperties = model.Locales.Select(x => new LocalizedProperty
                    {LanguageId = x.CultureId, LocaleKey = "Name", LocaleValue = x.Name}).ToList();

                var descriptionLocalizedProperties = model.Locales.Select(x => new LocalizedProperty
                    {LanguageId = x.CultureId, LocaleKey = "Description", LocaleValue = x.Description}).ToList();

                await SaveCategoryImage(category, model);
                await _categoryService.Create(category);

                foreach (var nameLocalizedProperty in nameLocalizedProperties)
                {
                    category.AddLocale(nameLocalizedProperty);
                }

                foreach (var descriptionLocalizedProperty in descriptionLocalizedProperties)
                {
                    category.AddLocale(descriptionLocalizedProperty);
                }

                await _categoryRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = category.Id }, null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, CategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryRepository.Query().Include(x => x.Locales).FirstOrDefaultAsync(x => x.Id == id);
                if (category is null)
                    return NotFound();

                category.Name = model.Name;
                category.Slug = model.Slug;
                category.MetaTitle = model.MetaTitle;
                category.MetaKeywords = model.MetaKeywords;
                category.MetaDescription = model.MetaDescription;
                category.Description = model.Description;
                category.DisplayOrder = model.DisplayOrder;
                category.IncludeInMenu = model.IncludeInMenu;
                category.IsPublished = model.IsPublished;

                // update locales
                foreach (var localized in model.Locales)
                {
                    SaveLocalizedValue(category, x => x.Name, localized.Name, localized.CultureId);
                    SaveLocalizedValue(category, x => x.Description, localized.Description, localized.CultureId);
                }

                await SaveCategoryImage(category, model);
                await _categoryService.Update(category);

                return Accepted();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var category = _categoryRepository.Query().FirstOrDefault(x => x.Id == id);
            if (category is null)
            {
                return NotFound();
            }

            // todo: delete localized properties of this category

            await _categoryService.Delete(category);
            return NoContent();
        }

        // GET /api/categories/seasons
        [HttpGet("seasons")]
        public async Task<IActionResult> Seasons()
        {
            var data = await this._productSeasonRepository.Query().ToListAsync();

            return Json(data);
        }

        [HttpGet("getCultures")]
        public async Task<IActionResult> GetCultures()
        {
            return Json(await _cultureRepository.Query().Where(x => x.Id != GlobalConfiguration.DefaultCulture).ToListAsync());
        }

        private async Task SaveCategoryImage(Category category, CategoryForm model)
        {
            if (model.ThumbnailImage != null)
            {
                var fileName = await SaveFile(model.ThumbnailImage);
                if (category.ThumbnailImage != null)
                {
                    category.ThumbnailImage.FileName = fileName;
                }
                else
                {
                    category.ThumbnailImage = new Media { FileName = fileName };
                }
            }
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName =
                ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _mediaService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }

        // localization shits:
        private IList<CategoryLocalizedForm> PrepareCategoryLocalization(Category category, CategoryForm categoryFrom)
        {
            Action<CategoryLocalizedForm, string> localizedFormConfiguration = null;

            if (category != null)
            {
                localizedFormConfiguration = (locale, cultureId) =>
                {
                    locale.Name = _localizationService.GetLocalized(category, entity => entity.Name, cultureId);
                    locale.Description = _localizationService.GetLocalized(category, entity => entity.Description, cultureId);
                };
            }

            // get all available languages
            var availableLanguages = _cultureRepository.Query().Where(x => x.Id != GlobalConfiguration.DefaultCulture).ToList(); // todo: remove default language from here

            var localizedModels = availableLanguages.Select(culture =>
            {
                var localizedForm = new CategoryLocalizedForm { CultureId = culture.Id };

                localizedFormConfiguration?.Invoke(localizedForm, localizedForm.CultureId);

                return localizedForm;
            }).ToList();

            return localizedModels;
        }

        private void SaveLocalizedValue<TPropType>(Category entity, Expression<Func<Category, TPropType>> keySelector,
            TPropType localeValue, string languageId)
        {
            // get property name
            var propName = ((keySelector.Body as MemberExpression)?.Member as PropertyInfo)?.Name;

            // get all localized properties for this entity
            var localizedProperties = _localizedPropertyRepository.Query().Where(x => x.EntityId == entity.Id);

            // find 
            var prop = localizedProperties.FirstOrDefault(lp => lp.LanguageId == languageId && lp.LocaleKey.Equals(propName, StringComparison.InvariantCultureIgnoreCase));

            // value
            var stringLocale = localeValue as string;

            if (prop != null)
            {
                if (string.IsNullOrWhiteSpace(stringLocale))
                {
                    // delete this prop
                    _localizedPropertyRepository.Remove(prop);
                }
                else
                {
                    // update
                    prop.LocaleValue = stringLocale;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(stringLocale))
                    return;

                // create new
                prop = new LocalizedProperty
                {
                    EntityId = entity.Id,
                    LanguageId = languageId,
                    LocaleKey = propName,
                    LocaleValue = stringLocale
                };

                entity.AddLocale(prop);

                _localizedPropertyRepository.Add(prop);
            }
        }
    }
}