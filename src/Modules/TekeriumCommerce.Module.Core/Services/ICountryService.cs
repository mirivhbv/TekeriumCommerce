namespace TekeriumCommerce.Module.Core.Services
{
    public interface ICountryService
    {
        string ToFlagApiUrl(string countryCode, string style, int imgSize);
    }
}