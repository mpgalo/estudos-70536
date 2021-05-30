using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

using System.Text;

namespace BasicSerializationSampleSoapFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create file to save the data to
            FileStream fs = new FileStream("SerializedDate.Data", FileMode.Create);
            // Create a BinaryFormatter object to perform the serialization
            SoapFormatter sf = new SoapFormatter();
            // Use the BinaryFormatter object to serialize the data to the file
            sf.Serialize(fs, System.DateTime.Now);
            // Close the file
            fs.Close();            

            // Open file to read the data from
            fs = new FileStream("SerializedDate.Data", FileMode.Open);
            // Create a BinaryFormatter object to perform the deserialization
            sf = new SoapFormatter();
            // Create the object to store the deserialized data
            DateTime previousTime = new DateTime();
            // Use the BinaryFormatter object to deserialize the data from the file
            previousTime = (DateTime)sf.Deserialize(fs);
            // Close the file
            fs.Close();
            // Display the deserialized time
            Console.WriteLine("Day: " + previousTime.DayOfWeek + ", _Time: " + previousTime.TimeOfDay.ToString());
        }
    }
}
