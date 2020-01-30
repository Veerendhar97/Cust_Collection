using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cust_Collection
{
    public class Node
    {
        public int Data;
        public Node Next;
        public Node(int Value)
        {
            Data = Value;
            Next = null;
        }
    }
    public class Operation:IEnumerable

    {
        public int Count = 0;
        Node head = null;
        #region Add()
        public void Add(int Value)
        {
            Node node = new Node(Value);
            if (head == null)
                head = node;
            else
            {
                Node Current = head;
                while (Current.Next != null)
                {
                    Current = Current.Next;
               }
                Current.Next = node;
            }
            Count++;
         
        }
        #endregion Add()

        #region Delete()
        public void Delete(int Value)
        {
            Node Current = head;
            if (head == null)
            {
                Console.WriteLine("No such Element");
                return;
            }
            else if  (head.Data==Value)
            {
                head = head.Next;
                
            }
            Node Previous = null;                     
            while(Current!=null)
            {
                if(Current.Data==Value)
                {
                    Previous.Next = Current.Next;
                    Current = Current.Next;
                    Count--;
                        
                }
                else
                {
                    Previous =Current;
                    Current = Current.Next;
                   
                }
            }         
        }
        #endregion Delete()

        #region Truncate()
        public void Truncate()
        {
            head = null;
        }
        #endregion Truncate()

        #region Contain()
        public bool Contain(int Value)
        {
            Node Current = head;
            while (Current != null)
            {
                if (Value.Equals(Current.Data))
                   return true;
                else
                    Current = Current.Next;
            }
            return false;
        }
        #endregion Contain()

        #region DeleteFrom()
        public void DeleteFrom(int Index)
        {
            Node Current = head, Previous = null;
            if (Index >= Count)
            {
                Console.WriteLine("Trying to acees out of bound location");
                return;
            }
            else if (Index == 0)
            {
                head = head.Next;
                return;
            }
            else
            {
                for (int i = 0; i < Index; i++)
                {
                    if (Current != null)
                    {
                        Previous = Current;
                        Current = Current.Next;
                        Count--;
                    }
                }
                if (Current == null)
                {
                    Console.WriteLine("No such Element");
                    return;
                }
                if (Current != null)
                {
                    Previous.Next = Current.Next;
                }
            }

        }
        #endregion DeleteFrom()

        #region Dispaly()
        public void Display()
        {
            Node Current = head;
            while (Current != null)
            {
                Console.WriteLine(Current.Data);
                Current = Current.Next;
            }
        }
        #endregion Dispaly()

        #region Sort()
        public void Sort()
        {
            if (Count > 1 && head!= null)
            {
                for (int i = 0; i < Count-1; i++)
                {
                    Node Current = head;
                    Node next = head.Next;
                    for (int j = 0; j < Count - 1; j++)
                    {
                        if (Current.Data > next.Data)
                        {
                            int temp = Current.Data;
                            Current.Data = next.Data;
                            next.Data = temp;
                        }
                        Current = next;
                        next = next.Next;
                    }
                }
            }

        }
        #endregion Sort()

        #region Enumerator

        public IEnumerator GetEnumerator()
        {
            return new Enumarator(head);
        }
        class Enumarator:IEnumerator
        {
            private Node cur, Head;

            public Enumarator(Node head)
            {
                this.cur = null;

                this.Head = head;
            }
            public object Current
            { 
                get
                {
                        return cur.Data;                 
                }              
             }
            public bool MoveNext()
            {
                if (Head != null)
                {
                    if (cur == null)
                    {
                        cur = Head;
                        return true;
                    }
                    if (this.cur.Next == null)
                    {
                        return false;
                    }
                    else
                    {
                        this.cur = this.cur.Next;
                    }
                    return true;
                }
                return false;
            }
            


            public void Reset() 
            {
                cur = Head;
            }
        }
        #endregion Enumerator
    }
}
