using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtesShop.Admin.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }

        public List<Resource> CategoryNameResources { get; set; }
        public List<Resource> CategoryDescriptionResources { get; set; }
        public int ResourceCount { get; set; }
        
        public List<Image> Images { get; set; }

    }

    public class NewCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageIdList { get; set; }

        public List<int> SelectedImages { get; set; }

        public List<Image> AvailableImages { get; set; }
    }

    public class EditCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageIdList { get; set; }

        public List<int> SelectedImages { get; set; }

        public List<Image> AvailableImages { get; set; }

    }

    public class NewCategoryTranslationModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Culture { get; set; }

    }

    public class EditCategoryTranslationViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Culture { get; set; }

    }

    public class CategoryTranslationResources
    {
        public List<Resource> NameResources { get; set; }
        public List<Resource> DescriptionResources { get; set; }
        public int ResourceCount { get; set; }
        public int KeySetId { get; set; }

    }


}