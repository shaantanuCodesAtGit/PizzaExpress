using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Text;

namespace Utility.Helper
{
    public static class ImageHelper
    {
        public static string Read(string fileName)
        {
            var dic = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}\\PizzaOrderingApiServer\\Data\\Database\\Images\\{fileName}.jpg";

            var fileInfo = new FileInfo(dic);

            // The byte[] to save the data in
            byte[] data = new byte[fileInfo.Length];

            // Load a filestream and put its content into the byte[]
            using (FileStream fs = fileInfo.OpenRead())
            {
                fs.Read(data, 0, data.Length);
            }

            return Convert.ToBase64String(data);
        }
    }
}
