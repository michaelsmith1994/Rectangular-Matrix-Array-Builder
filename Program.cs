using System;
using System.IO;
using System.Windows;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assigment1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numRows;
            int numCols;
            Console.WriteLine("Enter a value for the # of rows you would like.");//input rows for matrix
            Console.WriteLine("number of rows: ");
            numRows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a value for the # of columns you would like.");//input coloumns for matrix
            Console.WriteLine("number of columns: ");
            numCols = Convert.ToInt32(Console.ReadLine());
            double[,] rectangleArray = new double[numRows, numCols];

            Random random = new Random();
            // instantiate and display the variables in our matrix (converted to two decimal points for easy verification purposes)
            for (int i = 0; i < numRows; i++)
            {
                double[] resultingArray = new double[numCols];

                for (int j = 0; j < numCols; j++)
                {

                    Console.WriteLine("Random values for row " + (i + 1) + " is:");
                    rectangleArray[i, j] = (random.NextDouble() * (100));
                    //lets clean the decimals a little for neatness
                    double bigDecimalValue = (random.NextDouble() * (100));
                    string twoDecimalValue = bigDecimalValue.ToString("0.00");
                    rectangleArray[i, j] = double.Parse(twoDecimalValue);
                    Console.WriteLine(rectangleArray[i, j]);


                }
            }
            Console.WriteLine();
            Console.WriteLine("\nHere is the array in proper format: ");
            MatrixHandler.ArrayPrint(rectangleArray, numRows, numCols);//call static matrix print method
            Console.WriteLine();
            Console.Write("\nHere is the sum: ");
            MatrixHandler.ArraySum(rectangleArray);//call static matrix sum method
            Console.Write("\nHere is the average: ");
            MatrixHandler.ArrayAverage(rectangleArray);//call static matrix average method
            Console.WriteLine();
            Console.WriteLine("\nHere is the largest in each row: ");
            MatrixHandler.ArrayLargestInRow(rectangleArray, numRows, numCols);//call static largest in rows method
            Console.WriteLine("");
            Console.WriteLine("\nHere is the largest in each column: ");
            MatrixHandler.ArrayLargestInCol(rectangleArray, numRows, numCols);//call static largest in coloumns method
            Console.WriteLine("");
            Console.WriteLine("Press the ENTER key to close the project.");
            Console.ReadLine();
        }
    }
    //matrixHandler for required methods
    class MatrixHandler
    {
        public static void ArraySum(double[,] array)
        {
            double total = 0;
            foreach (double number in array)
            {
                total += number;
            }
            Console.Write(total.ToString("0.00"));
        }
        public static void ArrayAverage(double[,] array)
        {
            double total = 0, average = 0;
            foreach (double number in array)
            {
                total += number;
                average = total / array.Length;

            }
            Console.Write(average.ToString("0.00"));

        }
        public static void ArrayLargestInRow(double[,] array, int rows, int cols)
        {
            double[] result = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                double newMax = array[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (array[i, j] > newMax)
                    {
                        newMax = array[i, j];
                    }
                }
                result[i] = newMax;
            }
            Console.Write("[");
            for (int n = 0; n < rows; n++)
            {
                Console.Write(" " + result[n] + " ");
            }
            Console.Write("]");
        }

        public static void ArrayLargestInCol(double[,] array, int rows, int cols)
        {
            double[] result = new double[cols];
            for (int j = 0; j < cols; j++)
            {
                double newMax = array[0, j];
                for (int i = 1; i < rows; i++)
                {
                    if (array[i, j] > newMax)
                    {
                        newMax = array[i, j];
                    }
                }
                result[j] = newMax;
            }
            Console.Write("[");
            for (int n = 0; n < cols; n++)
            {
                Console.Write(" " + result[n] + " ");
            }
            Console.Write("]");
        }

        public static void ArrayPrint(double[,] array, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.Write("[");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(" " + array[i, j] + " ");
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }
    }
}


