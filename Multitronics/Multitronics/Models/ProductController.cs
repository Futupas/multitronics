using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multitronics.Models
{
    public class ProductController : Controller
    {
        private void SomeProductData(string WebName)
        {
            SomeProductDataModel product = new SomeProductDataModel();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Server=mssql3.gear.host;Database=multitronics;User Id=multitronics;Password=Jl8bl98_?E2o;";
                try
                {
                    cn.Open();
                    string strSQL = "Select * From Product Where WebName = '" + WebName + "'";
                    SqlCommand myCommand = new SqlCommand(strSQL, cn);
                    SqlDataReader dr = myCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        product.Name = dr[0].ToString();
                        product.Description= dr[1].ToString() ;
                        product.Price = Int32.Parse(dr[2].ToString());
                        product.Count= Int32.Parse(dr[3].ToString());
                        product.PhotoSrc= dr[4].ToString();
                        product.Specifications= dr[5].ToString();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
        }

    }
}
