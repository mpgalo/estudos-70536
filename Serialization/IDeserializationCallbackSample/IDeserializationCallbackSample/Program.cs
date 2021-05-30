using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;

namespace IDeserializationCallbackSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create file to save the data to
            FileStream fs = new FileStream("SerializedCustomObject.Data", FileMode.Create);
            // Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();
            ShoppingCartItem shoppingItem = new ShoppingCartItem(1, 25, 50);
            bf.Serialize(fs, shoppingItem);
            fs.Close();

            fs = new FileStream("SerializedCustomObject.Data", FileMode.Open);
            // Create a BinaryFormatter object to perform the deserialization
            bf = new BinaryFormatter();
            // Create the object to store the deserialized data            
            // Use the BinaryFormatter object to deserialize the data from the file
            ShoppingCartItem previousItem = (ShoppingCartItem)bf.Deserialize(fs);
            // Close the file
            fs.Close();

            Console.WriteLine(previousItem.ToString());
        }
    }

    //Define que a classe será serializavel
    [Serializable]
    class ShoppingCartItem : IDeserializationCallback
    {
        public int productId;
        public decimal price;
        public int quantity;

        //Define que este atributo não será serializado e portanto seu valor emitido apos desserializacao
        [NonSerialized]
        public decimal total;
        public ShoppingCartItem(int _productID, decimal _price, int _quantity)
        {
            productId = _productID;
            price = _price;
            quantity = _quantity;
            total = price * quantity;
        }

        public override string ToString()
        {
            StringBuilder strItem = new StringBuilder();
            strItem.AppendFormat("Produto : {0}\n", productId);
            strItem.AppendFormat("Preço : {0}\n", price);
            strItem.AppendFormat("Quantidade: {0}\n", quantity);
            strItem.AppendFormat("Total: {0}", total);

            return strItem.ToString();
        }

        /// <summary>
        /// So témos acesso ao total pois implemetamos IDeserializationCallback,
        /// pois como o atributo está definido como nao serializavel seu valor não iria ser serializado,
        /// consequentemente nao poderia ser recuperado posteriormente
        /// </summary>
        /// <param name="sender"></param>
        void IDeserializationCallback.OnDeserialization(Object sender)
        {
            // After deserialization, calculate the total
            total = price * quantity;
        }
    }
}
