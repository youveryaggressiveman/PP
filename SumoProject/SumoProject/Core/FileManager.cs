using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace SumoProject.Core
{
    public class FileManager
    {
        private readonly string _path = @"../../Assets/";

        public async Task<string> ReadFile(string name)
        {
            try
            {
                var path =  _path + "Files/" + name + ".txt";

                using (StreamReader reader = new StreamReader(path))
                {
                    var result = await reader.ReadToEndAsync();

                    return result;
                }
            }
            catch
            {
                return " ";
            }

        }

        public Uri FindUri(string name)
        {
            try
            {
                DirectoryInfo directoryInfo= new DirectoryInfo(_path + "Images/");

                foreach (var item in directoryInfo.GetFiles())
                {
                    if(item.Name == name + ".png")
                    {
                        return new Uri(item.FullName);
                    }
                }

                return null;
            }
            catch 
            {

                throw;
            }
            
        }
    }
}
