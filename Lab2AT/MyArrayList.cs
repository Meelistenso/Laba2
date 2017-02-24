using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2AT
{
    public class MyArrayList<T> : ICollectionComparable<T>
    {
        private static uint initSize = 16;
        private static uint cutRate = 4;
        private Object[] array = new Object[initSize];
        private uint size = 0;

        public void AddBack(T item)
        {
            if (Count == array.Length - 1)
                resize(array.Length * 2); 
            array[Count++] = item;
        }

        public void AddFront(T item)
        {
            if (Count == array.Length - 1)
                resizeFvrd(array.Length * 2);
            array[0] = item;
        }

        public void Insert(T item, uint index)
        {
            if (Count == array.Length - 1)
                resizeMid(array.Length * 2, index);
            array[index++] = item;
        }

        public uint Count
        {
            get { return size; }
            set { size = value; }
        }

        public void Remove(uint index)
        {
            for (uint i = index; i < Count; i++)
                array[i] = array[i + 1];
            array[Count] = null;
            Count--;
            if (array.Length > initSize && Count < array.Length / cutRate)
                resize(array.Length / 2); 
        }

        public void RemoveFront() {
            Remove(0);
        }

        public void RemoveBack() {
            array[Count] = null;
            Count--;
            if (array.Length > initSize && Count < array.Length / cutRate)
                resize(array.Length / 2);
        }

        public double Summ()
        {
            double res = 0;
            for (uint i = 0; i < Count; i++)
            {
                res += Convert.ToDouble(array[i]);
            }
            return res;
        }

        public uint? GetIndex(T item)
        {
            for (uint i=0; i<Count;i++)
            {
                if (array[i].Equals(item))
                {
                    return i;
                }
            }
            return null;
        }

        public void Display()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine("Element " + i.ToString() + " : " + array[i].ToString());
            }
        }

        private void resize(int newLength)
        {
            Object[] newArray = new Object[newLength];
            System.Array.Copy(array, 0, newArray, 0, Count);
            array = newArray;
        }
        private void resizeFvrd(int newLength) {
            Object[] newArray = new Object[newLength];
            System.Array.Copy(array, 0, newArray, 1, Count);
            array = newArray;
        }
        private void resizeMid(int newLength,uint index) {
            Object[] newArray = new Object[newLength];
            System.Array.Copy(array, newArray, index);
            System.Array.Copy(array, index, newArray, index+newLength-array.Length, Count-index);
            array = newArray;
        }
    }
}
