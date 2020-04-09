using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class Resource
    {
        [Key, Column(Order = 1)]
        public int Id { get; set; }

        [Column(Order = 2)]
        public string Key { get; set; }

        [Column(Order = 3)]
        public string Value { get; set; }

        [Column(Order = 4)]
        public string Culture { get; set; }
    }
}
