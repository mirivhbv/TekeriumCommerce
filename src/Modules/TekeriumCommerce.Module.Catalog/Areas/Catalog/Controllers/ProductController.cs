using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Catalog.Services;
using TekeriumCommerce.Module.Core.Areas.Core.ViewModels;
using TekeriumCommerce.Module.Core.Services;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    public class ProductController : Controller
    {
        private readonly IMediaService _mediaService;
        private readonly IRepository<Product> _productRepository;
        private readonly IMediator _mediator;
        private readonly IProductPricingService _productPricingService;
        
        public ProductController(IMediaService mediaService, 
            IRepository<Product> productRepository, 
            IMediator mediator,
            IProductPricingService productPricingService)
        {
            _mediaService = mediaService;
            _productRepository = productRepository;
            _mediator = mediator;
            _productPricingService = productPricingService;
        }

        // todo:
        //[HttpGet("product/product-overview")]
        //public async Task<IActionResult> ProductOverview(long id)
        //{
        //    var product = await _productRepository.Query()
        //        .Include(x => x.Category)
        //        .Include(x => x.TyreProfile)
        //        .Include(x => x.TyreRimSize)
        //        .Include(x => x.TyreWidth)
        //        .Include(x => x.Medias).ThenInclude(m => m.Media)
        //        .FirstOrDefaultAsync(x => x.Id == id && x.IsPublished);

        //    if (product is null)
        //        return NotFound();

        //    var model = new ProductDetail
        //    {
                
        //    }
        //}

        public async Task<IActionResult> ProductDetail(long id)
        {
            var product = await _productRepository.Query()
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .Include(x => x.TyreProfile)
                .Include(x => x.TyreRimSize)
                .Include(x => x.TyreWidth)
                .Include(x => x.Medias).ThenInclude(m => m.Media)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsPublished);

            if (product is null)
                return NotFound();
            
            var model = new ProductDetail
            {
                Id = product.Id,
                Name = product.Name,
                CalculatedProductPrice = _productPricingService.CalculateProductPrice(product),
                StockQuantity = product.StockQuantity,
                ShortDescription = product.ShortDescription,
                MetaTitle = product.MetaTitle,
                MetaKeywords = product.MetaKeywords,
                MetaDescription = product.MetaDescription,
                Description = product.Description,
                Specification = product.Specification,
                Brand = new ProductDetailBrand
                    { Id = product.Brand.Id, Name = product.Brand.Name, Slug = product.Brand.Slug },
                Category = new ProductDetailCategory
                    { Id = product.Category.Id, Name = product.Category.Name, Slug = product.Category.Slug}
            };

            MapProductImagesToProductVm(product, model);

            // todo: mediator publish entity viewed


            return View(model);
        }

        private void MapProductImagesToProductVm(Product product, ProductDetail model)
        {
            model.Images = product.Medias.Where(x => x.Media.MediaType == Core.Models.MediaType.Image).Select(
                productMedia => new MediaViewModel
                {
                    Url = _mediaService.GetMediaUrl(productMedia.Media),
                    ThumbnailUrl = _mediaService.GetThumbnailUrl(productMedia.Media)
                }).ToList();
        }
    }
}