using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class AttributeValue
    {
        [Key]
        public int AttributeValueId { get; set; }
        
        public string Name { get; set; }
        
    }
}
