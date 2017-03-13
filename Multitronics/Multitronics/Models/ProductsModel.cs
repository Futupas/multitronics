using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multitronics.Models
{
    public class SomeProductDataModel
    {
        public string Name = "";
        public string Description = "";
        public int Price = 0;
        public int Count = 0;
        public string PhotoSrc = "";
        public string Specifications = "";
    }
    public class SomeProductCommentModel
    {
        public string AuthorName = "";
        public string Text = "";
    }
    public class ProductDataModel
    {
        public string Name = "";
        public string Description = "";
        public int Price = 0;
        public string Href = "";
        public string PhotoSrc = "";
    }
    public class CategoryModel
    {
        public int Id = 0;
        public string Name = "";
    }
}