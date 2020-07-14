using AtesShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtesShop.Admin.ViewModels
{
    public class FileViewModel
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public HttpPostedFileBase DocFile { set; get; }
    }

    public class EditFileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }

    public class FileTableViewModel
    {
        public List<DocFile> Files { get; set; }
    }
    
}