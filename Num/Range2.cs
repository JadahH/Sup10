using System.Collections;
using System.Collections.Generic;

namespace Num;


public class Range2
{

static void Main()
        {
            List<Range> quarters = new List<Range>();
            FloatNumberIterator floatIterator = new FloatNumberIterator();
            IEnumerator<double> enumerator = floatIterator.GetEnumerator();

            Console.WriteLine(" Welcome ");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("  P - Pick a quarter");
                Console.WriteLine("  Q - Quit");
                Console.Write("Your choice: ");
                string input = Console.ReadLine().Trim().ToUpper();

        
        if (input == "Q")
                {
                    Console.WriteLine("Applicatin Over, Have a good day!");
                    break;
                }
                else if (input == "P")
                {
                    try
                    {
                        if (!enumerator.MoveNext())
                        {
                            Console.WriteLine("No more numbers available.");
                            break;
                        }
                    }

                }
            }


        }

}

    