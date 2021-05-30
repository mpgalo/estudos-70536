using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace XMLSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            //Serializando objeto em Stream
            FileStream fs = new FileStream(@"c:\SerializedDate.XML", FileMode.Create);
            // Create an XmlSerializer object to perform the serialization
            XmlSerializer xs = new XmlSerializer(typeof(DateTime));
            // Use the XmlSerializer object to serialize the data to the file
            xs.Serialize(fs, System.DateTime.Now);
            // Close the file
            fs.Close();

            //Deserealizando objeto em stream

            fs = new FileStream(@"c:\SerializedDate.XML", FileMode.Open);

            // Use the XmlSerializer object to deserialize the data from the file
            DateTime previousTime = (DateTime)xs.Deserialize(fs);
            // Close the file
            fs.Close();
            // Display the deserialized time
            Console.WriteLine("Day: " + previousTime.DayOfWeek + ",Time: " + previousTime.TimeOfDay.ToString());
        }
    }
}
