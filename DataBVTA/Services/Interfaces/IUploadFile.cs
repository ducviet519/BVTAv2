using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Interfaces
{
    public interface IUploadFile
    {
        public Task<string> UploadMultipleFileAsync(List<IFormFile> files);

        public string DeleteFile(string filePath);

        public Task<string> UploadFileAsync(IFormFile fileUpload);
    }
}
