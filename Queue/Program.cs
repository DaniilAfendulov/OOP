using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> testStack = new Stack<string>();
            Queue<string> testQueue = new Queue<string>();
            Data<string>[] dataArray = new Data<string>[]
            {
                new Data<string>("1"),
                new Data<string>("2"),
                new Data<string>("3"),
                new Data<string>("4"),
                new Data<string>("5"),
                new Data<string>("6"),
                new Data<string>("7")
            };
            Data<string>[] dataArray2 = new Data<string>[]
            {
                new Data<string>("1"),
                new Data<string>("2"),
                new Data<string>("3"),
                new Data<string>("4"),
                new Data<string>("5"),
                new Data<string>("6"),
                new Data<string>("7")
            };

            foreach (Data<string> data in dataArray)
            {
                Stack<string>.Push(ref testStack.Head, data);
            }

            foreach (Data<string> data in dataArray2)
            {
                Queue<string>.Enqueue(ref testQueue.Head, ref testQueue.Tail, data);
            }



            Data<string> element;
            do
            {
                element = Stack<string>.Pop(ref testStack.Head);
                if (element != null) Console.WriteLine(element.data);
            } while (element != null);

            do
            {
                element = Queue<string>.Dequeue(ref testQueue.Head);
                if (element != null) Console.WriteLine(element.data);
            } while (element != null);
            Console.ReadLine();

        }


        public class Data<T>
        {
            public T data;
            public Data<T> next = null;
            public Data(T data)
            {
                this.data = data;
            }
        }

        public class Stack<T>
        {
            public Data<T> Head;
            public static void Push(ref Data<T> head, Data<T> element)
            {
                element.next = head;
                head = element;
            }
            public static Data<T> Pop(ref Data<T> head)
            {
                if (head != null)
                {
                    Data<T> element = head;
                    head = head.next;
                    return element;
                }
                else return null;
            }
        }



        public class Queue<T>
        {
            public Data<T> Head;
            public Data<T> Tail;

            static public void Enqueue(ref Data<T> head, ref Data<T> tail, Data<T> element)
            {
                if (head == null)
                {
                    head = element;
                    tail = element;
                }
                else
                {
                    tail.next = element;
                    tail = element;
                }
            }
            static public Data<T> Dequeue(ref Data<T> head)
            {
                if (head != null)
                {
                    Data<T> element = head;
                    head = head.next;
                    return element;
                }
                else return head;
            }
        }

    }
}
