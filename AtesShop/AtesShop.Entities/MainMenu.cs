using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class MainMenu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }

        public int OrderId { get; set; }

        public virtual List<SubMenu> SubMenus { get; set; }


    }
}
