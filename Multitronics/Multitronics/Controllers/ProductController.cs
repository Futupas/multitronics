using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Multitronics.Models;
using System.Net;
using System.Net.Mail;

namespace Multitronics.Controllers
{
    public class ProductController : Controller
    {
        //
        //public ActionResult SomeProduct()
        //{
        //    ViewBag.id = RouteData.Values["id"].ToString();
        //    return View();
        //}
        // just product's info
        //[HttpGet]
        //public ActionResult SomeProductData()
        //{
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = @"Server=mssql3.gear.host;Database=multitronics;User Id=multitronics;Password=Jl8bl98_?E2o;";
        //    SqlCommand command = new SqlCommand(String.Format("SELECT * FROM [dbo].[Product] WHERE [WebName]='{0}';", RouteData.Values["id"]), conn);
        //    conn.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    string retdata = "";
        //    if (!reader.HasRows)
        //    {
        //        retdata = "<h3 style='color: #ff0000;'>Такого товара нету.</h3>";
        //    }
        //    else
        //    {
        //        //while (reader.Read())
        //        if (reader.Read())
        //        {
        //            string pr = String.Format("<h3>{0}</h3><p>{1}</p><p>Количество товаров: {2}</p><p>Вся информация берется из базы данных.</p>",
        //                reader["Name"], reader["Description"], reader["Count"]);
        //            retdata = pr;
        //        }
        //    }

        //    conn.Close();
        //    conn.Dispose();

        //    return Content(retdata);
        //}

        // Пустая страничка конкретного продукта
        public ActionResult SomeProduct()
        {
            return View();
        }
        // Информация о конкретном продукте
        [HttpGet]
        public ActionResult SomeProductData()
        {
            string WebName = RouteData.Values["id"].ToString();
            //string WebName = HttpUtility.UrlDecode(RouteData.Values["id"].ToString());
            //return Json(new { Encode = HttpUtility.UrlEncode(RouteData.Values["id"].ToString()), Decode = HttpUtility.UrlDecode(RouteData.Values["id"].ToString()), Original = RouteData.Values["id"].ToString() }, JsonRequestBehavior.AllowGet);

            SomeProductDataModel product = new SomeProductDataModel();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Server=mssql3.gear.host;Database=multitronics;User Id=multitronics;Password=Jl8bl98_?E2o;";
                try
                {
                    cn.Open();
                    string strSQL = "Select * From [Product] Where [WebName] = N'" + WebName + "'";
                    SqlCommand myCommand = new SqlCommand(strSQL, cn);
                    SqlDataReader dr = myCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        product.Name = dr["Name"].ToString();
                        product.Description = dr["Description"].ToString();
                        product.Price = Int32.Parse(dr["Price"].ToString());
                        product.Count = Int32.Parse(dr["Count"].ToString());
                        product.PhotoSrc = dr["Photo"].ToString();
                        product.Specifications = dr["Specif"].ToString();
                    }

                    return Json(product, JsonRequestBehavior.AllowGet);
                }
                catch (SqlException ex)
                {
                    return Json(new { Error = true, Message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
        // Отзывы о конкретном продукте
        [HttpGet]
        public ActionResult SomeProductComments()
        {
            string WebName = ViewBag.id = RouteData.Values["id"].ToString();
            List<SomeProductCommentModel> productcomments = new List<SomeProductCommentModel>();
            productcomments.Add(new SomeProductCommentModel { AuthorName = "Vas", Text = "lllol" });
            return Json(productcomments, JsonRequestBehavior.AllowGet);
        }
        // ~/Product
        public ActionResult Product()
        {
            return Redirect(Url.Action("Products", "Home"));
        }
        // Пустая страничка всех продуктов
        public ActionResult Products()
        {
            return View();
        }
        // Список категорий
        public ActionResult GetCategories()
        {
            List<CategoryModel> categories = new List<CategoryModel>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Server=mssql3.gear.host;Database=multitronics;User Id=multitronics;Password=Jl8bl98_?E2o;";
            SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Category];", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                categories.Add(new CategoryModel {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"]
                });
            }

            conn.Close();
            conn.Dispose();

            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        // Все продукты конкретной категории
        public ActionResult ProductsData(string Category)
        {
            List<ProductDataModel> products = new List<ProductDataModel>();
            int CategoryID = Int32.Parse(Category);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Server=mssql3.gear.host;Database=multitronics;User Id=multitronics;Password=Jl8bl98_?E2o;";
            SqlCommand command = new SqlCommand(String.Format("SELECT * FROM [dbo].[Product] WHERE [CategoryID]={0};", CategoryID), conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new ProductDataModel
                {
                    Name = (string)reader["Name"],
                    Description = (string)reader["Description"],
                    Href = (string)reader["WebName"],
                    PhotoSrc = (string)reader["Photo"],
                    Price = (int)reader["Price"],
               });
            }

            conn.Close();
            conn.Dispose();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult BySomeProduct()
        {
            string ProductWebName = ViewBag.id = RouteData.Values["id"].ToString();

            MailAddress from = new MailAddress("multitronics@mail.ua", "Multitronics Server");
            //MailAddress to = new MailAddress("futupas@gmail.com");
            MailMessage m = new MailMessage();
            m.From = from;
            m.To.Add(new MailAddress("futupas@gmail.com"));
            m.To.Add(new MailAddress("vgorkyn@mail.ru"));
            m.Subject = "Multitronics product";
            m.Body = String.Format("<h1>Кто-то хочет купить ваш продукт</h1><p>Кто-то нажал на кнопку <span style='background-color: #0f0;'>\"Купить\"</span>. <a href='http://multitronics.gear.host/Product/{0}'>Ссылка на тот продукт</a></p><p>Кстати, не забудь про просьбу</p>", ProductWebName);
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            smtp.Credentials = new NetworkCredential("multitronics@mail.ua", "MultiEmail091_j6");
            smtp.EnableSsl = true;
            smtp.Send(m);

            return Json(new { success = true });
        }
    }
}
