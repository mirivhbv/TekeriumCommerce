using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Infrastructure.Web.SmartTable;
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
    [Route("api/products")]
    public class ProductApiController : Controller
    {
        private readonly IMediaService _mediaService;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductMedia> _productMediaRepository;
        private readonly IProductService _productService;
        private readonly IWorkContext _workContext;

        public ProductApiController(IMediaService mediaService, IRepository<Product> productRepository, IRepository<ProductMedia> productMediaRepository, IProductService productService, IWorkContext workContext)
        {
            _mediaService = mediaService;
            _productRepository = productRepository;
            _productMediaRepository = productMediaRepository;
            _productService = productService;
            _workContext = workContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var product = _productRepository.Query()
                .Include(x => x.ThumbnailImage)
                .Include(x => x.Medias).ThenInclude(m => m.Media)
                .FirstOrDefault(x => x.Id == id);

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin"))
            {
                return BadRequest(new { error = "You don't have permission to manage this product" });
            }

            var productVm = new ProductVm
            {
                Id = product.Id,
                Name = product.Name,
                Slug = product.Slug,
                MetaTitle = product.MetaTitle,
                MetaKeywords = product.MetaKeywords,
                MetaDescription = product.MetaDescription,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                Specification = product.Specification,
                OldPrice = product.OldPrice,
                Price = product.Price,
                SpecialPrice = product.SpecialPrice,
                SpecialPriceStart = product.SpecialPriceStart,
                SpecialPriceEnd = product.SpecialPriceEnd,
                IsPublished = product.IsPublished,
                CategoryId = product.CategoryId,
                ThumbnailImageUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage),
                BrandId = product.BrandId,
                ProductSeasonId = product.ProductSeasonId,
                TyreWidthId = product.TyreWidthId,
                TyreProfileId = product.TyreProfileId,
                TyreRimSizeId = product.TyreRimSizeId
            };

            foreach (var productMedia in product.Medias.Where(x => x.Media.MediaType == MediaType.Image))
            {
                productVm.ProductImages.Add(new ProductMediaVm
                {
                    Id = productMedia.Id,
                    MediaUrl = _mediaService.GetThumbnailUrl(productMedia.Media)
                });
            }

            foreach (var productMedia in product.Medias.Where(x => x.Media.MediaType == MediaType.File))
            {
                productVm.ProductDocuments.Add(new ProductMediaVm
                {
                    Id = productMedia.Id,
                    Caption = productMedia.Media.Caption,
                    MediaUrl = _mediaService.GetMediaUrl(productMedia.Media)
                });
            }

            return Json(productVm);
        }

        [HttpPost("grid")]
        public async Task<IActionResult> List([FromBody] SmartTableParam param)
        {
            var query = _productRepository.Query().Where(x => !x.IsDeleted);
            var currentUser = await _workContext.GetCurrentUser();

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;
                if (search.Name != null)
                {
                    string name = search.Name;
                    query = query.Where(x => x.Name.Contains(name));
                }

                if (search.IsPublished != null)
                {
                    bool isPublished = search.IsPublished;
                    query = query.Where(x => x.IsPublished == isPublished);
                }

                if (search.CreatedOn != null)
                {
                    if (search.CreatedOn.before != null)
                    {
                        DateTimeOffset before = search.CreatedOn.before;
                        query = query.Where(x => x.CreatedOn <= before);
                    }

                    if (search.CreatedOn.after != null)
                    {
                        DateTimeOffset after = search.CreatedOn.after;
                        query = query.Where(x => x.CreatedOn >= after);
                    }
                }
            }

            var gridData = query.ToSmartTableResult(param, x => new ProductListItem
            {
                Id = x.Id,
                Name = x.Name,
                StockQuantity = x.StockQuantity,
                CreatedOn = x.CreatedOn,
                IsPublished = x.IsPublished
            });

            return Json(gridData);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductForm model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var currentUser = await _workContext.GetCurrentUser();

            var product = new Product()
            {
                Name = model.Product.Name,
                Slug = model.Product.Slug,
                MetaTitle = model.Product.MetaTitle,
                MetaKeywords = model.Product.MetaKeywords,
                MetaDescription = model.Product.MetaDescription,
                ShortDescription = model.Product.ShortDescription,
                Description = model.Product.Description,
                Specification = model.Product.Specification,
                Price = model.Product.Price,
                OldPrice = model.Product.OldPrice,
                SpecialPrice = model.Product.SpecialPrice,
                SpecialPriceStart = model.Product.SpecialPriceStart,
                SpecialPriceEnd = model.Product.SpecialPriceEnd,
                IsPublished = model.Product.IsPublished,
                CategoryId = model.Product.CategoryId,
                BrandId = model.Product.BrandId,
                TyreWidthId = model.Product.TyreWidthId,
                TyreProfileId = model.Product.TyreProfileId,
                TyreRimSizeId = model.Product.TyreRimSizeId,
                CreatedBy = currentUser,
                ProductSeasonId = model.Product.ProductSeasonId
            };

            await SaveProductMedias(model, product);

            // done! todo: add price history
            var productPriceHistory = CreatePriceHistory(currentUser, product);
            product.PriceHistories.Add(productPriceHistory);

            _productService.Create(product);
            return CreatedAtAction(nameof(Get), new {id = product.Id}, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, ProductForm model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _productRepository.Query()
                .Include(x => x.ThumbnailImage)
                .Include(x => x.Medias)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id);

            if (product is null)
            {
                return NotFound();
            }

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin"))
            {
                return BadRequest(new { error = "You don't have permission to manage this product" });
            }

            var isPriceChanged = product.Price != model.Product.Price ||
                                  product.OldPrice != model.Product.OldPrice ||
                                  product.SpecialPrice != model.Product.SpecialPrice ||
                                  product.SpecialPriceStart != model.Product.SpecialPriceStart ||
                                  product.SpecialPriceEnd != model.Product.SpecialPriceEnd;

            product.Name = model.Product.Name;
            product.Slug = model.Product.Slug;
            product.MetaTitle = model.Product.MetaTitle;
            product.MetaKeywords = model.Product.MetaKeywords;
            product.MetaDescription = model.Product.MetaDescription;
            product.ShortDescription = model.Product.ShortDescription;
            product.Description = model.Product.Description;
            product.Specification = model.Product.Specification;
            product.Price = model.Product.Price;
            product.OldPrice = model.Product.OldPrice;
            product.SpecialPrice = model.Product.SpecialPrice;
            product.SpecialPriceStart = model.Product.SpecialPriceStart;
            product.SpecialPriceEnd = model.Product.SpecialPriceEnd;
            product.BrandId = model.Product.BrandId;
            product.ProductSeasonId = model.Product.ProductSeasonId;
            product.TyreWidthId = model.Product.TyreWidthId;
            product.TyreProfileId = model.Product.TyreProfileId;
            product.TyreRimSizeId = model.Product.TyreRimSizeId;
            product.IsPublished = model.Product.IsPublished;
            product.UpdatedBy = currentUser;

            if (isPriceChanged)
            {
                var productPriceHistory = CreatePriceHistory(currentUser, product);
                product.PriceHistories.Add(productPriceHistory);
            }

            await SaveProductMedias(model, product);

            foreach (var productMediaId in model.Product.DeletedMediaIds)
            {
                var productMedia = product.Medias.First(x => x.Id == productMediaId);
                _productMediaRepository.Remove(productMedia);
                await _mediaService.DeleteMediaAsync(productMedia.Media);
            }

            // todo: update category

            _productService.Update(product);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var product = _productRepository.Query().FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin"))
            {
                return BadRequest(new { error = "You don't have permission to manage this product" });
            }

            await _productService.Delete(product);

            return NoContent();
        }

        [HttpPost("change-status/{id}")]
        public async Task<IActionResult> ChangeStatus(long id)
        {
            var product = _productRepository.Query().FirstOrDefault(x => x.Id == id);
            if (product is null)
                return NotFound();

            var currentUser = await _workContext.GetCurrentUser();
            if (!User.IsInRole("admin"))
            {
                return BadRequest(new { error = "You don't have permission to manage this product" });
            }

            product.IsPublished = !product.IsPublished;
            await _productRepository.SaveChangesAsync();

            return Accepted();
        }

        // helper methods:

        private static ProductPriceHistory CreatePriceHistory(User loginUser, Product product)
        {
            return new ProductPriceHistory
            {
                CreatedBy = loginUser,
                Product = product,
                Price = product.Price,
                OldPrice = product.OldPrice,
                SpecialPrice = product.SpecialPrice,
                SpecialPriceStart = product.SpecialPriceStart,
                SpecialPriceEnd = product.SpecialPriceEnd
            };
        }

        private async Task SaveProductMedias(ProductForm model, Product product)
        {
            if (model.ThumbnailImage != null)
            {
                var fileName = await SaveFile(model.ThumbnailImage);
                if (product.ThumbnailImage != null)
                {
                    product.ThumbnailImage.FileName = fileName;
                }
                else
                {
                    product.ThumbnailImage = new Media { FileName = fileName };
                }
            }

            // Currently model binder cannot map the collection of file productImages[0], productImages[1]
            foreach (var file in Request.Form.Files)
            {
                if (file.ContentDisposition.Contains("productImages"))
                {
                    model.ProductImages.Add(file);
                }
                else if (file.ContentDisposition.Contains("productDocuments"))
                {
                    model.ProductDocuments.Add(file);
                }
            }

            foreach (var file in model.ProductImages)
            {
                var fileName = await SaveFile(file);
                var productMedia = new ProductMedia
                {
                    Product = product,
                    Media = new Media { FileName = fileName, MediaType = MediaType.Image }
                };
                product.AddMedia(productMedia);
            }

            foreach (var file in model.ProductDocuments)
            {
                var fileName = await SaveFile(file);
                var productMedia = new ProductMedia
                {
                    Product = product,
                    Media = new Media { FileName = fileName, MediaType = MediaType.File, Caption = file.FileName }
                };
                product.AddMedia(productMedia);
            }
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _mediaService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }
    }
}