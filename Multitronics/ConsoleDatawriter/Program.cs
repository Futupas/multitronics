using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Data.SqlClient;

namespace ConsoleDatawriter
{
    class Program
    {
        //const string RightRegisterKey = "right";
        //const string TempRegisterKey = "bad";
        //static int Registered = 0;

        static XmlDocument SettingsFile;
        static string ConnectionString;
        //static string RegisterKey;
        static void Main(string[] args)
        {
            try
            {
                Design();
                Initialize();
                //RegisterProduct();
                //if (Registered == 1 || Registered == 2)
                //{
                    while (true)
                    {
                        Work();
                    }
                //}
            }
            //catch (RegisterException ex)
            //{

            //}
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
        //static void RegisterProduct()
        //{
        //    if (RegisterKey == RightRegisterKey)
        //    {
        //        Registered = 2;
        //    }
        //    else if (RegisterKey == TempRegisterKey)
        //    {
        //        Registered = 1;
        //    }
        //    else
        //    {
        //        Registered = 0;
        //    }
        //}
        static void Initialize()
        {
            string SettingsFilePath = (Environment.GetEnvironmentVariable("APPDATA")+@"\MultitronicsDataSetter\");
            string SettinsFileName = "data.xml";

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


                //start_regkey:
                //try
                //{
                //    RegisterKey = xRoot["registerKey"].InnerText;
                //    if (RegisterKey != RightRegisterKey && RegisterKey != TempRegisterKey)
                //    {
                //        RegisterKey = GetUserRegKey();
                //        try
                //        {
                //            xRoot["registerKey"].AppendChild();
                //        }
                //        catch (NullReferenceException ex)
                //        {
                //            XmlElement connStr = SettingsFile.CreateElement("registerKey");
                //            connStr.InnerText = RegisterKey;
                //            xRoot.AppendChild(connStr);
                //            SettingsFile.Save(SettingsFilePath + SettinsFileName);
                //        }
                //    }
                //}
                //catch (NullReferenceException ex)
                //{
                //    XmlElement connStr = SettingsFile.CreateElement("registerKey");
                //    connStr.InnerText = GetUserRegKey();
                //    xRoot.AppendChild(connStr);
                //    SettingsFile.Save(SettingsFilePath + SettinsFileName);
                //    goto start_regkey;
                //}
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

            Console.WriteLine("Вас приветствует MultitronicsDataSetter");
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
        static string GetUserRegKey()
        {
            Console.Write("Enter your registration key: ");
            return Console.ReadLine();
        }

        static void Work()
        {
            string input = Console.ReadLine();
            Console.WriteLine(input);
            //Console.WriteLine(Registered);
            Console.WriteLine();
            Console.ReadLine();
        }
    }

    //public class RegisterException : Exception
    //{
    //    public RegisterException()
    //    {

    //    }
    //}
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
}
