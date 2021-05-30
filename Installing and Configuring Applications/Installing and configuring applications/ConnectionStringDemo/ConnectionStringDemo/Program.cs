using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionStringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoConnectionStringHandler.GetSpecificConnectionStrings(RetrievalType.ByName, "AdventureWorksString");
            DemoConnectionStringHandler.GetSpecificConnectionStrings(RetrievalType.ByName, "MarsEnabledSqlServer2005String");
            DemoConnectionStringHandler.GetSpecificConnectionStrings(RetrievalType.ByProviderType, "System.Data.SqlClient");
            Console.WriteLine();
            Console.WriteLine();
            DemoConnectionStringHandler.GetAllConnectionStrings();
            Console.ReadLine();
        }
    }
}
