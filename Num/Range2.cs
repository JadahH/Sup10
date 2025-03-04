using System.Collections;
using System.Collections.Generic;

namespace Num;


public class Range2
{


     /// <summary>
    /// The main entry point of the application.
    /// Initializes quarter ranges and a floating number iterator, and then displays an interactive menu
    /// to the user to pick a quarter or quit the application.
    /// </summary>

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


                        double newValue = enumerator.Current;
                        Range newRange = new Range(newValue);
                        quarters.Add(newRange);

                      
                        Console.WriteLine("\nPresent Quarters:");
                        var groupedQuarters = quarters.GroupBy(q => q.GetHashCode())
                                                      .OrderBy(g => g.Key);




                    }

                }
            }


        }


}

    