﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Arrays
{
    class Program
    {
        /*
        static void Main(string[] args)
        {
            // make a single dimension array
            Array MyArray1 = Array.CreateInstance(typeof(int), 5);

            // make a 3 dimensional array
            Array MyArray2 = Array.CreateInstance(typeof(int), 5, 3, 2);

            // make an array container
            Array BossArray = Array.CreateInstance(typeof(Array), 2);
            BossArray.SetValue(MyArray1, 0);
            BossArray.SetValue(MyArray2, 1);

            int i = 0, j, rank;
            foreach (Array anArray in BossArray)
            {
                rank = anArray.Rank;
                if (rank > 1)
                {
                    Console.WriteLine("Lengths of {0:d} dimension array[{1:d}]", rank, i);
                    // show the lengths of each dimension
                    for (j = 0; j < rank; j++)
                    {
                        Console.WriteLine("    Length of dimension({0:d}) = {1:d}", j, anArray.GetLength(j));
                    }
                }
                else
                {
                    Console.WriteLine("Lengths of single dimension array[{0:d}]", i);
                }
                // show the total length of the entire array or all dimensions
                Console.WriteLine("    Total length of the array = {0:d}", anArray.Length);
                Console.WriteLine();
                Console.ReadKey();
                i++;
            }
        }
        */

        static void Main(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            //int i = Convert.ToInt32(Console.ReadLine());
            string input = @"E:\Lab\Microsoft\DotNet\Git\Arrays\Arrays\test.txt";

            listDictionary(input);

            /*****************/
            //TESTING ARRAYS
            Console.WriteLine("\n\n\n");

            //Different types of array declaration and initialization
            double[] balance1 = new double[10]; //Array declaration. All the array elements are initialized to zero.
            Console.WriteLine("Length of balance1: " + balance1.Length);

            double[] balance2 = { 2340.0, 4523.69, 3421.0 };
            Console.WriteLine("Length of balance2: " + balance2.Length);

            int[] marks1 = new int[5] { 99, 98, 92, 97, 95 };
            Console.WriteLine("Length of marks1: " + marks1.Length);

            int[] marks2 = new int[] { 99, 98, 92, 97, 95 };
            Console.WriteLine("Length of marks2: "+marks2.Length);

            //Checking on property
            bool balan = balance1.IsFixedSize;
            Console.WriteLine(balan);

            /*********/
            //HOUR GLASS SUM ACTIVITY
            int[][] arr = new int[6][];
            string input1 = @"E:\Lab\Microsoft\DotNet\Git\Arrays\Arrays\2DArrays_02.txt";
            string[] lines = File.ReadAllLines(input1);

            for (int i = 0; i < 6; i++)
            {
                string strLine = lines[i];
                arr[i] = Array.ConvertAll(strLine.Split(' '), arrTemp => Convert.ToInt32(arrTemp)); 
            }

            Console.WriteLine("\nHourglass Sum: "+HourGlassArray(arr));



            Console.ReadKey();
        }
        public static void listDictionary(string input)
        {
            string[] lines = File.ReadAllLines(input);


            int i = Convert.ToInt32(lines[0]);
            //Console.WriteLine(i);

            /* SPLIT STRING TO ARRAY
            string strLine = "sam 99912222";
            string[] strWord = strLine.Split(' ');
            Console.WriteLine(strWord[0]);
            Console.WriteLine(strWord[1]);
            foreach (var word in strWord)
            {
                Console.WriteLine($"{word}");
            }
            */


            Dictionary<string, string> vals = new Dictionary<string, string>();

            for (int j = 1; j <= i; j++)
            {
                string strLine = lines[j];
                string[] strWord = strLine.Split(' ');

                vals.Add(strWord[0], strWord[1]);
            }

            // print dictionary
            //foreach (KeyValuePair<string, string> val in vals)
            //{
            //    Console.WriteLine($"{val.Key} {val.Value}");
            //}

            int k = lines.Count();
            //Console.WriteLine(k);

            for (int x = i + 1; x < k; x++)
            {
                string strKey = lines[x];
                string strVal;

                if (vals.TryGetValue(strKey, out strVal))
                {
                    Console.WriteLine(strKey + "=" + strVal);
                }
                else
                {
                    Console.WriteLine("Not found");
                }

            }
            /*
            $strPerson = trim(fgets($stdin));
            while ($strPerson != ""){
                if (array_key_exists($strPerson,$strCon))
                {
                    fwrite($stdout, $strPerson."=".$strCon[$strPerson]);
                }
                else
                {
                    fwrite($stdout, "Not found". "\n");
                }
            //Get next line.
            $strPerson = trim(fgets($stdin));
                    }
             */

            /*********DICTIONARY**********/
            /*string strLine = "sam 99912222";
            string[] strWord = strLine.Split(' ');

            Dictionary<string, string> vals = new Dictionary<string, string>();
            {         { strWord[0], strWord[1] }           };



            foreach (KeyValuePair<string, string> val in vals)
            {
                Console.WriteLine($"Pair here: {val.Key}, {val.Value}");
            }

            // Use KeyValuePair to use foreach on Dictionary.
            foreach (KeyValuePair<string, int> bird in birds)
            {
                Console.WriteLine($"Pair here: {bird.Key}, {bird.Value}");
            }
            */

            /*********LIST**********/
            /*var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>(strWord[0], strWord[1]));

            foreach (var element in list)
            {
                Console.WriteLine(element);
            }*/
        }
        public static int HourGlassArray(int[][] arr) {
            int result = 0;
            int arrIndex = 0;
            //This function only works if data input is composed of 6x6 2D Array
            int[] resultCount = new int[16];

            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    result += arr[i][j];
                    result += arr[i][j + 1];
                    result += arr[i][j + 2];
                    result += arr[i + 1][j + 1];
                    result += arr[i+2][j];
                    result += arr[i+2][j + 1];
                    result += arr[i+2][j + 2];

                    resultCount[arrIndex] = result;
                    arrIndex += 1;
                    result = 0;
                }
            }
            int z = resultCount.Max();

            return z;
        }
        public static int HourGlassList(int[][] arr)
        {
            //This function does not depened on size of input data.
            int result = 0;
            List<int> resultCount = new List<int>();

            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    result += arr[i][j];
                    result += arr[i][j + 1];
                    result += arr[i][j + 2];
                    result += arr[i + 1][j + 1];
                    result += arr[i + 2][j];
                    result += arr[i + 2][j + 1];
                    result += arr[i + 2][j + 2];

                    resultCount.Add(result);
                    result = 0;
                }
            }
            return resultCount.Max();
        }
    }
}
