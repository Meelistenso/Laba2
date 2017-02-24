using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2AT
{
    public class DoublyNode<T>
    {
        private object _Data;
        private DoublyNode<T> _Next;
        private DoublyNode<T> _Prev;
        public object Value
        {
            get { return _Data; }
            set { _Data = value; }
        }
        public DoublyNode(object Data)
        {
            this._Data = Data;
        }
        public DoublyNode<T> Next
        {
            get { return this._Next; }
            set { this._Next = value; }
        }
        public DoublyNode<T> Prev
        {
            get { return this._Prev; }
            set { this._Prev = value; }
        }
    }
}

