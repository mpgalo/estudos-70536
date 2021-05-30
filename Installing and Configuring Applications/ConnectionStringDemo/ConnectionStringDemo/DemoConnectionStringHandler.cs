// C#
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.Odbc;
namespace ConnectionStringDemo
{
    public enum RetrievalType
    {
        ByName = 0,
        ByProviderType = 1
    }
    public class DemoConnectionStringHandler
    {
        private String _MyValue;
        public String MyValue
        {
            get { return this._MyValue; }
            set { this._MyValue = value; }
        }
        public static void GetSpecificConnectionStrings(RetrievalType type, String typeOrName)
        {
            if (typeOrName == string.Empty || typeOrName == null) { throw new ArgumentException("Name cannot be empty", "typeOrname"); }
            switch (type)
            {
                case RetrievalType.ByName:
                    ConnectionStringSettings MySettings = ConfigurationManager.ConnectionStrings[typeOrName];
                    Debug.Assert(MySettings != null, "The name does not appear to exist, verify it in the configuration file");
                    if (MySettings != null)
                    {
                        Console.WriteLine(MySettings.ConnectionString);
                    }
                    break;
                case RetrievalType.ByProviderType:
                    ConnectionStringSettingsCollection MyTypeSettings = ConfigurationManager.ConnectionStrings;
                    Debug.Assert(MyTypeSettings != null, "Type does not appear to be present.");
                    if (MyTypeSettings != null)
                    {
                        foreach (ConnectionStringSettings typeSettings in MyTypeSettings)
                        {
                            if (typeSettings.ProviderName == typeOrName)
                            {
                                SqlConnection MyConnection = new SqlConnection(typeSettings.ConnectionString);
                                Console.WriteLine("Connection String " + typeSettings.ConnectionString);
                            }
                        }
                    }
                    break;
            }
        }
        public static void GetAllConnectionStrings()
        {
            ConnectionStringSettingsCollection MySettings = ConfigurationManager.ConnectionStrings;
            Debug.Assert(MySettings != null); //Should fail if no values
            //are present
            if (MySettings != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (ConnectionStringSettings individualSettings in MySettings)
                {
                    sb.Append("Full Connection String: " + individualSettings.ConnectionString + "\r\n"); 
                    sb.Append("Provider Name: " + individualSettings.ProviderName + "\r\n"); 
                    sb.Append("Section Name: " + individualSettings.Name + "\r\n");
                } 
                Console.WriteLine(sb.ToString());
            }
        }
    }
}