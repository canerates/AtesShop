using AtesShop.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new AtesShop.Resources.ResourceBuilder();
            string filePath = builder.Create(new DbResourceProvider(),
                summaryCulture: "en-us");

            Console.WriteLine("Created file {0}", filePath);
        }
    }
}
