using BanhoDeLoja.Collections;
using BanhoDeLoja.Delegate;
using BanhoDeLoja.SocketTcp;
using BanhoDeLoja.Tasking;
using BanhoDeLoja.Threading;
using System;
using System.Threading.Tasks;
using static BanhoDeLoja.Delegate.DelegateSample;

namespace BanhoDeLoja
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1-Delegagte");
            Console.WriteLine("2-Lock");
            Console.WriteLine("3-SocketTCP");
            Console.WriteLine("4-Task");
            Console.WriteLine("5-Threads");
            Console.WriteLine("5-Collections");

            var key = Console.ReadLine();

            var opt = int.TryParse(key, out int result) ? result : 0;

            Console.WriteLine("\n");

            switch (opt)
            {
                case 1:
                    // Creates one delegate for each method. For the instance method, an
                    // instance (mySC) must be supplied. For the static method, use the
                    // class name.
                    mySampleClass mySC = new mySampleClass();
                    myMethodDelegate myD1 = new myMethodDelegate(mySC.myStringMethod);
                    myMethodDelegate myD2 = new myMethodDelegate(mySampleClass.mySignMethod);

                    // Invokes the delegates.
                    Console.WriteLine("{0} is {1}; use the sign \"{2}\".", 5, myD1(5), myD2(5));
                    Console.WriteLine("{0} is {1}; use the sign \"{2}\".", -3, myD1(-3), myD2(-3));
                    Console.WriteLine("{0} is {1}; use the sign \"{2}\".", 0, myD1(0), myD2(0));
                    break;
                case 2:
                    Task.Run(async () => await AccountTest.MainSample()).Wait();
                    break;
                case 3:
                    SynchronousSocketClient.StartClient();
                    break;
                case 4:
                    TaskSample.MainSample();
                    break;
                case 5:
                    ThreadSample.Run();
                    break;
                case 6:
                    Console.WriteLine("Collections");
                    Console.WriteLine("1-ConcurrentDictionary");

                    Task.Run(async () => await TestDictionary.RunSample()).Wait();

                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}
