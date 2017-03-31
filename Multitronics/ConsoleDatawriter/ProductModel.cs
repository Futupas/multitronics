using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDatawriter
{
    class ProductModel
    {
        //public int? ID = null;
        public int CategoryID = 0;
        public string Name = "";
        public string WebName = "";
        public string Description = "";
        public string PhotoSrc = "";
        public int Price = 0;
        public int Count = 0;
        public string Specif = "";
    }
    class ShortProductModel
    {
        public int ID = 0;
        public string CategoryName = "";
        public string Name = "";
        public string WebName = "";
        public int Price = 0;
        public int count = 0;
    }
}
