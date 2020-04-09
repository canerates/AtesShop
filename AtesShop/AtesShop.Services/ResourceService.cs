using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Services
{
    public class ResourceService
    {
        public List<Resource> GetResources()
        {
            using (var context = new ASContext())
            {
                return context.Resources.ToList();
            }
        }

        public Resource GetResource(string key, string culture)
        {
            using (var context = new ASContext())
            {
                return context.Resources
                    .Where(x => x.Key == key && x.Culture == culture)
                    .FirstOrDefault();
            }
        }

        public List<Resource> GetResourcesByKey(string key)
        {
            using (var context = new ASContext())
            {
                return context.Resources.Where(x => x.Key == key).ToList();
            }
        }

        public Resource GetResourceById(int id)
        {
            using (var context = new ASContext())
            {
                return context.Resources.Find(id);
            }
        }

        public int GetResourcesCountByKey(string key)
        {
            using (var context = new ASContext())
            {
                return context.Resources.Where(x => x.Key == key).Count();
            }
        }

        public List<string> GetResourceDistinctKeys()
        {
            using (var context = new ASContext())
            {
                return context.Resources.Select(r => r.Key).Distinct().ToList();
            }
        }

        public void SaveResource(Resource resource)
        {
            using (var context = new ASContext())
            {
                context.Resources.Add(resource);
                context.SaveChanges();
            }
        }

        public void UpdateResource(Resource resource)
        {
            using (var context = new ASContext())
            {
                context.Entry(resource).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteResource(int id)
        {
            using (var context = new ASContext())
            {
                var resource = context.Resources.Find(id);
                context.Resources.Remove(resource);
                context.SaveChanges();
            }
        }

        public void DeleteResources(string key)
        {
            using (var context = new ASContext())
            {
                var resources = context.Resources.Where(x => x.Key == key).ToList();
                context.Resources.RemoveRange(resources);
                context.SaveChanges();
            }
        }

    }
}
