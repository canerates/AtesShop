using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtesShop.Admin.ViewModels
{
    public class FeatureViewModel
    {
        public Feature Feature { get; set; }
        public List<Resource> FeatureResources { get; set; }
        public int ResourceCount { get; set; }

    }

    public class AttributeSectionViewModel
    {
        public AttributeSection AttributeSection { get; set; }
        public List<Resource> ASectionResources { get; set; }
        public int ResourceCount { get; set; }

    }

    public class AttributeTypeViewModel
    {
        public AttributeType AttributeType { get; set; }
        public List<Resource> ATypeResources { get; set; }
        public int ResourceCount { get; set; }
    }

    public class AttributeValueViewModel
    {
        public AttributeValue AttributeValue { get; set; }
        public List<Resource> AValueResources { get; set; }
        public int ResourceCount { get; set; }
    }

    public class ProductAttributeViewModel
    {
        public Product Product { get; set; }
        public List<SectionCellViewModel> SectionCells { get; set; }
        public int AttributesCount { get; set; }
        
    }

    public class SectionCellViewModel
    {
        public AttributeSection Section { get; set; }
        public List<AttributeType> Types { get; set; }
        public List<AttributeValue> Values { get; set; }
    }
    
}