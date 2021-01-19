using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");  
            try
            {
                int n = Convert.ToInt32(Console.ReadLine());
                if (n > 0)
                    printTriangle(n);
                else
                    Console.WriteLine("Enter a number greater than 0");
            }
            catch
            {
                Console.WriteLine("Incorrect Input");
                Console.ReadLine();
            }
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            try
            {
                int n2 = Convert.ToInt32(Console.ReadLine());
                if (n2 > 0)
                    printPellSeries(n2);
                else
                    Console.WriteLine("Enter a number greater than 0");
            }
            catch
            {
                Console.WriteLine("Incorrect Input");
                Console.ReadLine();
            }
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            try
            {
                int n3 = Convert.ToInt32(Console.ReadLine());
                bool flag = SquareSums(n3);
                if (flag)
                {
                    Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
                }
                else
                {
                    Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
                }
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Incorrect Input");
                Console.ReadLine();
            }

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);
            Console.ReadLine();

        }


        private static void printTriangle(int n)
        {
            int i, j, count;
            count = n - 1;
            try
            {
                for (j = 1; j <= n; j++)
                {
                    for (i = 1; i <= count; i++)
                        Console.Write(" ");
                    count--;
                    for (i = 1; i <= 2 * j - 1; i++)
                        Console.Write("*");
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        private static void printPellSeries(int n2)
        {
            try
            {
                int i, c = 0;
                
                int a = 0;
                int b = 1;
                int sum = 1;
                if (n2 == 1)
                {
                    Console.Write("Series : " + a);
                    Console.Write("Sum : " + b);
                }
                if (n2 == 2)
                {
                    Console.Write("Series : " + a + " " + b);
                    Console.Write("Sum : " + (a + b));
                }
                else
                {
                    Console.Write("Series : " + a + " " + b + " ");
                    for (i = 3; i <= n2; i++)
                    {
                        c = a + 2 * b;
                        Console.Write(c + " ");
                        a = b;
                        b = c;
                        sum = sum + c;
                    }
                    Console.WriteLine("Sum : " + sum);
                }
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                Console.ReadLine();
                throw;
            }

        }

        private static bool SquareSums(int n3)
        {
            try
            {
                bool flag = false;
                if (n3 >= 0)
                {
                    int i, j;
                    //bool flag = false;
                    for (i = 0; i * i <= n3; i++)
                    {
                        for (j = 0; j * j <= n3; j++)
                        {
                            if (i * i + j * j == n3)
                            {
                                flag = true;
                            }
                        }
                    }
                    return flag;
                }
                else
                    return flag;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                Console.ReadLine();
                throw;
            }
        }

        private static string DestCity(string[,] paths)
        {
            try
            {
                string cityname = " ";
                List<string> list_ori = new List<string>();
                List<string> list_des = new List<string>();
                int i;
                for (i = 0; i < paths.GetLength(0); i++)
                {
                    list_ori.Add(paths[i, 0]);
                    list_des.Add(paths[i, 1]);
                }

                var output = list_des.Except(list_ori);
                foreach (var name in output)
                cityname = Convert.ToString(name);
                
                return cityname;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
