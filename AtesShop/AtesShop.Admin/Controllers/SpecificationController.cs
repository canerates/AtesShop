using AtesShop.Admin.ViewModels;
using AtesShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtesShop.Admin.Controllers
{
    public class SpecificationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FeatureTable()
        {
            List<FeatureViewModel> model = new List<FeatureViewModel>();
            var features = FeatureService.Instance.GetFeatures();

            foreach (var feature in features)
            {
                FeatureViewModel elem = new FeatureViewModel();
                elem.Feature = feature;

                var featureKey = "Feature" + feature.FeatureId;
                elem.FeatureResources = ResourceService.Instance.GetResourcesByKey(featureKey);
                elem.ResourceCount = ResourceService.Instance.GetResourcesCountByKey(featureKey);

                model.Add(elem);
            }
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult ASectionTable()
        {
            List<AttributeSectionViewModel> model = new List<AttributeSectionViewModel>();
            var sections = AttributeService.Instance.GetAttributeSections();

            foreach (var section in sections)
            {
                AttributeSectionViewModel elem = new AttributeSectionViewModel();
                elem.AttributeSection = section;

                var sectionKey = "ASection" + section.AttributeSectionId;
                elem.ASectionResources = ResourceService.Instance.GetResourcesByKey(sectionKey);
                elem.ResourceCount = ResourceService.Instance.GetResourcesCountByKey(sectionKey);

                model.Add(elem);
            }
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult ATypeTable()
        {
            List<AttributeTypeViewModel> model = new List<AttributeTypeViewModel>();
            var types = AttributeService.Instance.GetAttributeTypes();

            foreach (var type in types)
            {
                AttributeTypeViewModel elem = new AttributeTypeViewModel();
                elem.AttributeType = type;

                var typeKey = "AType" + type.AttributeTypeId;
                elem.ATypeResources = ResourceService.Instance.GetResourcesByKey(typeKey);
                elem.ResourceCount = ResourceService.Instance.GetResourcesCountByKey(typeKey);

                model.Add(elem);
            }
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult AValueTable()
        {
            List<AttributeValueViewModel> model = new List<AttributeValueViewModel>();
            var values = AttributeService.Instance.GetAttributeValues();

            foreach (var value in values)
            {
                AttributeValueViewModel elem = new AttributeValueViewModel();
                elem.AttributeValue = value;

                var valueKey = "AValue" + value.AttributeValueId;
                elem.AValueResources = ResourceService.Instance.GetResourcesByKey(valueKey);
                elem.ResourceCount = ResourceService.Instance.GetResourcesCountByKey(valueKey);

                model.Add(elem);
            }
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult AttributeTable()
        {
            List<ProductAttributeViewModel> model = new List<ProductAttributeViewModel>();
            var products = ProductService.Instance.GetProducts();

            foreach (var product in products)
            {
                ProductAttributeViewModel elem = new ProductAttributeViewModel();
                elem.Product = product;
                
                var sections = AttributeService.Instance.GetAttributeSectionsByProduct(product.Id);

                List<SectionCellViewModel> sectCells = new List<SectionCellViewModel>();

                foreach (var section in sections)
                {
                    SectionCellViewModel sectCell = new SectionCellViewModel();

                    sectCell.Section = section;
                    sectCell.Types = AttributeService.Instance.GetAttributeTypesByProductAndSection(product.Id, section.AttributeSectionId);
                    sectCell.Values = AttributeService.Instance.GetAttributesValueByProductAndSection(product.Id, section.AttributeSectionId);

                    sectCells.Add(sectCell);
                }
                elem.SectionCells = sectCells;
                elem.AttributesCount = AttributeService.Instance.GetProductAttributesCount(product.Id);


                model.Add(elem);
            }
            return PartialView(model);
        }

        public ActionResult AddSection()
        {

            return PartialView();
        }
        
        public ActionResult AddAttribute()
        {
            return PartialView();
        }
    }
}