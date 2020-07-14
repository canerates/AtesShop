using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class DocFile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }
        
    }
}
