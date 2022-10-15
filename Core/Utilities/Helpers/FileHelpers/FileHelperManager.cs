using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Core.Utilities.Helpers.FileHelpers
{
    public class FileHelperManager : IFileHelperService
    {
        private static string _currentFileDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";

        public IResult Upload(List<IFormFile> files)
        {
            StringBuilder builder = new StringBuilder();

            if (files.Count > 0 && files != null)
            {
                if (!Directory.Exists(_currentFileDirectory+ _folderName))
                {
                    Directory.CreateDirectory(_currentFileDirectory+ _folderName);
                }

                foreach (var file in files)
                {
                    string extension = Path.GetExtension(file.FileName);
                    string guid = Guid.NewGuid().ToString();
                    string path = guid + extension;

                    using (Stream fileStream = new FileStream(_currentFileDirectory + _folderName + path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    return new SuccessResult((_folderName + guid + extension).Replace("\\", "/"));
                }
            }
            return new ErrorResult("Resim yüklenmedi");
        }
    }
}
