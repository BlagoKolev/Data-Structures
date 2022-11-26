using Problem02.DoublyLinkedList;
using System;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var doubleList = new DoublyLinkedList<int>();
            var arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var item in arr)
            {
                doubleList.AddLast(item);
                Console.WriteLine(doubleList.GetLast());
            }
            for (int i = 0; i < arr.Length+1; i++)
            {
                var a = doubleList.RemoveLast();
                Console.WriteLine(a);
            }
        }
    }
}
