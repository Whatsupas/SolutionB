using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemBSolution
{
    class Program
    {
            static void Main(string[] args)
            {

                var lines = new Queue<List<int>>();

                // Getting input lines and collecting to Queue 

                while (true)
                {
                    string inputLine = Console.ReadLine();
                    if (inputLine != "0")
                    {
                        var stringArray = inputLine.Split(" ").Skip(1).ToList();
                        var intList = stringArray.Select(x => int.Parse(x)).ToList();
                        lines.Enqueue(intList);
                    }
                    else
                    {
                        break;
                    }

                }

                // handling each line until queue becomes empty
                while (lines.Any())
                {

                    List<int> objectsWeightList = lines.Dequeue();
                // why hashSet ? : duplicates are ignored and elements lookup complexity O(1) 
                var allPossibleSums = GetSums(objectsWeightList).ToList().ToHashSet();

                    double divisor = 2d;
                    int totalItemsWeight = objectsWeightList.Sum();
                    int kattisBagWeight = 0;
                    int properWeightbalanse = (int)Math.Ceiling(totalItemsWeight / divisor);


                    while (true)
                    {
                        // Checking if all possible sums of weights contains proper weight value 
                        bool isPerfectWeightBalanse = allPossibleSums.Contains(properWeightbalanse);
                        if (isPerfectWeightBalanse == true)
                        {
                            kattisBagWeight = properWeightbalanse;
                            break;
                        }
                        // if not then increasing proper weight value and moving to next iteration
                        properWeightbalanse++;
                    }

                    int kittensBagWeight = totalItemsWeight - kattisBagWeight;

                    string result = $"{kattisBagWeight} {kittensBagWeight}";
                    Console.WriteLine(result);

                }
            }

        // This method i borrowed from stackoverflow to find all possible sums 
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
