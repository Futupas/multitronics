using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using ConsoleDatawriter;

namespace ConsoleDatawriter
{
    class Program
    {
        const string CommandSepator = "----- ----- ----- ----- ----\n";
        static readonly string SettingsFilePath = (Environment.GetEnvironmentVariable("APPDATA") + @"\MultitronicsDataSetter\");
        const string SettinsFileName = "data.xml";

        static XmlDocument SettingsFile;

        static string ConnectionString;
        static void Main(string[] args)
        {
            try
            {
                Design();
                Initialize();

                while (true)
                {
                    Work();
                }
            }
            catch (MyException ex)
            {
                Console.WriteLine(ex.Data);
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine("exception!  "+ex.Message);
                Console.ReadKey();
            }
        }
        static void Initialize()
        {

            if (!Directory.Exists(SettingsFilePath))
            {
                Directory.CreateDirectory(SettingsFilePath);
            }
            if (!File.Exists(SettingsFilePath + SettinsFileName))
            {
                File.Create(SettingsFilePath + SettinsFileName).Close();
            }

            start1:
            try
            {
                SettingsFile = new XmlDocument();
                SettingsFile.Load(SettingsFilePath + SettinsFileName);
                XmlElement xRoot = SettingsFile.DocumentElement;

                start_connstr:
                try
                {
                    ConnectionString = xRoot["connectionString"].InnerText;
                }
                catch (NullReferenceException ex)
                {
                    XmlElement connStr = SettingsFile.CreateElement("connectionString");
                    connStr.InnerText = GetUserConnStr();
                    xRoot.AppendChild(connStr);
                    SettingsFile.Save(SettingsFilePath + SettinsFileName);
                    goto start_connstr;
                }

            }
            catch (XmlException ex)
            {
                File.WriteAllText((SettingsFilePath + SettinsFileName), "<?xml version='1.0' encoding='utf-8' ?><root></root>", Encoding.UTF8);
                goto start1;
            }
            catch (Exception ex)
            {
                string data = "";
                data += (string.Format("Void: 'Initialize()';\n"));
                data += (string.Format("Target site: '{0}'\n", ex.TargetSite));
                data += (string.Format("Type: '{0}';\n", ex.GetType()));
                data += (string.Format("Message: '{0}';\n", ex.Message));
                data += (string.Format("Help link: '{0}';\n", ex.HelpLink));
                data += (string.Format("H result: '{0}';\n", ex.HResult));
                data += (string.Format("System info: неизвестная ошибка"));
                throw new MyException("Ошибка инициализации", data);
            }

            //Console.WriteLine("All ready!");
        }
        static void Design()
        {
            Console.Title = "MultitronicsDataSetter | Не забудь про просьбу!!!";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Вас приветствует MultitronicsDataSetter\n\n");
        }
        static string GetUserConnStr()
        {
            const string DefConnStr = "Csfasdfasfdsadfasdfds f sda f ads f";

            Console.WriteLine("Connection string is not found.");
            Console.WriteLine("Enter 'd' if you want to use default connection string");
            Console.WriteLine("Enter 'm' if you want to use manual connection string");
            string w = Console.ReadLine();
            switch (w.ToLowerInvariant())
            {
                case "m":
                    Console.Write("Your connection string: ");
                    string ncs = Console.ReadLine(); //new connection string
                    return ncs;
                    break;
                case "d": return DefConnStr; break;
                default: return DefConnStr; break;
            }
        }
        static void ChangeConnStr()
        {
            Console.WriteLine("Enter your connection string: ");
            string newconnstr = Console.ReadLine();
            SettingsFile.DocumentElement["connectionString"].InnerText = newconnstr;
            SettingsFile.Save(SettingsFilePath + SettinsFileName);
            ConnectionString = newconnstr;
            Console.WriteLine("Conection string was changed");
        }

        static void Work()
        {
            string input = Console.ReadLine().ToLowerInvariant();
            string[] inputs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Resize<string>(ref inputs, 5);
            if (inputs.Length < 5)
            {
                for (int i = 4; i >= inputs.Length; i++)
                {
                    inputs[i] = null;
                }
            }
            switch (inputs[0])
            {
                case "close": Environment.Exit(0); break;
                case "help":
                    switch (inputs[1])
	                {
                        case null:
                            Console.WriteLine(HelpStrings.HelpString);
                            Console.WriteLine(CommandSepator);
                            break;
                        case "t": 
                            Console.WriteLine(HelpStrings.Products);
                            Console.WriteLine(CommandSepator);
                            break;
                        case "c": 
                            Console.WriteLine(HelpStrings.Categories);
                            Console.WriteLine(CommandSepator);
                            break;
                        case "settings": 
                            Console.WriteLine(HelpStrings.Settings);
                            Console.WriteLine(CommandSepator);
                            break;
                        default:
                            Console.WriteLine("Unknown command!");
                            Console.WriteLine(CommandSepator);
                            break;
	                }
                    break;
                case "t": 
                    switch (inputs[1])
	                {
                        case null: Console.WriteLine(HelpStrings.Product_variants); break;
                        case "add":
                            var newproduct = new ProductModel();
                            Console.Write("Name           : "); newproduct.Name = Console.ReadLine();
                            Console.Write("Category       : "); newproduct.CategoryID = Int32.Parse(Console.ReadLine());
                            Console.Write("Link : /Product/ "); newproduct.WebName = Console.ReadLine();
                            Console.Write("Description    : "); newproduct.Description = Console.ReadLine();
                            Console.Write("Photo          : "); newproduct.PhotoSrc = Console.ReadLine();
                            Console.Write("Price          : "); newproduct.Price = Int32.Parse(Console.ReadLine());
                            Console.Write("Count          : "); newproduct.Count = Int32.Parse(Console.ReadLine());
                            Console.Write("Specifications : "); newproduct.Specif = Console.ReadLine();
                            Console.Write("Are you sure want to add this product? (y/n): ");
                            string readln1 = Console.ReadLine().ToLowerInvariant();

                            if (readln1 == "y")
                            {
                                using (var conn = new SqlConnection())
                                {
                                    conn.ConnectionString = ConnectionString;
                                    conn.Open();
                                    var command = new SqlCommand(
                                        String.Format("INSERT INTO [Product] ([CategoryID],[Name],[WebName],[Description],[Photo],[Price],[Count],[Specif]) VALUES ({0},N'{1}',N'{2}',N'{3}',N'{4}',{5},{6},N'{7}');",
                                        newproduct.CategoryID, newproduct.Name, newproduct.WebName, newproduct.Description, newproduct.PhotoSrc, newproduct.Price, newproduct.Count, newproduct.Specif), 
                                        conn);
                                    command.ExecuteReader();
                                }
                                Console.WriteLine("Your product was successfully added to database!");
                            }

                            Console.WriteLine(CommandSepator);
                            break;
                        case "rem":
                        case "del": 
                            Console.Write("Enter ID of product you want to delete: ");
                            int PrID = Int32.Parse(Console.ReadLine());
                            Console.Write("Are you sure want to delete this product? (y/n): ");
                            string readln2 = Console.ReadLine().ToLowerInvariant();

                            if (readln2 == "y")
                            {
                                using (var conn = new SqlConnection())
                                {
                                    conn.ConnectionString = ConnectionString;
                                    conn.Open();
                                    var command = new SqlCommand(
                                        String.Format("DELETE FROM [Product] WHERE [ID]={0};", PrID), conn);
                                    command.ExecuteReader();
                                }
                                Console.WriteLine("Your product was successfully deleted from database!");
                            }

                            Console.WriteLine(CommandSepator);
                            break;
                        case "get": 
                            switch (inputs[2])
	                        {
                                case "all":
                                    using (var conn = new SqlConnection())
                                    {
                                        conn.ConnectionString = ConnectionString;
                                        conn.Open();
                                        var command = new SqlCommand(
                                            String.Format("SELECT * FROM [Product]"),
                                            conn);
                                        SqlDataReader reader = command.ExecuteReader();
                                        Console.WriteLine("Products: ");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine("ID           : {0}", reader["ID"]);
                                            Console.WriteLine("Name         : {0}", reader["Name"]);
                                            Console.WriteLine("CategoryID   : {0}", reader["CategoryID"]);
                                            Console.WriteLine("Link: /Product/{0}", reader["WebName"]);
                                            Console.WriteLine("Description  : {0}", reader["Description"]);
                                            Console.WriteLine("Photo        : {0}", reader["Photo"]);
                                            Console.WriteLine("Count        : {0}", reader["Count"]);
                                            Console.WriteLine("Price        : {0}", reader["Price"]);
                                            Console.WriteLine("Specification: {0}", reader["Specif"]);
                                            Console.WriteLine();
                                        }
                                    }

                                    Console.WriteLine(CommandSepator);
                                    break;
                                case null:
                                    using (var conn = new SqlConnection())
                                    {
                                        conn.ConnectionString = ConnectionString;
                                        conn.Open();
                                        var command = new SqlCommand(
                                            String.Format("SELECT [Product].[ID], [Product].[Name], [Category].[Name] AS [CategoryName], [Product].[WebName], [Product].[Price], [Product].[Count] FROM [Product], [Category] WHERE [Product].[CategoryID]=[Category].[ID];"),
                                            conn);
                                        SqlDataReader reader = command.ExecuteReader();
                                        Console.WriteLine("Products: ");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine("ID           : {0}", reader["ID"]);
                                            Console.WriteLine("СategoryName : {0}", reader["Name"]);
                                            Console.WriteLine("CategoryID   : {0}", reader["CategoryName"]);
                                            Console.WriteLine("Link: /Product/{0}", reader["WebName"]);
                                            Console.WriteLine("Price        : {0}", reader["Price"]);
                                            Console.WriteLine("Count        : {0}", reader["Count"]);
                                            Console.WriteLine();
                                        }
                                    }

                                    Console.WriteLine(CommandSepator);
                                    break;
                                case "short":
                                    using (var conn = new SqlConnection())
                                    {
                                        conn.ConnectionString = ConnectionString;
                                        conn.Open();
                                        var command = new SqlCommand(
                                            String.Format("SELECT [ID],[Name] FROM [Product]"),
                                            conn);
                                        SqlDataReader reader = command.ExecuteReader();
                                        Console.WriteLine("Products: ");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine("{0}: {1}", reader["ID"], reader["Name"]);
                                        }
                                    }

                                    Console.WriteLine(CommandSepator);
                                    break;
                                default:
                                    Console.WriteLine("Unknown command!");
                                    Console.WriteLine(CommandSepator);
                                    break;
	                        }
                            break;
                        default:
                            Console.WriteLine("Unknown command!");
                            Console.WriteLine(CommandSepator);
                            break;
	                }
                    break;
                case "c":
                    switch (inputs[1])
                    {
                        case null: Console.WriteLine(HelpStrings.Categories_variants); break;
                        case "add":
                            dynamic newcategory = new
                            {

                            };
                            Console.WriteLine("add category");

                            Console.WriteLine(CommandSepator);
                            break;
                        case "rem": 
                            Console.WriteLine("remove category");
                            Console.WriteLine(CommandSepator);
                            break;
                        case "get": 
                            Console.WriteLine("get all category");
                            Console.WriteLine(CommandSepator);
                            break;
                        default:
                            Console.WriteLine("Unknown command!");
                            break;
                    }
                    break;
                case "settings":
                    switch (inputs[1])
                    {
                        case null: 
                            Console.WriteLine(HelpStrings.Settings_variants);
                            Console.WriteLine(CommandSepator);
                            break;
                        case "connstr": 
                            ChangeConnStr();
                            Console.WriteLine(CommandSepator);
                            break;
                        default:
                            Console.WriteLine("Unknown command!");
                            Console.WriteLine(CommandSepator);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Unknown command!");
                    Console.WriteLine(CommandSepator);
                    break;
            }
        }
    }

    public class MyException : Exception
    {
        public readonly string Data;
        public readonly string Message;
        public MyException(string message, string data = "")
        {
            this.Message = message;
            this.Data = data;
        }
    }


    public class HelpStrings
    {
        public const string HelpString = "Helo str";
        public const string Categories = "Helo str c";
        public const string Products = "Helo str p";
        public const string Settings = "Helo str s";

        public const string Product_variants = "P var";
        public const string Categories_variants = "C var";
        public const string Settings_variants = "S var";
    }
}
