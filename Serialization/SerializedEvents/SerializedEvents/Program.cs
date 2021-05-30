using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializedEvents
{
    
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream file = new FileStream(@"c:\teste.txt", FileMode.Create))
            {
                ShoppingCartItem item = new ShoppingCartItem(1, 20, 10);
                BinaryFormatter formatter = new BinaryFormatter();
                //formatter.Context = new StreamingContext(StreamingContextStates.CrossProcess);
                formatter.Serialize(file, item);       

                

            }
        }

        [Serializable]
        class ShoppingCartItem
        {
            public Int32 productId;
            public decimal price;
            public Int32 quantity;
            public decimal total;

            public ShoppingCartItem(int productId, int price, int quantity)
            {
                this.productId = productId;
                this.price = price;
                this.quantity = quantity;
            }

            [OnSerializing]
            void CalculateTotal(StreamingContext sc)
            {               
                total = price * quantity;
            }

            [OnDeserialized]
            void CheckTotal(StreamingContext sc)
            {
                if (total == 0) { CalculateTotal(sc); }
            }
        }
        
    }
}
