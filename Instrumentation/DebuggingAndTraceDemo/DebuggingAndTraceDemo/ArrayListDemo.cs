using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace DebuggingAndTraceDemo
{
    [DebuggerTypeProxy(typeof(MyDemoObject))]
    class ArrayListDemo : ArrayList
    {
        public String ShouldIgnore = "The Debugger won't see this";
        internal class MyDemoObject
        {
            public String ShouldIgnore = "The Debugger WILL see this";
            private ArrayList _myList;
            public MyDemoObject(ArrayList myList)
            {
                this._myList = myList;
            }
            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public Object[] AllValues
            {
                get
                {
                    Object[] o = new Object[this._myList.Count]; for (Int32 x = 0; x < this._myList.Count; x++)
                    {
                        o[x] = this._myList[x];
                    }
                    return o;
                }
            }
        }
    }
}

