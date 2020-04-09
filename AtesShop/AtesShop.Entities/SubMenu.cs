using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class SubMenu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }

        public int ParameterId { get; set; }

        public int OrderId { get; set; }
        
        [ForeignKey("MainMenu")]
        public int MainMenuId { get; set; }

        public virtual MainMenu MainMenu { get; set; }

        public string ResourceKey { get; set; }
    }
}
