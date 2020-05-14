using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class ProductAttribute
    {
        [Key]
        public int ProductAttributeId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [ForeignKey("AttributeSection")]
        public int AttributeSectionId { get; set; }
        
        public virtual AttributeSection AttributeSection { get; set; }

        [ForeignKey("AttributeType")]
        public int AttributeTypeId { get; set; }

        public virtual AttributeType AttributeType { get; set; }

        [ForeignKey("AttributeValue")]
        public int AttributeValueId { get; set; }

        public virtual AttributeValue AttributeValue { get; set; }

        public int OrderId { get; set; }

    }
}
