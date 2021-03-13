using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Lab3
    {
        static int[] intArray = {17,  166,  288,  324,  531,  792,  946,  157,  276,  441, 533, 355, 228, 879, 100, 421, 23, 490, 259, 227,
                                 216, 317, 161, 4, 352, 463, 420, 513, 194, 299, 25, 32, 11, 943, 748, 336, 973, 483, 897, 396,
                                 10, 42, 334, 744, 945, 97, 47, 835, 269, 480, 651, 725, 953, 677, 112, 265, 28, 358, 119, 784,
                                 220, 62, 216, 364, 256, 117, 867, 968, 749, 586, 371, 221, 437, 374, 575, 669, 354, 678, 314, 450,
                                 808, 182, 138, 360, 585, 970, 787, 3, 889, 418, 191, 36, 193, 629, 295, 840, 339, 181, 230, 150 };


        static void Main(string[] args)
        {
            int letContinue = 0;
            int[] intArrayUnsort = new int[100];
            string again;
            PrintArray(intArray);
            Console.WriteLine("\n");
            
            intArray.CopyTo(intArrayUnsort, 0);

            int sorting = BubbleSort(intArray);
            Console.WriteLine("The number of swaping is: " + sorting + "\n");

            PrintArray(intArray);
            Console.WriteLine("\n");

            
            

            while (letContinue == 0){
                Console.WriteLine("Please enter a number: ");
                int number = int.Parse(Console.ReadLine());

                int index1 = LinearSearch(intArrayUnsort, number, out int numOfComparison);
                if (index1 == -1)
                {
                    Console.WriteLine("Linear search made " + numOfComparison + " comparison to find out that " + number + " is not in this unsorted array.");
                }
                else
                {
                    Console.WriteLine("Linear search made " + numOfComparison + " comparison to find out that " + number + " is at index " + index1 + " in the unsorted array");
                }

                Console.WriteLine("\n");

                int index2 = BinarySearch(intArray, number, out numOfComparison);
                if (index2 == -1)
                {
                    Console.WriteLine("Binary search made " + numOfComparison + " comparison to find out that " + number + " is not in this sorted array.");
                }
                else
                {
                    Console.WriteLine("Binary search made " + numOfComparison + " comparison to find out that " + number + " is at index " + index2 + " in the sorted array");
                }

                Console.WriteLine("\n");
                Console.WriteLine("Would you like to continue?(Y/N)");
                again = Console.ReadLine();
                if (again == "N")
                {
                    letContinue = 1;
                }
                   
            }
           

        }

        static int LinearSearch(int[] haystack, int niddle, out int numOfComparison)
        {
            numOfComparison = 0;
            int niddleIndex = -1;

            int N = haystack.Length;
            for (int i = 0; i < N; i++)
            {
                numOfComparison++;
                if (haystack[i] == niddle)
                    return i;
            }
            return niddleIndex;
        }


        static int BubbleSort(int[] arr)
        {
            int numOfSwaps = 0;

            int n = arr.Length;
            for (int i = 0; i < n; i++)
                for(int j = 0; j < n - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        int first = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = first;
                        numOfSwaps++;
                    }
            intArray = arr;

            return numOfSwaps;
        }

        static int BinarySearch(int[] haystack, int niddle, out int numOfComparison)
        {
            numOfComparison = 0;
            int niddleIndex = -1;
            
            int N = haystack.Length;
            int min = 0;
            int max = N - 1;
            while (min <= max)
            {
                numOfComparison++;
                int mid = (min + max) / 2;
                if (haystack[mid] == niddle)
                {
                    return mid;
                }
                    
                else if (niddle < haystack[mid])
                {
                    max = mid - 1;
                }
                    
                else if (niddle > haystack[mid])
                {
                    min = mid + 1;
                }
                    
            }



            return niddleIndex;
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    Console.Write("{0}, ", arr[i]);
                }
                else
                {
                    Console.Write("{0} ", arr[i]);
                }
            }
            Console.WriteLine();
        }
        


    }
}
