using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Services
{
    public class RatingService
    {
        #region Singleton
        public static RatingService Instance
        {
            get
            {
                if (instance == null) instance = new RatingService();

                return instance;
            }
        }
        private static RatingService instance { get; set; }

        private RatingService()
        {
        }

        #endregion

        #region Admin

        public Rating GetProductRatings(int productId)
        {
            using (var context = new ASContext())
            {
                return context.Ratings.Where(x => x.ProductId == productId).FirstOrDefault();
            }
        }

        public void SaveProductRating(Rating rating)
        {
            using (var context = new ASContext())
            {
                context.Entry(rating.Product).State = System.Data.Entity.EntityState.Unchanged;
                context.Ratings.Add(rating);
                context.SaveChanges();
            }
        }

        #endregion
        
    }
}
