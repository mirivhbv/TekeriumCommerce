using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Catalog.Services;
using TekeriumCommerce.Module.Core.Services;
using TekeriumCommerce.Module.Search.Areas.Search.ViewModels;

namespace TekeriumCommerce.Module.Search.Areas.Search.Controllers
{
    [Area("search")]
    public class SearchController : Controller
    {
        private readonly int _pageSize;

        private readonly IRepository<Product> _productRepository;
        private readonly IMediaService _mediaService;
        private readonly IProductPricingService _productPricingService;

        public SearchController(IRepository<Product> productRepository,
                IMediaService mediaService,
                IProductPricingService productPricingService,
                IConfiguration config)
        {
            _productRepository = productRepository;
            _mediaService = mediaService;
            _productPricingService = productPricingService;
            _pageSize = config.GetValue<int>("Catalog.ProductPageSize");
        }

        [HttpGet("search")]
        public IActionResult Index(SearchOption searchOption)
        {
            if (string.IsNullOrWhiteSpace(searchOption.Width) || string.IsNullOrWhiteSpace(searchOption.Profile) ||
                string.IsNullOrWhiteSpace(searchOption.RimSize))
            {
                return Redirect("~/");
            }

            var model = new SearchResult
            {
                CurrentSearchOption = searchOption
            };

            var query = _productRepository.Query().Where(x =>
                x.Category.Name == searchOption.Category &&
                x.TyreWidth.Size == searchOption.Width && x.TyreProfile.Size == searchOption.Profile &&
                x.TyreRimSize.Size == searchOption.RimSize && 
                x.IsPublished);

            if (!query.Any())
            {
                model.TotalProduct = 0;
                return View(model);
            }

            // todo: append filter option

            if (searchOption.ProductSeason != "All")
            {
                query.Where(x => x.ProductSeason.Name == searchOption.ProductSeason);
            }

            model.TotalProduct = query.Count();

            var currentPageNum = searchOption.Page <= 0 ? 1 : searchOption.Page;

            var offset = (_pageSize * currentPageNum) - _pageSize;

            while (currentPageNum > 1 && offset > model.TotalProduct)
            {
                currentPageNum--;
                offset = (_pageSize * currentPageNum) - _pageSize;
            }

            // todo: save query (search) to db

            query = query.Include(x => x.ThumbnailImage);

            var products = query
                .Select(x => ProductThumbnail.FromProduct(x))
                .Skip(offset)
                .Take(_pageSize)
                .ToList();

            foreach (var product in products)
            {
                product.ThumbnailUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage);
                product.CalculatedProductPrice = _productPricingService.CalculateProductPrice(product);
            }

            model.Products = products;
            model.CurrentSearchOption.PageSize = _pageSize;
            model.CurrentSearchOption.Page = currentPageNum;

            return View(model);
        }

        // todo: applysort
        // todo: appendfilteroptions
    }
}