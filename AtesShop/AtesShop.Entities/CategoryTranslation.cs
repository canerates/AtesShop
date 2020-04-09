﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class CategoryTranslation
    {
        public int Id { get; set; }

        public string CategoryNameResourceKey { get; set; }

        public string CategoryDescriptionResourceKey { get; set; }
        
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
