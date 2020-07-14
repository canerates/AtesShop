using AtesShop.Admin.ViewModels;
using AtesShop.Entities;
using AtesShop.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtesShop.Admin.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FileTable(string search)
        {
            FileTableViewModel model = new FileTableViewModel(); 
            var files = FileService.Instance.GetFiles();

            if (!string.IsNullOrEmpty(search))
            {
                files = files.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            model.Files = files;

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Upload(FileViewModel model)
        {
            if (model.DocFile.ContentLength > 0)
            {
                byte[] fileData = null;

                using (var binaryReader = new BinaryReader(model.DocFile.InputStream))
                {
                    fileData = binaryReader.ReadBytes(model.DocFile.ContentLength);
                }

                var file = new DocFile();
                file.Name = model.Name;
                file.Data = fileData;
                file.ContentType = model.DocFile.ContentType;

                FileService.Instance.SaveFile(file);
            }
            return RedirectToAction("FileTable");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var file = FileService.Instance.GetFile(id);
            EditFileViewModel model = new EditFileViewModel();

            model.Id = file.Id;
            model.Name = file.Name;
            model.ContentType = file.ContentType;
            model.Data = file.Data;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(FileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentFile = FileService.Instance.GetFile(model.Id);

                if (model.DocFile != null && model.DocFile.ContentLength > 0)
                {
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(model.DocFile.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(model.DocFile.ContentLength);
                    }
                    currentFile.Data = fileData;
                    currentFile.ContentType = model.DocFile.ContentType;
                }
                currentFile.Name = model.Name;

                FileService.Instance.UpdateFile(currentFile);
            }

            return RedirectToAction("FileTable");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            FileService.Instance.DeleteFile(id);
            return RedirectToAction("FileTable");
        }
    }
}