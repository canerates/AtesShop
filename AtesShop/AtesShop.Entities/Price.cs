using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class Price
    {
        public int Id { get; set; }
        
        public string Key { get; set; }
        
        public string Value { get; set; }

        public string PreValue { get; set; }

        public string Culture { get; set; }

        public string RoleId { get; set; }

        public string RoleName { get; set; }
        
    }
}
