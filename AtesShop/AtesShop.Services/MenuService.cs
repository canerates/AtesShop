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

        public MainMenu GetMainMenu(int id)
        {
            using (var context = new ASContext())
            {
                return context.MainMenus.Find(id);
            }
        }

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

        public void SaveMainMenu(MainMenu menu)
        {
            using (var context = new ASContext())
            {
                context.MainMenus.Add(menu);

                context.SaveChanges();
            }
        }

        public void UpdateMainMenu(MainMenu menu)
        {
            using (var context = new ASContext())
            {
                context.Entry(menu).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteMainMenu(int id)
        {
            using (var context = new ASContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                var menu = context.MainMenus.Find(id);
                context.MainMenus.Remove(menu);
                context.SaveChanges();
            }
        }

        public SubMenu GetSubMenu(int id)
        {
            using (var context = new ASContext())
            {
                return context.SubMenus.Find(id);
            }
        }

        public List<SubMenu> GetSubMenus()
        {
            using (var context = new ASContext())
            {
                return context.SubMenus
                    .Include(x => x.MainMenu)
                    .OrderBy(x => x.MainMenu.Id)
                    .ThenBy(x => x.OrderId)
                    .ToList();
            }
        }

        public List<SubMenu> GetSubMenuByParent(int mainMenuId)
        {
            using (var context = new ASContext())
            {
                return context.SubMenus
                    .Where(x => x.MainMenuId == mainMenuId)
                    .Include(x => x.MainMenu)
                    .OrderBy(x => x.OrderId)
                    .ToList();
            }
        }

        public void SaveSubMenu(SubMenu menu)
        {
            using (var context = new ASContext())
            {

                context.Entry(menu.MainMenu).State = System.Data.Entity.EntityState.Unchanged;

                context.SubMenus.Add(menu);

                context.SaveChanges();
            }
        }

        public void UpdateSubMenu(SubMenu menu)
        {
            using (var context = new ASContext())
            {
                context.Entry(menu).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteSubMenu(int id)
        {
            using (var context = new ASContext())
            {
                var menu = context.SubMenus.Find(id);
                context.SubMenus.Remove(menu);
                context.SaveChanges();
            }
        }
    }
}
