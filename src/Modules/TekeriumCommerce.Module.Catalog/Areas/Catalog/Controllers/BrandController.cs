using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Core.Services;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    public class BrandController : Controller
    {
        private int _pageSize;

        private readonly IRepository<Category> _categoryRepository;
        private readonly IMediaService _mediaService;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Brand> _brandRepository;

        public BrandController(IRepository<Category> categoryRepository, 
            IMediaService mediaService, 
            IRepository<Product> productRepository, 
            IRepository<Brand> brandRepository,
            IConfiguration config)
        {
            _categoryRepository = categoryRepository;
            _mediaService = mediaService;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _pageSize = config.GetValue<int>("Catalog.ProductPageSize");
        }

        public IActionResult BrandDetail(long id, SearchOption searchOption)
        {
            var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == id);

            var model = new ProductsByBrand
            {
                BrandId = id,
                BrandName = brand.Name,
                BrandSlug = brand.Slug,
                CurrentSearchOption = searchOption,
                FilterOption = new FilterOption()
            };

            var query = _productRepository.Query().Where(x => x.BrandId == id && x.IsPublished);

            if (!query.Any())
            {
                model.TotalProduct = 0;
                return View(model);
            }

            // todo: append filter option to model
            return null;
        }
    }
}