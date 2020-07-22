using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Services
{
    public class InventoryService
    {
        #region Singleton

        public static InventoryService Instance
        {
            get
            {
                if (instance == null) instance = new InventoryService();

                return instance;
            }
        }
        private static InventoryService instance { get; set; }

        private InventoryService()
        {
        }

        #endregion

        #region Admin

        #endregion

        #region Web

        public InventoryItem GetInventory(int productId)
        {
            using (var context = new ASContext())
            {
                return context.Inventory.Find(productId);
            }
        }

        public void UpdateInventory(InventoryItem item)
        {
            using (var context = new ASContext())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }


        #endregion

    }
}
