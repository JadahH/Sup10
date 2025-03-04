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


                        /// <summary>
                        /// Processes the current value from an enumerator by creating a new <see cref="Range"/> instance,
                        /// adding it to a collection, and then grouping the collection based on each Range's hash code.
                        /// </summary>
                        /// <param name="enumerator">
                        /// An enumerator that provides double values. The current value will be used to create a new Range.
                        /// </param>
                        /// <param name="quarters">
                        /// A list of <see cref="Range"/> objects where the newly created Range will be added.
                        /// </param>


                        double newValue = enumerator.Current;
                        Range newRange = new Range(newValue);
                        quarters.Add(newRange);

                      
                        Console.WriteLine("\nPresent Quarters:");
                        var groupedQuarters = quarters.GroupBy(q => q.GetHashCode())
                                                      .OrderBy(g => g.Key);




                            /// <summary>
                            /// The main entry point of the application.
                            /// It allows the user to add quarter values, processes them into buckets, and handles any errors that occur.
                            /// </summary>

                        foreach (var group in groupedQuarters)
                        {
                            double lowerBound = group.Key * 0.25;
                            double upperBound = lowerBound + 0.25;
                            Console.WriteLine($"Bucket [{lowerBound:F2} - {upperBound:F2}): {string.Join(", ", group.Select(q => q.Value.ToString("F2")))}");
                        }
                    }
                    catch (BadSequenceException ex)
                    {
                        Console.WriteLine($"\nERROR: {ex.Message}");
                        Console.WriteLine("invalid sequence.");
                        running = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nError: {ex.Message}");
                        running = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter 'P' to add a quarter or 'Q' to quit.");
                }
            }

                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadKey();
                }

                    

}

            

    