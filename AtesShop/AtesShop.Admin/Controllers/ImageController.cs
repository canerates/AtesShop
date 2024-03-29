﻿using AtesShop.Admin.ViewModels;
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
    //[Authorize(Roles = "Admin")]
    public class ImageController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ImageTable(string search)
        {
            ImageTableViewModel model = new ImageTableViewModel();
            var images = ImageService.Instance.GetImages();

            if (!string.IsNullOrEmpty(search))
            {
                images = images.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            model.Images = images;

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Upload(ImageFileViewModel model)
        {

            if (model.File.ContentLength > 0)
            {
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(model.File.InputStream))
                {
                    imageData = binaryReader.ReadBytes(model.File.ContentLength);
                }
                var image = new Image();
                image.Name = model.Name;
                image.Data = imageData;
                image.ContentType = model.File.ContentType;

                ImageService.Instance.SaveImage(image);
            }
            return RedirectToAction("ImageTable");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var image = ImageService.Instance.GetImage(id);
            EditImageViewModel model = new EditImageViewModel();

            model.Id = image.Id;
            model.Name = image.Name;
            model.ContentType = image.ContentType;
            model.Data = image.Data;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(ImageFileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentImage = ImageService.Instance.GetImage(model.Id);


                if (model.File != null && model.File.ContentLength > 0 )
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(model.File.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(model.File.ContentLength);
                    }
                    
                    currentImage.Data = imageData;
                    currentImage.ContentType = model.File.ContentType;
                }
                currentImage.Name = model.Name;

                ImageService.Instance.UpdateImage(currentImage);
            }
            
            return RedirectToAction("ImageTable");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            ImageService.Instance.DeleteImage(id);
            return RedirectToAction("ImageTable");
        }
    }
}