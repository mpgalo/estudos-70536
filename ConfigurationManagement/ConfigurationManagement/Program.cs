using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Collections;
using System.Configuration;
using System.Xml;

namespace ConfigurationManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            NameValueCollection AllAppSettings = ConfigurationManager.AppSettings;
            Console.WriteLine(AllAppSettings["Foo"]);
            Console.WriteLine(AllAppSettings[0]);
            //Console.ReadLine();
            WriteSettings();
            WriteSettings2();
            ValuesHandler vals = ConfigurationManager.GetSection("MyFirstSection/DemoValues") as ValuesHandler;
            Console.WriteLine(vals.GetValueFromKey("111"));
            Console.ReadLine();
        }

        private static void WriteSettings()
        {
            try
            {
                LabSectionHandler LabSection;

                // Get the current configuration file.

                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.Sections["LabSection"] == null)
                {
                    LabSection = new LabSectionHandler();
                    LabSection.Status = "OK";
                    LabSection.SectionInformation.ForceSave = true;
                    config.Sections.Add("LabSection", LabSection);
                    config.Save(ConfigurationSaveMode.Full);
                    //ConfigurationManager.RefreshSection("LabSection");
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void WriteSettings2()
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Add an Application Setting.
            config.AppSettings.Settings.Add("ModificationDate", DateTime.Now.ToLongTimeString() + " ");

            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

    public class LabSectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("status", IsRequired = true)]
        public string Status
        {
            get { return (string)base["status"]; }
            set { base["status"] = value; }
        }
    }

    public class ValuesHandler
    {
        private Hashtable customValue;

        public ValuesHandler(Hashtable configValues)
        {
            this.customValue = configValues;
        }

        public String GetValueFromKey(String key)
        {
            return this.customValue[key] as String;
        }
    }

    public class MyHandler : IConfigurationSectionHandler
    {
        object IConfigurationSectionHandler.Create(
        object parent, object configContext, XmlNode section)
        {
            Hashtable ConfigValues = new Hashtable();
            XmlElement Root = section as XmlElement;
            String TempValue = string.Empty;
            foreach (XmlNode ParentNode in Root.ChildNodes)
            {
                foreach (XmlNode ChildNode in ParentNode.ChildNodes)
                {
                    if (ChildNode.Name == "Identifier")
                    {
                        TempValue = ChildNode.InnerText;
                    }
                    if (ChildNode.Name == "SettingValue")
                    {
                        ConfigValues[TempValue] = ChildNode.InnerText;
                    }
                }
            }
            ValuesHandler MyHandler = new ValuesHandler(ConfigValues);
            return MyHandler;
        }
    }
}




