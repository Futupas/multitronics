using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Multitronics.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //
        public ActionResult SomeProduct()
        {
            ViewBag.id = RouteData.Values["id"].ToString();
            return View();
        }
        // just product's info
        [HttpGet]
        public ActionResult SomeProductData()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Server=mssql3.gear.host;Database=multitronics;User Id=multitronics;Password=Jl8bl98_?E2o;";
            SqlCommand command = new SqlCommand(String.Format("SELECT * FROM [dbo].[Product] WHERE [WebName]='{0}';", RouteData.Values["id"]), conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            string retdata = "";
            if (!reader.HasRows)
            {
                retdata = "<h3 style='color: #ff0000;'>Такого товара нету.</h3>";
            }
            else
            {
                //while (reader.Read())
                if (reader.Read())
                {
                    string pr = String.Format("<h3>{0}</h3><p>{1}</p><p>Количество товаров: {2}</p><p>Вся информация берется из базы данных.</p>",
                        reader["Name"], reader["Description"], reader["Count"]);
                    retdata = pr;
                }
            }
            
            conn.Close();
            conn.Dispose();

            return Content(retdata);
        }
        //
        public ActionResult Product()
        {
            return Redirect(Url.Action("Products", "Home"));
        }
        //
        public ActionResult Products()
        {
            return View();
        }
    }
}
