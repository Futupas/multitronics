using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ConsoleDatawriter
{
    class Program
    {
        static XmlDocument SettingsFile;
        static void Main(string[] args)
        {
            Initialize("");
            //Console.WriteLine(Environment.GetEnvironmentVariable("APPDATA")+"\\");
            Console.ReadLine();
        }
        static void Initialize(string str)
        {
            string SettingsFilePath = (Environment.GetEnvironmentVariable("APPDATA")+@"\MultitronicsDataSetter\");
            string SettinsFileName = "data.xml";

            if (!Directory.Exists(SettingsFilePath))
            {
                Directory.CreateDirectory(SettingsFilePath);
            }
            if (!File.Exists(SettingsFilePath + SettinsFileName))
            {
                File.Create(SettingsFilePath + SettinsFileName);
            }

            start:
            try
            {
                SettingsFile = new XmlDocument();
                SettingsFile.Load(SettingsFilePath + SettinsFileName);
                XmlElement xRoot = SettingsFile.DocumentElement;
                string connectionString = xRoot["connectionString"].InnerText;
                Console.WriteLine(connectionString);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NullReferenceException");
                SettingsFile = new XmlDocument();
                SettingsFile.Load(SettingsFilePath + SettinsFileName);
                XmlElement xRoot = SettingsFile.DocumentElement;
                XmlElement connStr = SettingsFile.CreateElement("connectionString");
                connStr.InnerText = "cccccccccccccccccccccccc";
                xRoot.AppendChild(connStr);
                SettingsFile.Save(SettingsFilePath + SettinsFileName);
                goto start;
            }
            catch (XmlException ex)
            {
                Console.WriteLine("XmlException");
                File.WriteAllText((SettingsFilePath + SettinsFileName), "<?xml version='1.0' encoding='utf-8' ?><root></root>", Encoding.UTF8);
                goto start;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());
            }

            //Console.WriteLine(SettingsFilePath + SettinsFileName);
        }
    }
}

/*
 
 <?xml version="1.0" encoding="utf-8" ?>
<root>
  <connectionString>Conn str ddfdfdfdfdfdfdfd</connectionString>
  <registerKey>dddddddddddddd</registerKey>
</root>
 
 */
