using System;
using System.Threading;

class Program
{
    // Shared variable to demonstrate race condition
    static int counter = 0;
    static object lockObject = new object(); // Lock object to prevent race conditions

    static void Main()
    {
        Console.WriteLine("Starting Thread Pool Example with Increment and Decrement Tasks");

        // ThreadPool example - queue multiple tasks to increment and decrement counter
        ThreadPool.SetMaxThreads(50, 50);
        ThreadPool.QueueUserWorkItem(IncrementCounter);
        ThreadPool.QueueUserWorkItem(DecrementCounter);
        ThreadPool.QueueUserWorkItem(IncrementCounter);
        ThreadPool.QueueUserWorkItem(DecrementCounter);

        // Wait for a moment to see race condition effect
        Thread.Sleep(500); // Note: this is for demo purposes, not ideal in real applications

        Console.WriteLine($"Final counter value after Thread Pool (may vary due to race condition): {counter}");
    }

    // Method to increment the counter in ThreadPool
    static void IncrementCounter(object state)
    {
        // WITH LOCK (No race condition)
        
            for (int i = 0; i < 1000000; i++)
            {
                lock (lockObject)
                {
                    counter++;
                }
            }
            Thread.Sleep(1);
        
    }

    static void DecrementCounter(object state)
    {
        // WITH LOCK (No race condition)
        
            for (int i = 0; i < 1000000; i++)
            {
                lock (lockObject)
                {
                counter--;
                }
            }
            Thread.Sleep(1);
        
    }
}