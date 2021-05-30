using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionStringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoConnectionStringHandler.GetAllConnectionStrings();
            DemoConnectionStringHandler.GetSpecificConnectionStrings(RetrievalType.ByName, "AdventureWorksString");
            DemoConnectionStringHandler.GetSpecificConnectionStrings(RetrievalType.ByName, "MarsEnabledSqlServer2005String");
            DemoConnectionStringHandler.GetSpecificConnectionStrings(RetrievalType.ByProviderType, "System.Data.SqlClient");
            Console.ReadLine();
        }
    }
}
