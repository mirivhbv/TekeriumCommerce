using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TekeriumCommerce.Module.Core.Services
{
    public class FakeStorageService : IStorageService
    {
        public string GetMediaUrl(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMediaAsync(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
