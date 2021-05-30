using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml.Serialization;
using System.IO;

namespace SerializarDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            //this.SerializeDataSet(@"c:\teste.txt");
            Util.SerializeDataSet(@"C:\teste.txt");
            
        }


        
    }

    class Util
    {
        public static void SerializeDataSet(string filename)
        {
            XmlSerializer ser = new XmlSerializer(typeof(DataSet));
            // Creates a DataSet; adds a table, column, and ten rows.
            DataSet ds = new DataSet("myDataSet");
            DataTable t = new DataTable("table1");
            DataColumn c = new DataColumn("thing");
            t.Columns.Add(c);
            ds.Tables.Add(t);
            DataRow r;
            for (int i = 0; i < 10; i++)
            {
                r = t.NewRow();
                r[0] = "Thing " + i;
                t.Rows.Add(r);
            }
            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, ds);
            //Pode-se também utilizar o ds.WriteXml
            writer.Close();
        }
    }
}
