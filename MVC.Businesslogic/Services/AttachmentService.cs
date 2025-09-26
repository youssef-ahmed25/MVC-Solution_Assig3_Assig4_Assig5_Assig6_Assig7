using Microsoft.AspNetCore.Http;
using MVC.Businesslogic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Businesslogic.Services
{
    public class AttachmentService : IAttachmentService
    {
        List<string> allowedExtensions = new List<string>() { ".png", ".Jpg", ".jpeg" };
        const int maxSize = 2 * 1024 * 1024;
        public string? Upload(IFormFile file, string folderName)
        {
            var extension = Path.GetExtension(file.FileName);
            if(!allowedExtensions.Contains(extension))
            {
                return null;
            }
            if (file.Length > maxSize || file.Length==0)
            {
                return null;
            }
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", folderName);
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(folderPath, fileName);
            using FileStream fs=new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);
            return fileName;
        }
        public bool Delete(string filePath)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
    }
}
