using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
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
    [Route("api/brands")]
    public class BrandApiController : Controller
    {
        private readonly IRepository<Brand> _brandRepository;
        private readonly IBrandService _brandService;
        private readonly IMediaService _mediaService;
        private readonly IRepository<Media> _mediaRepository;

        public BrandApiController(IRepository<Brand> brandRepository, IBrandService brandService, IMediaService mediaService, IRepository<Media> mediaRepository)
        {
            _brandRepository = brandRepository;
            _brandService = brandService;
            _mediaService = mediaService;
            _mediaRepository = mediaRepository;
        }

        public async Task<IActionResult> Get()
        {
            var brandList = await _brandRepository.Query().Where(x => !x.IsDeleted).ToListAsync();

            return Json(brandList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var brand = await _brandRepository.Query().Include(x => x.Media).FirstOrDefaultAsync(x => x.Id == id);
            var model = new BrandVm
            {
                Id = brand.Id,
                Name = brand.Name,
                Slug = brand.Slug,
                IsPublished = brand.IsPublished,
                BrandImageUrl = _mediaService.GetThumbnailUrl(brand.Media)
            };

            return Json(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post(BrandForm model)
        {
            if (ModelState.IsValid)
            {
                var brand = new Brand
                {
                    Name = model.Brand.Name,
                    Slug = model.Brand.Slug,
                    IsPublished = model.Brand.IsPublished
                };

                // save image
                var fileName = await SaveFile(model.BrandImage);
                var media = new Media {FileName = fileName, MediaType = MediaType.Image};

                _mediaRepository.Add(media);

                brand.Media = media;

                await _brandService.Create(brand);
                return CreatedAtAction(nameof(Get), new { id = brand.Id }, null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(long id, BrandForm model)
        {
            if (ModelState.IsValid)
            {
                var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == id);
                if (brand == null)
                {
                    return NotFound();
                }

                brand.Name = model.Brand.Name;
                brand.Slug = model.Brand.Slug;
                brand.IsPublished = model.Brand.IsPublished;
                
                // save image
                var fileName = await SaveFile(model.BrandImage);
                var media = new Media { FileName = fileName, MediaType = MediaType.Image };

                _mediaRepository.Add(media);

                brand.Media = media;

                await _brandService.Update(brand);
                return Accepted();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(long id)
        {
            var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            await _brandService.Delete(brand);
            return NoContent();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _mediaService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }
    }
}