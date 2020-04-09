using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace AtesShop.Resources {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>Home</summary>
        public static string Home {
               get {
                   return resourceProvider.GetResource("Home", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Products</summary>
        public static string Products {
               get {
                   return resourceProvider.GetResource("Products", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Shop</summary>
        public static string Shop {
               get {
                   return resourceProvider.GetResource("Shop", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Support</summary>
        public static string Support {
               get {
                   return resourceProvider.GetResource("Support", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>About</summary>
        public static string About {
               get {
                   return resourceProvider.GetResource("About", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>About Us</summary>
        public static string AboutUs {
               get {
                   return resourceProvider.GetResource("AboutUs", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Contact Us</summary>
        public static string ContactUs {
               get {
                   return resourceProvider.GetResource("ContactUs", CultureInfo.CurrentUICulture.Name) as string;
               }
            }

        }        
}
