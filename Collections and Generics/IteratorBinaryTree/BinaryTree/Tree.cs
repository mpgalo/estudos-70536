using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class Tree<T>:IEnumerable<T> where T : IComparable<T>
    {
        private T data;
        private Tree<T> left;
        private Tree<T> right;

        public Tree(T nodeValue)
        {
            this.data = nodeValue;
            this.left = null;
            this.right = null;
        }

        public T NodeData
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public Tree<T> LeftTree
        {
            get { return this.left; }
            set { this.left = value; }
        }

        public Tree<T> RightTree
        {
            get { return this.right; }
            set { this.right = value; }
        }

        public void Insert(T newItem)
        {
            T currentNodeValue = this.NodeData;
            if (currentNodeValue.CompareTo(newItem) > 0)
            {
                if (this.LeftTree == null)
                {
                    this.LeftTree = new Tree<T>(newItem);
                }
                else
                {
                    this.LeftTree.Insert(newItem);
                }
            }
            else
            {
                if (this.RightTree == null)
                {
                    this.RightTree = new Tree<T>(newItem);
                }
                else
                {
                    this.RightTree.Insert(newItem);
                }
            }
        }

        public void WalkTree()
        {
            if (this.LeftTree != null)
            {
                this.LeftTree.WalkTree();
            }

            Console.WriteLine(this.NodeData.ToString());

            if (this.RightTree != null)
            {
                this.RightTree.WalkTree();
            }
        }

        #region IEnumerable<T> Members

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            if (this.LeftTree != null)
            {
               foreach(T item in this.LeftTree)
               {
                   yield return item;
               }
            }

            yield return this.NodeData;

            if (this.RightTree != null)
            {
                foreach (T item in this.RightTree)
                {
                    yield return item;
                }
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
