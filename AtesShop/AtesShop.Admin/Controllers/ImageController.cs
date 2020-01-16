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
    public class ImageController : Controller
    {
        ImageService imageService = new ImageService();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ImageTable(string search)
        {
            var images = imageService.GetImages();

            if (!string.IsNullOrEmpty(search))
            {
                images = images.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            

            return PartialView(images);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase imageFile)
        {
            if(imageFile.ContentLength > 0)
            {
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(imageFile.InputStream))
                {
                    imageData = binaryReader.ReadBytes(imageFile.ContentLength);
                }
                var image = new Image();
                image.Name = imageFile.FileName;
                image.Data = imageData;
                image.ContentType = imageFile.ContentType;

                imageService.SaveImage(image);
            }
            return RedirectToAction("ImageTable");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var image = imageService.GetImage(id);
            return PartialView(image);
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase imageFile)
        {
            imageService.UpdateImage(image);
            return RedirectToAction("ImageTable");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            imageService.DeleteImage(id);
            return RedirectToAction("ImageTable");
        }
    }
}