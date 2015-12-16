using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetThread
{
    class Program
    
    {
        static object flag = new Object();
        static int test;
        static void Main(string[] args)
        {


       /*     Thread myThread = new Thread((message) => {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(message);
                }
            });*/

                Thread myThread1 = new Thread((param) =>
                {
                    for (int j = 0; j < 50; j++)
                    {
                        Interlocked.Increment(ref test);
                        Console.WriteLine("le thread {0} vaut {1}", param, test);
                    }

                }

                );

            Thread myThread2 = new Thread((param) =>
            {
                for (int j = 0; j < 50; j++)
                {
                        Interlocked.Increment(ref test);
                        Console.WriteLine("le thread {0} vaut {1}", param, test);
                }
            }

              );

            Thread myThread3 = new Thread((param) =>
            {
                for (int j = 0; j < 50; j++)
                {
                        Interlocked.Increment(ref test);
                        Console.WriteLine("le thread {0} vaut {1}", param, test);
                }
            }

              );

            Thread myThread4 = new Thread((param) =>
            {
                    for (int j = 0; j < 50; j++)
                    {
                          Interlocked.Increment(ref test);
                          Console.WriteLine("le thread {0} vaut {1}", param, test);
                    }
            });
            while (true)
            {
                Thread myThread5 = new Thread((param) =>
                {
                    while (true)
                    {
                        Interlocked.Increment(ref test);
                        Console.WriteLine("le thread {0} vaut {1}", param, test);
                    }
                       
                    
                });
                myThread5.Start();
            }
            //myThread1.Start(1);
            //myThread2.Start(2);
            //myThread3.Start(3);
            //myThread4.Start(4);
            
            Console.ReadLine();
        }
    }

    class ClPara
    {
        public static void MethodePara()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("super star");
            }
        }
    }

}
