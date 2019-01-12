namespace TekeriumCommerce.Module.Core.Services
{
    public class CountryService : ICountryService
    {
        /// <summary>
        /// Accepts country code and size, afterwards returns specific country flag image address from https://countryflags.io
        /// </summary>
        /// <param name="countryCode">Country Code (AZ, TR, RU and etc.)</param>
        /// <param name="style">There are only 2 type of flag image: flat and shinny</param>
        /// <param name="imgSize">size of image (16, 24, 32, 48, 64)</param>
        /// <returns></returns>
        public string ToFlagApiUrl(string countryCode, string style, int imgSize)
        {
            return $"https://www.countryflags.io/{countryCode}/{style}/{imgSize}.png";
        }
    }
}