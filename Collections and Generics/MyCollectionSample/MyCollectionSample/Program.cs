using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MyCollectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // C#
            MyList<int> myIntList = new MyList<int>();
            myIntList.Add(1);
            myIntList.Add(2);
            // myIntList.Add("4"); does not compile!
            MyList<String> myStringList = new MyList<String>();
            myStringList.Add("1");
            myStringList.Add("2");
            //myStringList.Add(2); // does not compile!

            foreach (string item in myStringList)
            {
                Console.WriteLine(item);
            }
            
        }
    }
    public class MyList<T> : ICollection, IEnumerable
    {
        private ArrayList _innerList = new ArrayList();
        public void Add(T val)
        {            
            _innerList.Add(val);
        }
        public T this[int index]
        {
            get
            {
                return (T)_innerList[index];
            }
        }
        #region ICollection Members
        // ...
        #endregion
        #region IEnumerable Members
        // ...
        #endregion 
    
        #region ICollection Members

        void ICollection.CopyTo(Array array, int index)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int ICollection.Count
        {
            get { return _innerList.Count; }
        }

        bool ICollection.IsSynchronized
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        object ICollection.SyncRoot
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerator enumerator = _innerList.GetEnumerator();
            return enumerator;
        }

        #endregion
    }
}
