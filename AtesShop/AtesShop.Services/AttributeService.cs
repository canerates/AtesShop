using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Services
{
    public class AttributeService
    {
        #region Singleton
        public static AttributeService Instance
        {
            get
            {
                if (instance == null) instance = new AttributeService();

                return instance;
            }
        }
        private static AttributeService instance { get; set; }

        private AttributeService()
        {
        }

        #endregion

        #region Admin

        public List<AttributeSection> GetAttributeSections()
        {
            using (var context = new ASContext())
            {
                return context.AttributeSections.ToList();
            }
        }

        public List<AttributeSection> GetAttributeSections(int productId)
        {
            using (var context = new ASContext())
            {
                return context.ProductAttributes.Where(x => x.ProductId == productId).Select(x => x.AttributeSection).Distinct().ToList();
            }
        }

        public List<AttributeType> GetAttributeTypes()
        {
            using (var context = new ASContext())
            {
                return context.AttributeTypes.ToList();
            }
        }

        public List<AttributeType> GetAttributeTypes(int productId, int sectionId)
        {
            using (var context = new ASContext())
            {
                return context.ProductAttributes.Where(x => x.ProductId == productId && x.AttributeSectionId == sectionId).Select(x => x.AttributeType).ToList();
            }
        }

        public List<AttributeValue> GetAttributeValues()
        {
            using (var context = new ASContext())
            {
                return context.AttributeValues.ToList();
            }
        }

        public List<AttributeValue> GetAttributeValues(int productId, int sectionId)
        {
            using (var context = new ASContext())
            {
                return context.ProductAttributes.Where(x => x.ProductId == productId && x.AttributeSectionId == sectionId).Select(x => x.AttributeValue).ToList();
            }
        }

        public int GetProductAttributesCount(int productId)
        {
            using (var context = new ASContext())
            {
                return context.ProductAttributes.Where(x => x.ProductId == productId).Count();
            }
        }

        #endregion

        #region Web

        public Dictionary<AttributeSection, List<ProductAttribute>> GetProductAttributes(int productId)
        {
            using (var context = new ASContext())
            {
                Dictionary<AttributeSection, List<ProductAttribute>> dict = new Dictionary<AttributeSection, List<ProductAttribute>>();
                var attributes = context.ProductAttributes.Where(x => x.ProductId == productId).Include("AttributeType").Include("AttributeValue").Include("AttributeSection").ToList();

                foreach (var attr in attributes)
                {
                    if (dict.ContainsKey(attr.AttributeSection))
                    {
                        dict[attr.AttributeSection].Add(attr);
                    }
                    else
                    {
                        List<ProductAttribute> valueList = new List<ProductAttribute>();
                        dict.Add(attr.AttributeSection, valueList);
                        dict[attr.AttributeSection].Add(attr);
                    }
                }
                return dict;
            }
        }

        #endregion
    }
}
