using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Services
{
    public class UserService
    {
        #region Singleton

        public static UserService Instance
        {
            get
            {
                if (instance == null) instance = new UserService();

                return instance;
            }
        }
        private static UserService instance { get; set; }

        private UserService()
        {
        }

        #endregion

        #region Admin



        #endregion

        #region Web

        #region UserAddress

        public UserAddress GetUserAddress(int id)
        {
            using (var context = new ASContext())
            {
                return context.UserAddresses.Find(id);
            }
        }

        public List<UserAddress> GetUserAddressList(string userId)
        {
            using (var context = new ASContext())
            {
                return context.UserAddresses.Where(x => x.UserId == userId).ToList();
            }
        }

        public List<int> GetUserAddressIdList(string userId)
        {
            using (var context = new ASContext())
            {
                return context.UserAddresses.Where(x => x.UserId == userId).Select(x => x.Id).ToList();
            }
        }

        public void SaveUserAddress(UserAddress address)
        {
            using (var context = new ASContext())
            {
                context.UserAddresses.Add(address);
                context.SaveChanges();
            }
        }

        public void UpdateUserAddress(UserAddress address)
        {
            using (var context = new ASContext())
            {
                context.Entry(address).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteUserAddress(int id)
        {
            using (var context = new ASContext())
            {
                var address = context.UserAddresses.Find(id);
                context.UserAddresses.Remove(address);
                context.SaveChanges();
            }
        }

        #endregion

        #endregion
    }
}
