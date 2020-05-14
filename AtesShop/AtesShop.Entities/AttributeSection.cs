using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class AttributeSection
    {
        [Key]
        public int AttributeSectionId { get; set; }
        
        public string Name { get; set; }
        
    }
}
