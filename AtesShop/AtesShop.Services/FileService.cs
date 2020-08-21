using AtesShop.Database;
using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Services
{
    public class FileService
    {
        #region Singleton
        public static FileService Instance
        {
            get
            {
                if (instance == null) instance = new FileService();

                return instance;
            }
        }
        private static FileService instance { get; set; }

        private FileService()
        {
        }

        #endregion

        #region Admin

        public List<DocFile> GetFiles()
        {
            using (var context = new ASContext())
            {
                return context.DocFiles.ToList();
            }
        }

        public void SaveFile(DocFile file)
        {
            using (var context = new ASContext())
            {
                context.DocFiles.Add(file);
                context.SaveChanges();
            }
        }

        public void UpdateFile(DocFile file)
        {
            using (var context = new ASContext())
            {
                context.Entry(file).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteFile(int id)
        {
            using (var context = new ASContext())
            {
                var file = context.DocFiles.Find(id);
                context.DocFiles.Remove(file);
                context.SaveChanges();
            }
        }

        #endregion

        #region Web

        public DocFile GetFile(int fileId)
        {
            using (var context = new ASContext())
            {
                return context.DocFiles.Find(fileId);
            }
        }

        public DocFile GetFileByName(string fileName)
        {
            using (var context = new ASContext())
            {
                return context.DocFiles.Where(x => x.Name == fileName).FirstOrDefault();
            }
        }

        public List<DocFile> GetSpecFiles()
        {
            using (var context = new ASContext())
            {
                var type = 1; // Specification
                return context.DocFiles.Where(x => x.DocType == type).ToList();
            }
        }

        public List<DocFile> GetManualFiles()
        {
            using (var context = new ASContext())
            {
                var type = 2; // Manuals
                return context.DocFiles.Where(x => x.DocType == type).ToList();
            }
        }

        #endregion
    }
}
