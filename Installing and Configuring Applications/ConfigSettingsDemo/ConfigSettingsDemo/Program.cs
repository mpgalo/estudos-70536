using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Collections;
using System.Configuration;

namespace ConfigSettingsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            NameValueCollection AllAppSettings = ConfigurationManager.AppSettings;
            Console.WriteLine(AllAppSettings["Foo"]);
            Console.WriteLine(AllAppSettings[0]);
            WriteSettings();
            Console.ReadLine();
        }

        private static void WriteSettings()
        {
            try
            {
                CustomSection customSection;
                // Get the current configuration file.
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.Sections["LabSection1"] == null)
                {
                    customSection = new CustomSection();
                    customSection.FirstName = "TesteNome";
                    customSection.LastName = "TesteSegundoNome";
                    config.Sections.Add("LabSection1", customSection);
                    customSection.SectionInformation.ForceSave = true;                   
                    config.Save(ConfigurationSaveMode.Full);
                }
                else
                {
                    customSection = config.Sections["LabSection1"] as CustomSection;
                    Console.WriteLine(customSection.FirstName);
                    Console.WriteLine(customSection.LastName);
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.ToString());
            }            
        }
    }

    public class CustomSection : ConfigurationSection
    {
        [ConfigurationProperty("LastName", IsRequired = false,DefaultValue = "NotGiven")]
        public String LastName
        {
            get { return (String)base["LastName"]; }
            set { base["LastName"] = value; }
        }

        [ConfigurationProperty("FirstName", IsRequired = false, DefaultValue ="NotGiven")]
        public String FirstName
        {
            get { return (String)base["FirstName"]; }
            set { base["FirstName"] = value; }
        }
    }

    public class CustomSectionHandler : IConfigurationSectionHandler
    {

        #region IConfigurationSectionHandler Members

        object IConfigurationSectionHandler.Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
