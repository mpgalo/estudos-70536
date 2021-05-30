using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;

namespace CustomSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream file = new FileStream(@"c:\teste.txt",FileMode.Create))
            {
                ShoppingCartItem item = new ShoppingCartItem(1,20,10);
                BinaryFormatter formatter = new BinaryFormatter();
                
                formatter.Serialize(file, item);

            }
        }
    }
    [Serializable]
    class ShoppingCartItem : ISerializable
    {
        public Int32 productId;
        public decimal price;
        public Int32 quantity;
        [NonSerialized]
        public decimal total;
        // The standard, non-serialization constructor 
        public ShoppingCartItem(int _productID, decimal _price, int _quantity)
        {
            productId = _productID;
            price = _price;
            quantity = _quantity;
            total = price * quantity;
        }
        // The following constructor is for deserialization 
        protected ShoppingCartItem(SerializationInfo info, StreamingContext context)
        {
            productId = info.GetInt32("Product ID");
            price = info.GetDecimal("Price");
            quantity = info.GetInt32("Quantity");
            total = price * quantity;
        }
        // The following method is called during serialization 
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Product ID", productId);
            info.AddValue("Price", price);
            info.AddValue("Quantity", quantity);
        }

        public override string ToString() { return productId + ": " + price + " x " + quantity + " = " + total; }
    }
}
