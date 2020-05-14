using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class AttributeType
    {
        [Key]
        public int AttributeTypeId { get; set; }
        
        public string Name { get; set; }
        
    }
}
