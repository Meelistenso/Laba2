using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2AT
{
    public class Node<T>
    {
        private object _Data;
        private Node<T> _Next;
        public object Value
        {
            get { return _Data; }
            set { _Data = value; }
        }
        public Node(object Data)
        {
            this._Data = Data;
        }
        public Node<T> Next
        {
            get { return this._Next; }
            set { this._Next = value; }
        }
    }
}
