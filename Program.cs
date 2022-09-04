using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemBSolution
{
    class Program
    {
        private const string inputErrorMessage = "Input contains of up to 150 hiking trips" + "\n" + 
                                                 "Each trip is given as a line in the input." + "\n" +
                                                 "The line startrs with 1 <= n <= 20, the number of items they need to split." + "\n" +
                                                 "Then follows the weight of each item. The weights are all in the range of [100,600] grams." + "\n" +
                                                 "End of input is indicated by a line containing a single 0." + "\n" +
                                                 "Please try again";

            static void Main(string[] args)
            {

                var lines = new Queue<List<int>>();

                // Reading input lines and collecting data into queue 

                while (true)
                {
                    try
                    {
                        string inputLine = Console.ReadLine();

                        if (inputLine?.Equals("0") ?? true)
                            break;

                        var weightOfOachItem = inputLine.Split()
                                                        .Skip(1)
                                                        .Select(x => int.Parse(x))
                                                        .ToList();

                        lines.Enqueue(weightOfOachItem);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine(e.Message);
                        Console.WriteLine();
                        Console.WriteLine(inputErrorMessage);
                    }
                }

                // Handling each line until queue becomes empty
                while (lines.Any())
                {
                    List<int> objectsWeightList = lines.Dequeue();
                    // why hashSet ? : duplicates are ignored and elements lookup complexity is O(1) 
                    var allPossibleSums = GetSums(objectsWeightList).ToHashSet();

                    var divisor = 2d;
                    var totalItemsWeight = objectsWeightList.Sum();
                    var kattisBagWeight = 0;
                    var properWeightbalanse = (int)Math.Ceiling(totalItemsWeight / divisor);

                    while (true)
                    {
                        // Checking if all possible sums of weights contains proper weight value 
                        bool isPerfectWeightBalanse = allPossibleSums.Contains(properWeightbalanse);
                        if (isPerfectWeightBalanse == true)
                        {
                            kattisBagWeight = properWeightbalanse;
                            break;
                        }
                        // if not then increasing proper weight value and moving to the next iteration
                        properWeightbalanse++;
                    }

                    int kittensBagWeight = totalItemsWeight - kattisBagWeight;

                    string result = $"{kattisBagWeight} {kittensBagWeight}";
                    Console.WriteLine(result);
                }
            }

        // This method i have borrowed from stack overflow community to find all possible sums 
        public static IEnumerable<int> GetSums(List<int> list)
                {
                      return from m in Enumerable.Range(0, 1 << list.Count)
                             select
                                (from i in Enumerable.Range(0, list.Count)
                                 where (m & (1 << i)) != 0
                                 select list[i]).Sum();
                }
    }
}
