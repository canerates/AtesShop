using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtesShop.Admin.ViewModels
{
    public class ResourceKeyViewModel
    {
        public string ResourceKey { get; set; }
        public List<Resource> Resources { get; set; }
        public int ResourceCount { get; set; }

    }

    public class ResourceViewModel
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Culture { get; set; }
    }
    
}