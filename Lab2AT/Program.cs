using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LambdaMicrobenchmarking;

namespace Lab2AT
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            MyArrayList<int> myarraylist = new MyArrayList<int>();
            MyLinkedList<int> mylist = new MyLinkedList<int>();
            MyDoublyLinkedList<int> mydoublylist = new MyDoublyLinkedList<int>();

            SetRand(myarraylist);
            SetRand(mylist); 
            SetRand(mydoublylist);

            Func<double> sumLinq1 = () => mylist.Summ();
            Func<double> sumLinq2 = () => mydoublylist.Summ();
            Func<double> sumLinqArr = () => myarraylist.Summ();

            Console.WriteLine("SummTest");
            Script.Of("LinkedList", sumLinq1)
            .Of("DoublyLinkedList", sumLinq2)
            .Of("ArrayList", sumLinqArr)
            .WithHead()
            .RunAll();




            /* string[] test = new string[n];
             for (int i = 0; i < n;i++) {
                 test[i] = Test(mylist) + "\n" + Test(mydoublylist) + "\n" + Test(myarraylist) ;
             }

             foreach(string s in test) {
                 Console.WriteLine("-------");
                 Console.WriteLine(s);
             }
             */
            Console.ReadLine();
        }

        static string Test (ICollectionComparable<int> list) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
                SetRand(list);
            stopwatch.Stop();
                string res = " Setting time: " + stopwatch.Elapsed;
            stopwatch.Reset();
            stopwatch.Start();
                FindRand(list);
            stopwatch.Stop();
            res += " Finding time: " + stopwatch.Elapsed+" "+ list.ToString();
                return res;
        }

        static void SetRand(ICollectionComparable<int> list)
        {
            Random rand = new Random();
            for (uint i = 0; i < 333; i++)
            {
                list.AddBack(rand.Next());
                list.AddFront(rand.Next());
                list.Insert(rand.Next(), i+1);
            }
        }

        static void FindRand(ICollectionComparable<int> list)
        {
            Random rand = new Random();
            for (uint i = 0; i < 1000; i++)
            {
                list.GetIndex(rand.Next());
            }
        }
    }
}
