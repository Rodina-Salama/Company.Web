using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Company.Service.Helper
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            // var folderPath = @" D:\.net - project\Company.Web\Company.Web\wwwroot\files\Images\";
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);
            var fileName = "${Guid.NewGuid()}-{file.FileName}";
            var filepath = Path.Combine(folderpath, fileName);
            using var fileStream = new FileStream(filepath, FileMode.Create);
            file.CopyTo(fileStream);
            return filepath;
        }
    }
}
