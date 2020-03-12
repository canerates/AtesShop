using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtesShop.Admin.ViewModels
{
    public class ImageFileViewModel
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public HttpPostedFileBase File { set; get; }
    }

    public class EditImageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}