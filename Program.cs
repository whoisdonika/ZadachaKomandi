using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadachaKomandi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter numbers : ");
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            Console.Write("Enter command : ");
            string command = Console.ReadLine();

            while (command != "print")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "push")
                {
                    int num = int.Parse(tokens[1]);
                    nums.Add(num);
                }
                else if (action == "pop")
                {
                    if (nums.Count > 0)
                    {
                        int num = nums[nums.Count - 1];
                        nums.RemoveAt(nums.Count - 1);
                        Console.WriteLine(num);
                    }
                }
                else if (action == "shift")
                {
                    if (nums.Count > 0)
                    {
                        int num = nums[nums.Count - 1];
                        nums.RemoveAt(nums.Count - 1);
                        nums.Insert(0, num);
                    }
                }
                else if (action == "addMany")
                {
                    int index = int.Parse(tokens[1]);

                    if (index >= 0 && index < nums.Count)
                    {
                        List<int> addNums = new List<int>();

                        for (int i = 2; i < tokens.Length; i++)
                        {
                            int numberToAdd = int.Parse(tokens[i]);
                            addNums.Add(numberToAdd);
                        }

                        nums.InsertRange(index, addNums);
                    }
                }
                else if (action == "remove")
                {
                    int index = int.Parse(tokens[1]);

                    if (index >= 0 && index < nums.Count)
                    {
                        nums.RemoveAt(index);
                    }
                }
                Console.Write("Enter command : ");
                command = Console.ReadLine();
            }

            nums.Reverse();
            Console.WriteLine(string.Join(", ", nums));



        }
    }
}
