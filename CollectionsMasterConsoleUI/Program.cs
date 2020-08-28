using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create

            #region Arrays
            // Create an integer Array of size 50
            var nArray = new int[50];

            //Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(nArray);

            //Print the first number of the array
            Console.WriteLine(nArray[0]);

            //Print the last number of the array            
            Console.WriteLine(nArray[nArray.Length-1]);

            Console.WriteLine("All Numbers Original");
            //Use this method to print out your numbers from arrays or lists
            NumberPrinter(nArray);
            Console.WriteLine("-------------------");

            //Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*     Hint: Array._____(); Create a custom method     */

            Console.WriteLine("All Numbers Reversed:");
            ReverseArray(nArray);
            NumberPrinter(nArray);

            Console.WriteLine("---------REVERSE CUSTOM------------");
            var nArrRev = nArray.Reverse();
            NumberPrinter(nArrRev);

            Console.WriteLine("-------------------");

            //Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(nArray);

            Console.WriteLine("-------------------");

            //Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(nArray);
            NumberPrinter(nArray);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //Create an integer List
            var nList = new List<int>();

            //Print the capacity of the list to the console
            Console.WriteLine(nList.Count);

            //Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(nList);

            //Print the new capacity
            Console.WriteLine(nList.Count);

            Console.WriteLine("---------------------");

            //Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");
            int nInput;
            while (Int32.TryParse(Console.ReadLine(), out nInput) == false)
                Console.WriteLine("Invalid input, try again");
            NumberChecker(nList, nInput);
            
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //Print all numbers in the list
            NumberPrinter(nList);
            Console.WriteLine("-------------------");

            //Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Odds Only!!");
            OddKiller(nList);

            Console.WriteLine("------------------");

            //Sort the list then print results
            Console.WriteLine("Sorted Odds!!");
            nList.Sort();
            NumberPrinter(nList);
            
            Console.WriteLine("------------------");

            //Convert the list to an array and store that into a variable
            var nArrayFromList = nList.ToArray();

            //Clear the list
            nList.Clear();

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i] % 3 == 0)
                    numbers[i] = 0;

            NumberPrinter(numbers);
        }

        private static void OddKiller(List<int> numberList)
        {
            bool done = false;
            while (!done)
            {
                int i;
                for (i = 0; i < numberList.Count; i++)
                    if (numberList[i] % 2 != 0)
                    {
                        numberList.Remove(numberList[i]);
                        break;
                    }
                if(i == numberList.Count)
                    done = true;
            }

            NumberPrinter(numberList);
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            var cnt = 0;
            foreach (int n in numberList)
                if (n == searchNumber)
                    cnt++;
            Console.WriteLine($"{searchNumber} is present in the list {cnt} times");
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            for(int i = 0; i < 50; i++)
                numberList.Add(rng.Next(50));

        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();
            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rng.Next(50);
            }

        }        

        private static void ReverseArray(int[] array)
        {
            var temp = new int[array.Length];

            for(int i = 0; i < array.Length; i++)
                temp[i] = array[array.Length - 1 - i];

            for (int i = 0; i < array.Length; i++)
                array[i] = temp[i];
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
