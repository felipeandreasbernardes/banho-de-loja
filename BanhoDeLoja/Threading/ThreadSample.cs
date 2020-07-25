using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

//https://docs.microsoft.com/pt-br/dotnet/api/system.threading.thread?view=netcore-3.1

namespace BanhoDeLoja.Threading
{
    public class ThreadSample
    {
        public static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                // Yield the rest of the time slice.
                Thread.Sleep(0);
            }
        }
        public static void Run()
        {
            Console.WriteLine("Main thread: Start a second thread.");
            // The constructor for the Thread class requires a ThreadStart
            // delegate that represents the method to be executed on the
            // thread.  C# simplifies the creation of this delegate.
            Thread t = new Thread(new ThreadStart(ThreadProc));

            // Start ThreadProc.  Note that on a uniprocessor, the new
            // thread does not get any processor time until the main thread
            // is preempted or yields.  Uncomment the Thread.Sleep that
            // follows t.Start() to see the difference.
            t.Start();
            //Thread.Sleep(0);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }

            Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
            t.Join();
            Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");
            Console.ReadLine();
        }
    }
}
