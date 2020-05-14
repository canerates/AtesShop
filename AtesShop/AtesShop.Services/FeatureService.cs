using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Services
{
    public class FeatureService
    {
        #region Singleton
        public static FeatureService Instance
        {
            get
            {
                if (instance == null) instance = new FeatureService();

                return instance;
            }
        }
        private static FeatureService instance { get; set; }

        private FeatureService()
        {
        }

        #endregion

        public List<Feature> GetProductFeatures(int productId)
        {
            using (var context = new ASContext())
            {
                List<Feature> features = new List<Feature>();
                var productFeatures = context.ProductFeatures.Where(x => x.ProductId == productId).ToList();
                foreach (var pf in productFeatures)
                {
                    var feature = context.Features.Where(x => x.FeatureId == pf.FeatureId).FirstOrDefault();
                    features.Add(feature);
                }
                return features;
            }
        }

        public List<Feature> GetFeatures()
        {
            using (var context = new ASContext())
            {
                return context.Features.ToList();
            }
        }
    }
}
