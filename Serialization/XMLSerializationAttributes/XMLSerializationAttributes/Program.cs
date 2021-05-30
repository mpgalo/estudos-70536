using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace XMLSerializationAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"c:\SerializedDate.XML", FileMode.Create);
            // Create an XmlSerializer object to perform the serialization
            XmlSerializer xs = new XmlSerializer(typeof(ShoppingCartItem));
            // Use the XmlSerializer object to serialize the data to the file
            ShoppingCartItem item = new ShoppingCartItem();
            item.productId = 1;
            item.price = 20;
            item.quantity = 10;
            item.total = 200;
            xs.Serialize(fs, item);
            // Close the file
            fs.Close();

            //Deserealizando objeto em stream

            fs = new FileStream(@"c:\SerializedDate.XML", FileMode.Open);

            // Use the XmlSerializer object to deserialize the data from the file
            ShoppingCartItem previousItem = (ShoppingCartItem)xs.Deserialize(fs);
            // Close the file
            fs.Close();
            // Display the deserialized time
            Console.WriteLine("ProductID: " + previousItem.productId + ",Price: " + previousItem.price + " , Quantity: " + previousItem.quantity
            + ", Total: " + previousItem.total);
            
        }
    }

    //Define o nome do no raiz
    [XmlRoot("CartItem")]
    public class ShoppingCartItem
    {
        [XmlAttribute]
        public Int32 productId;
        public decimal price;
        public Int32 quantity;
        [XmlIgnore]
        public decimal total;
        public ShoppingCartItem()
        {
        }      
        
    }
}
