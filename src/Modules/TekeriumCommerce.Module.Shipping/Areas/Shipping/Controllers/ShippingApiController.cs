using System.Threading.Tasks;
using TekeriumCommerce.Module.Shipping.Areas.Shipping.ViewModels;
using TekeriumCommerce.Module.Shipping.Models;
using TekeriumCommerce.Module.Shipping.Services;

namespace TekeriumCommerce.Module.Shipping.Areas.Shipping.Controllers {
    [Area ("Shipping")]
    [Authorize (Roles = "admin")]
    [Route ("api/shipping")]
    public class ShippingApiController : Controller {
        private readonly IRepository<City> _cityRepository;
        private readonly ICityService _cityService;

        public ShippingApiController (IRepository<City> cityRepository, ICityService cityService) {
            _cityRepository = cityRepository;
            _cityService = cityService;
        }

        public async Task<IActionResult> Get () {
            var cities = await _cityRepository.Query ()
                .Select (x => new {
                    x.Id,
                        x.Name,
                        x.Cost
                }).ToListAsync ();

            return Json (cities);
        }

        [HttpGet ("{id}")]
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

                await _cityService.Create (city);
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

        [HttpDelete]
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