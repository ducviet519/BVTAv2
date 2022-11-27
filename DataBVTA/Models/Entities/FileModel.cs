using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Models.Entities
{
    public abstract class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public string UploadedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
    public class FileOnFileSystemModel : FileModel
    {
        public string FilePath { get; set; }
    }
    public class FileOnDatabaseModel : FileModel
    {
        public byte[] Data { get; set; }
    }
}
