using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Catalog.Services;
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

        public CategoryApiController(IRepository<Category> categoryRepository, ICategoryService categoryService, IMediaService mediaService, IRepository<ProductSeason> productSeasonRepository)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
            _mediaService = mediaService;
            _productSeasonRepository = productSeasonRepository;
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
                .FirstOrDefaultAsync(x => x.Id == id);
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

                await SaveCategoryImage(category, model);
                await _categoryService.Create(category);
                return CreatedAtAction(nameof(Get), new { id = category.Id }, null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, CategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
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

            //if (category.Children.Any(x => !x.IsDeleted))
            //{
            //    return BadRequest(new { Error = "Please make sure this category contains no children" });
            //}

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
                    category.ThumbnailImage = new Media {FileName = fileName};
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
    }
}