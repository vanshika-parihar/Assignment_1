using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");  
            try                                                                 //For checking the input type.(needs to be integer)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                if (n > 0)                                                      // Entered value need to be greater than 0.
                    printTriangle(n);
                else
                    Console.WriteLine("Enter a number greater than 0.");
            }// end of try
            catch
            {
                Console.WriteLine("Incorrect Input");                           //The input is not an integer.
                Console.ReadLine();
            }//end of catch
            Console.WriteLine();


            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            try                                                                 //For checking the input type.(needs to be integer)
            {
                int n2 = Convert.ToInt32(Console.ReadLine());
                if (n2 > 0)                                                     // Entered value need to be greater than 0.
                    printPellSeries(n2);
                else
                    Console.WriteLine("Enter a number greater than 0.");
            }//End of try
            catch
            {
                Console.WriteLine("Incorrect Input");                           //The input is not an integer.
                Console.ReadLine();
            }//end of catch
            Console.WriteLine();


            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            try                                                                  //For checking the input type.(needs to be integer)
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
            }//end of try
            catch
            {
                Console.WriteLine("Incorrect Input");                              //The input is not an integer.
                Console.ReadLine();
            }//end of catch
            Console.WriteLine();

            //Question 4:
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);
            Console.WriteLine();

            //Question 5:            
            List<string> emails = new List<string>();            
            emails.Add("dis.email+bull@usf.com");            
            emails.Add("dis.e.mail+bob.cathy@usf.com");            
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);            
            Console.WriteLine("Q5");            
            Console.WriteLine("The number of unique emails is " + ans5);
            Console.ReadLine();
            Console.WriteLine();

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + "\"" +destination+ "\"");
            Console.ReadLine();
        }

        private static int UniqueEmails(List<string> emails)
        {
            try
            {                  
                string[] domain_name = new string[emails.Count];    
                string[] local_name = new string[emails.Count];     
                string[] final_list = new string[emails.Count];     
                int i,index=0;
                for(i=0;i<emails.Count;i++)
                {
                    index = emails[i].IndexOf("@");                         // found the index of "@".
                    local_name[i] = emails[i].Substring(0, index);          //seperating the local name.
                    domain_name[i] = emails[i].Substring(index + 1);        //seperating the domain name.
                    if (local_name[i].Contains("+"))                        // if local name contains +, find the index and remove it.
                    {
                        index = local_name[i].IndexOf("+");
                        local_name[i] = local_name[i].Remove(index);
                    }
                    local_name[i] = local_name[i].Replace(".", string.Empty); // removed "." in the local name

                    final_list[i] = local_name[i] + '@' + domain_name[i];     // updated list of emails
                }

                string[] unique = final_list.Distinct().ToArray();            // unique email in the updated list
                return unique.Length;                                         // returning the cout of unique emails
            }// end of try            
            catch (Exception e)            
            {                
                Console.WriteLine(e.Message);                
                throw;            
            }// end of catch        
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
                        Console.Write(" ");                 //printing " "(blank space).
                    count--;
                    for (i = 1; i <= 2 * j - 1; i++)
                        Console.Write("*");                 //printing "*".
                    Console.WriteLine();                    //entering next row.
                }
            }// end of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }//end of catch
            Console.ReadLine();
        }

        private static void printPellSeries(int n2)
        {
            try
            {
                int i, c = 0;
                
                int a = 0;                                      //first element
                int b = 1;                                      //second element
                if (n2 == 1)                                    //only first element is asked
                {
                    Console.Write("Series : " + a);
                }
                if (n2 == 2)                                    //first two elements are asked
                {
                    Console.Write("Series : " + a + " " + b);
                }
                else                                            //more than 2 elements are asked
                {
                    Console.Write("Series : " + a + " " + b + " ");
                    for (i = 3; i <= n2; i++)
                    {
                        c = a + 2 * b;
                        Console.Write(c + " ");                 //printing 3rd element onwards 
                        a = b;
                        b = c;
                    }
                }
                Console.ReadLine();
            }// end of try
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                Console.ReadLine();
                throw;
            }//end of catch

        }

        private static bool SquareSums(int n3)
        {
            try
            {
                bool flag = false;
                if (n3 >= 0)                                //only if the number is positive integer
                {
                    int i, j;
                    for (i = 0; i * i < n3; i++)
                    {
                        for (j = 0; j * j < n3; j++) 
                        {
                            if (i * i + j * j == n3)        // checking if the number is equal to the sum of two integers
                            {
                                flag = true;
                            }
                        }
                    }
                    return flag;
                }
                else                                        // if number is a negative integer, square sum is not possible
                    return flag;
            }// end of try
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                Console.ReadLine();
                throw;
            }//end of catch
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
                    list_ori.Add(paths[i, 0]);                  // seperating the origin cities
                    list_des.Add(paths[i, 1]);                  // seperating the destination city
                }

                var output = list_des.Except(list_ori);         // filtering the destination city which is not a origin city
                foreach (var name in output)
                cityname = Convert.ToString(name);  
                
                return cityname;                                // returning the city name
            }//end of try
            catch (Exception)
            {
                throw;
            }//end of catch
        }

        private static int diffPairs(int[] arr, int k)
        {
            try
            {
                Array.Sort(arr);                                        // sorted the input array
                Dictionary<int, int> arr_dict = new Dictionary<int, int>();
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[j] - arr[i] == k)                       // if the difference is equal to k
                        {
                            if (!(arr_dict.Keys.Contains(arr[i]))) //if the dictionary keys do not contain ith element of array
                            {
                                arr_dict.Add(arr[i], arr[j]);           //add it to the dictionary 
                            }
                                break;                                  //break out of the outer if 
                        }
                    }// end of inner for loop
                }// end of outer for loop
                return arr_dict.Keys.ToList().Count();                  // returing the count of keys
            }// end of try
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                Console.ReadLine();
                throw;
            }//end of catch
        }

    }

}


    

