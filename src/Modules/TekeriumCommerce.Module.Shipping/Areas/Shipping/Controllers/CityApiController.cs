using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Shipping.Areas.Shipping.ViewModels;
using TekeriumCommerce.Module.Shipping.Models;
using TekeriumCommerce.Module.Shipping.Services;

namespace TekeriumCommerce.Module.Shipping.Areas.Shipping.Controllers {
    [Area ("Shipping")]
    [Authorize (Roles = "admin")]
    [Route ("api/shipping")]
    public class CityApiController : Controller {
        private readonly IRepository<City> _cityRepository;
        private readonly ICityService _cityService;

        public CityApiController(IRepository<City> cityRepository, ICityService cityService) {
            _cityRepository = cityRepository;
            _cityService = cityService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Get () {
            var cities = await _cityRepository.Query ()
                .Select (x => new CityVm {
                    Id = x.Id,
                    Name = x.Name,
                    Cost = x.Cost,
                }).ToListAsync ();

            return Json (cities);
        }

        [HttpGet ("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get (long id) {
            var city = await _cityRepository.Query ().FirstOrDefaultAsync (x => x.Id == id);

            var model = new CityVm {
                Id = city.Id,
                Name = city.Name,
                Cost = city.Cost
            };

            return Json (model);
        }

        [HttpPost ("add")]
        public async Task<IActionResult> Add ([FromBody] CityVm model) {
            if (ModelState.IsValid) {
                var city = new City {
                    Name = model.Name,
                    Cost = model.Cost
                };

                await _cityService.Create(city);
                return CreatedAtAction (nameof (Get), new { id = city.Id }, null);
            }

            return BadRequest (ModelState);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> Put (long id, [FromBody] CityVm model) {
            if (ModelState.IsValid) {
                var city = _cityRepository.Query ().FirstOrDefault (x => x.Id == id);
                if (city is null) {
                    return NotFound ();
                }

                city.Name = model.Name;
                city.Cost = model.Cost;

                await _cityService.Update (city);
                return Accepted ();
            }

            return BadRequest (ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (long id) {
            var city = _cityRepository.Query ().FirstOrDefault (x => x.Id == id);
            if (city is null) {
                return NotFound ();
            }
            
            await _cityService.Delete(city);
            return NoContent();
        }
    }
}