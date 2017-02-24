using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2AT
{ 
    class MyDoublyLinkedList<T> : ICollectionComparable<T>
    {
        private DoublyNode<T> First;
        private DoublyNode<T> Current;
        private DoublyNode<T> Last;
        private uint size;

        public MyDoublyLinkedList()
        {
            size = 0;
            First = Current = Last = null;
        }

        public uint Count
        {
            get { return size; }
            set { size = value; }
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
                while (Current != null && count != index)
                {
                    Current = Current.Next;
                    count++;
                }
                DoublyNode<T> newDoublyNode = new DoublyNode<T>(item); 
                Current.Prev.Next = newDoublyNode;
                newDoublyNode.Prev = Current.Prev;
                Current.Prev = newDoublyNode;
                newDoublyNode.Next = Current;
                Count++;
            }
        }

        public void AddFront(T item)
        {
            DoublyNode<T> newDoublyNode = new DoublyNode<T>(item);

            if (First == null)
            {
                First = Last = newDoublyNode;
            }
            else
            {
                newDoublyNode.Next = First;
                First = newDoublyNode; 
                newDoublyNode.Next.Prev = First;
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
                DoublyNode<T> temp = First;
                if (First.Next != null)
                {
                    First.Next.Prev = null;
                }
                First = First.Next;
                Count--;
            }
        }

        public void AddBack(T item)
        {
            DoublyNode<T> newDoublyNode = new DoublyNode<T>(item);

            if (First == null)
            {
                First = Last = newDoublyNode;
            }
            else
            {
                Last.Next = newDoublyNode;
                newDoublyNode.Prev = Last;
                Last = newDoublyNode;
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
                DoublyNode<T> temp = Last;
                if (Last.Prev != null)
                {
                    Last.Prev.Next = null;
                }
                Last = Last.Prev;
                Count--;
            }
        }


        public double Summ() {
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
                while (Current != null && count != index)
                {
                    Current = Current.Next;
                    count++;
                }
                Current.Prev.Next = Current.Next;
                Current.Next.Prev = Current.Prev;
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
