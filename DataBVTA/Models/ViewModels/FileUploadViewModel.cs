using DataBVTA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Models.ViewModels
{
    public class FileUploadViewModel
    {
        public List<FileOnFileSystemModel> FilesOnFileSystem { get; set; }
        public List<FileOnDatabaseModel> FilesOnDatabase { get; set; }
    }
}
