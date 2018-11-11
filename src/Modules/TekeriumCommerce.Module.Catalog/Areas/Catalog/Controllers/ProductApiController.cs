using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Infrastructure.Web.SmartTable;
using TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Core.Extensions;
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
        private readonly IWorkContext _workContext;

        public ProductApiController(IMediaService mediaService, IRepository<Product> productRepository, IRepository<ProductMedia> productMediaRepository, IWorkContext workContext)
        {
            _mediaService = mediaService;
            _productRepository = productRepository;
            _productMediaRepository = productMediaRepository;
            _workContext = workContext;
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

            return null;
        }
    }
}