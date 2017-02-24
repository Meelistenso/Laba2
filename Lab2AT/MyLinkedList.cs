using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2AT
{
    class MyLinkedList<T> : ICollectionComparable<T>
    {
        private Node<T> First;
        private Node<T> Current;
        private Node<T> Last;
        private uint size;

        public MyLinkedList()
        {
            size = 0;
            First = Current = Last = null;
        }

        public void Insert(T item, uint index)
        {
            if (index < 1 || index > size)
            {
                throw new InvalidOperationException();
            }
            else if (index == 1)
            {
                AddFront(item);
            }
            else if (index == size)
            {
                AddBack(item);
            }
            else
            {
                uint count = 1;
                Current = First;
                while (Current != null && count+1 != index)
                {
                    Current = Current.Next;
                    count++;
                }
                Node<T> newNode = new Node<T>(item);
                Node<T> tempNode = Current.Next;
                Current.Next = newNode;
                newNode.Next = tempNode;
            }
        }

        public void AddFront(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (First == null)
            {
                First = Last = newNode;
            }
            else
            {
                newNode.Next = First;
                First = newNode;
            }
            Count++;
        }

        public void RemoveFront()
        {
            if (First == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Node<T> temp = First;
                First = First.Next;
                Count--;
            }
        }

        public void AddBack(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (First == null)
            {
                First = Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                Last = newNode;
            }
            Count++;
        }

        public void RemoveBack()
        {
            if (Last == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Current = First;
                while (Current.Next.Next != null)
                {
                    Current = Current.Next;
                }

                Current.Next = null;
                Last = Current;
                Count--;

            }
        }

        public uint Count
        {
            get { return size; }
            set { size = value; }
        }

        public double Summ()
        {
            Current = First;
            double res = 0;
            uint count = 1;
            while (Current != null)
            {
                res += Convert.ToDouble(Current.Value);
                count++;
                Current = Current.Next;
            }
            return res;
        }
        public void Display()
        {
            if (First == null)
            {
                Console.WriteLine("Doubly Linked List is empty");
                return;
            }
            Current = First;
            uint count = 1;
            while (Current != null)
            {
                Console.WriteLine("Element " + count.ToString() + " : " + Current.Value.ToString());
                count++;
                Current = Current.Next;
            }
        }

        public void Remove(uint index)
        {
            if (index < 1 || index > size)
            {
                throw new InvalidOperationException();
            }
            else if (index == 1)
            {
                RemoveFront();
            }
            else if (index == size)
            {
                RemoveBack();
            }
            else
            {
                uint count = 1;
                Current = First;
                while (Current != null && count != index-1)
                {
                    Current = Current.Next;
                    count++;
                }

                Current.Next = Current.Next.Next;
                Count--;
            }
        }

        public uint? GetIndex(T item)
        {
            uint index = 1;
            Current = First;
            while (Current.Next != null)
            {
                Current = Current.Next;
                index++;

                if (Current.Value.Equals(item)) return index;
            }
            return null;

        }

    }
}
