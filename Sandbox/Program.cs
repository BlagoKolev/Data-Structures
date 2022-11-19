// See https://aka.ms/new-console-template for more information
using Problem01.List;
using System;




var list = new Problem04.SinglyLinkedList.SinglyLinkedList<int>();
//list.AddFirst(1);
//list.AddFirst(2);
//list.AddFirst(3);
//list.AddFirst(4);


var expected = new int[] { 3, 8, 1, 3, 8, 1, 6, 5, 7, 2, 9, 4, 3, 8, 1, 6, 5, 7, 2, 9, 4 };

foreach (var num in expected)
{
    list.AddLast(num);

}
list.RemoveLast();
list.RemoveLast();
list.RemoveLast();

Console.WriteLine(18);
Console.WriteLine(list.Count);








