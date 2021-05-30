using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class TreeEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private Tree<T> currentData = null;
        private T currentItem = default(T); //faz com que a variavel seja inicializado 
        // de acordo com seu tipo, exemplo int = 0 string = null bool = false
        private Queue<T> enumData = null;

        public TreeEnumerator(Tree<T> data)
        {
            this.currentData = data;
        }

        private void populate(Queue<T> enumQueue, Tree<T> tree)
        {
            if (tree.LeftTree != null)
            {
                populate(enumQueue, tree.LeftTree);
            }

            enumQueue.Enqueue(tree.NodeData);

            if (tree.RightTree != null)
            {
                populate(enumQueue, tree.RightTree);
            }
        }

        #region IEnumerator<T> Members

        T IEnumerator<T>.Current
        {
            get
            {
                if (this.enumData == null)
                    throw new InvalidOperationException("Use MoveNext before calling current");

                return this.currentItem;
            }
        }

        #endregion

            #region IDisposable Members

            void IDisposable.Dispose()
            {
                //throw new Exception("The method or operation is not implemented.");
            }

            #endregion

            #region IEnumerator Members

            object System.Collections.IEnumerator.Current
            {
                get { throw new Exception("The method or operation is not implemented."); }
            }

            bool System.Collections.IEnumerator.MoveNext()
            {
                if (this.enumData == null)
                {
                    this.enumData = new Queue<T>();
                    populate(this.enumData, this.currentData);
                }

                if (this.enumData.Count > 0)
                {
                    this.currentItem = this.enumData.Dequeue();
                    return true;
                }

                return false;
            }

            void System.Collections.IEnumerator.Reset()
            {
                throw new Exception("The method or operation is not implemented.");
            }

            #endregion
        }
    }
