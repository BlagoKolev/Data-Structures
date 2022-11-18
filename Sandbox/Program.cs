// See https://aka.ms/new-console-template for more information
using Problem01.List;




var queue = new Problem03.Queue.Queue<int>();
var defaultQueue = new System.Collections.Generic.Queue<int>();
queue.Enqueue(1);   
defaultQueue.Enqueue(1);

queue.Enqueue(2);
defaultQueue.Enqueue(2);

queue.Enqueue(3);
defaultQueue.Enqueue(3);

queue.Enqueue(4);
defaultQueue.Enqueue(4);

queue.Enqueue(5);
defaultQueue.Enqueue(5);


for (int i = 0; i < 5; i++)
{
    Console.WriteLine(queue.Dequeue());
    Console.WriteLine(defaultQueue.Dequeue());
}




