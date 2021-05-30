using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListSample
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<String> links = new LinkedList<string>();
            LinkedListNode<string> first = links.AddLast("First");
            LinkedListNode<string> last = links.AddFirst("Last");
            LinkedListNode<string> second = links.AddBefore(last, "Second");
            LinkedList<string> links2 = second.List;
            Console.WriteLine(second.Next.Value);
            links.AddAfter(second, "Third");
            foreach (string s in links)
            {
                Console.WriteLine(s);
            }

            
        }
    }
}
