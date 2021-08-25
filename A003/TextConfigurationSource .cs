using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A003
{
    public class TextConfigurationSource : IConfigurationSource
    {
        public string FilePath { get; private set; }
        public TextConfigurationSource(string filename)
        {
            FilePath = filename;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            // получаем полный путь для файла
            string filePath = builder.GetFileProvider().GetFileInfo(FilePath).PhysicalPath;
            return new TextConfigurationProvider(filePath);
        }
    }
}