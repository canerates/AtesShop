using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Services
{
    public class ImageService
    {
        #region Singleton
        public static ImageService Instance
        {
            get
            {
                if (instance == null) instance = new ImageService();

                return instance;
            }
        }
        private static ImageService instance { get; set; }

        private ImageService()
        {
        }

        #endregion

        public Image GetImage(int imageId)
        {
            using (var context = new ASContext())
            {
                return context.Images.Find(imageId);
            }
        }

        public List<Image> GetImages()
        {
            using (var context = new ASContext())
            {
                return context.Images.ToList();
            }
        }

        public List<Image> GetImagesByList(string idText)
        {
            List<int> idList = idText.Split(',').Select(int.Parse).ToList();

            using (var context = new ASContext())
            {
                return context.Images.Where(i => idList.Contains(i.Id)).ToList();
            }
        }

        public void SaveImage(Image image)
        {
            using (var context = new ASContext())
            {
                context.Images.Add(image);
                context.SaveChanges();
            }
        }

        public void UpdateImage(Image image)
        {
            using (var context = new ASContext())
            {
                context.Entry(image).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteImage(int id)
        {
            using (var context = new ASContext())
            {
                var image = context.Images.Find(id);
                context.Images.Remove(image);
                context.SaveChanges();
            }
        }
    }
}
