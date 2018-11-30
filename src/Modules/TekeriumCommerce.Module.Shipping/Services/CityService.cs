using TekeriumCommerce.Module.Shipping.Models;

namespace TekeriumCommerce.Module.Shipping.Services
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _cityRepository;

        public CityService(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task Create(City city)
        {
            using (var transaction = _cityRepository.BeginTransaction()) {
                _cityRepository.Add(city);
                await _cityRepository.SaveChangesAsync();

                transaction.Commit();
            }
        }

        public async Task Delete(long id)
        {
            var city = _cityRepository.Query().First(x => x.Id == id);
            await Delete(city);
        }

        public async Task Delete(City city)
        {
            _cityRepository.Remove(city);

            await _cityRepository.SaveChangesAsync();
        }

        public async Task Update(City city)
        {
            await _cityRepository.SaveChangesAsync();
        }
    }
}