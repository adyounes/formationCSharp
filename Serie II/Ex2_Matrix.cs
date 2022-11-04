using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class Matrix
    {
        public static int[][] BuildingMatrix(int[] leftVector, int[] rightVector)
        {
            int[][] matrix = new int[leftVector.Length][];

            for (int i = 0; i < leftVector.Length; i++)
            {
                matrix[i] = new int[rightVector.Length];

                for (int j = 0; j < rightVector.Length; j++)
                {
                    matrix[i][j] = leftVector[i] * rightVector[j];
                }
            }
            return (matrix);
        }

        public static int[][] Addition(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] result = new int[leftMatrix.Length][];

            if (leftMatrix.Length == rightMatrix.Length)
            {
                for (int i = 0; i < leftMatrix.Length; i++)
                {
                    if (leftMatrix[i].Length == rightMatrix[i].Length)
                    {
                        result[i] = new int[leftMatrix[i].Length];

                        for (int j = 0; j < leftMatrix[i].Length; j++)
                        {
                            result[i][j] = leftMatrix[i][j] + rightMatrix[i][j];
                        }
                    }
                }
            }

            return (result);
        }

        public static int[][] Substraction(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] result = new int[leftMatrix.Length][];

            if (leftMatrix.Length == rightMatrix.Length)
            {
                for (int i = 0; i < leftMatrix.Length; i++)
                {
                    if (leftMatrix[i].Length == rightMatrix[i].Length)
                    {
                        result[i] = new int[leftMatrix[i].Length];

                        for (int j = 0; j < leftMatrix[i].Length; j++)
                        {
                            result[i][j] = leftMatrix[i][j] - rightMatrix[i][j];
                        }
                    }
                }
            }

            return (result);
        }

        public static int[][] Multiplication(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] result = new int[leftMatrix.Length][];

            if (leftMatrix[0].Length == rightMatrix.Length)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = new int[rightMatrix[0].Length];

                    for (int j = 0; j < rightMatrix[0].Length; j++)
                    {
                       

                        for (int k = 0; k < rightMatrix.Length; k++)
                        {
                            result[i][j] += leftMatrix[i][k] * rightMatrix[k][j];
                        }
                    }
                }
            }

            return (result);
        }

        public static void DisplayMatrix(int[][] matrix)
        {
            string s = string.Empty;
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[i].Length; ++j)
                {
                    s += matrix[i][j].ToString().PadLeft(5) + " ";
                }
                s += Environment.NewLine;
            }
            Console.WriteLine(s);
        }
    }
}
