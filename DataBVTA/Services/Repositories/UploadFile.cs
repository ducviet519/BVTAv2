using DataBVTA.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataBVTA.Services.Repositories
{
    public class UploadFile : IUploadFile
    {

        public string DeleteFile(string filePath)
        {
            string result = "";
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                file.Delete();
                result = "Đã xóa file thành công";
                return result;
            }
            else
            {
                result = "Lỗi! Xóa file không thành công";
                return result;
            }

        }
        
        //FileUploadPhysical
        public async Task<string> UploadMultipleFileAsync(List<IFormFile> files)
        {
            string FileLink = "";
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();
                    //var filePath = Path.Combine(_config["StoredFilesPath"],Path.GetRandomFileName());
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    FileLink = filePath;
                }
            }
            return FileLink;
        }

        public async Task<string> UploadFileAsync(IFormFile fileUpload)
        {
            string FileLink = "";
            string getDateS = DateTime.Now.ToString("ddMMyyyyHHmmss");
            //string uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "Upload");
            string uploadsFolder = "D:\\VanBan\\My Drive\\VBNB FileUpload";
            if (!Directory.Exists(uploadsFolder)) { Directory.CreateDirectory(uploadsFolder); }

            if (fileUpload != null && fileUpload.Length > 0)
            {
                string fileName = $"{getDateS}_{fileUpload.FileName}";
                //string fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUpload.FileName);

                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    await fileUpload.CopyToAsync(fileStream);
                }

                //string fileGoogleID = _googleDriveAPI.UploadFile(filePath);
                return FileLink = filePath;
            }
            else
                return FileLink = "";
        }
    }
}
