using System.IO;
using System.Threading.Tasks;
using TekeriumCommerce.Infrastructure;
using TekeriumCommerce.Module.Core.Services;

namespace TekeriumCommerce.Module.StorageLocal
{
    public class LocalStorageService : IStorageService
    {
        private const string MediaRootFolder = "user-content";

        public string GetMediaUrl(string fileName)
        {
            return $"/{MediaRootFolder}/{fileName}";
        }

        public async Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            var filePath = Path.Combine(GlobalConfiguration.WebRootPath, MediaRootFolder, fileName);
            using (var output = new FileStream(filePath, FileMode.Create))
            {
                await mediaBinaryStream.CopyToAsync(output);
            }
        }

        public async Task DeleteMediaAsync(string fileName)
        {
            var filePath = Path.Combine(GlobalConfiguration.WebRootPath, MediaRootFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}