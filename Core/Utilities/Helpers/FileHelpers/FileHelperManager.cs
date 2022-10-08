using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelpers
{
    public class FileHelperManager : IFileHelperService
    {
        public string Upload(List<IFormFile> files, string root)
        {
            StringBuilder builder = new StringBuilder();

            if (files.Count > 0 && files!=null)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                foreach (var file in files)
                {

                
                    string extension = Path.GetExtension(file.FileName);
                    string guid = Guid.NewGuid().ToString();
                    string path = guid + extension;

                    using (Stream fileStream = new FileStream(root + path,FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    return path;
             }     
            }
            return null;
        }
    }
}
