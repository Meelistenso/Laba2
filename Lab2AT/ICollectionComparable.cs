using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2AT
{
    public interface ICollectionComparable<T>
    {
        void AddFront(T item);
        void AddBack(T item);
        void Insert(T item, uint index);
        void RemoveFront();
        void RemoveBack();
        void Remove(uint index);
        double Summ();
        uint? GetIndex(T item);
        void Display();
     }

}
