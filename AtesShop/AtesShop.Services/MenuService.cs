using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AtesShop.Services
{
    public class MenuService
    {
        public List<MainMenu> GetMainMenus()
        {
            using (var context = new ASContext())
            {
                return context.MainMenus
                    .Include(x => x.SubMenus)
                    .OrderBy(x => x.OrderId)
                    .ToList();
            }
        }

        public List<SubMenu> GetSubMenus(int mainMenuId)
        {
            using (var context = new ASContext())
            {
                return context.SubMenus
                    .Where(x => x.MainMenu.Id == mainMenuId)
                    .Include(x => x.MainMenu)
                    .OrderBy(x => x.OrderId)
                    .ToList();
            }
        }

    }
}
