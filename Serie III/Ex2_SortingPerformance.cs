using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_III
{
    public struct SortData
    {
        /// <summary>
        /// Moyenne pour le tri par insertion
        /// </summary>
        public long InsertionMean { get; set; }
        /// <summary>
        /// Écart-type pour le tri par insertion
        /// </summary>
        public long InsertionStd { get; set; }
        /// <summary>
        /// Moyenne pour le tri rapide
        /// </summary>
        public long QuickMean { get; set; }
        /// <summary>
        /// Écart-type pour le tri rapide
        /// </summary>
        public long QuickStd { get; set; }
    }

    public static class SortingPerformance
    {
        public static void DisplayPerformances(List<int> sizes, int count)
        {
            //TODO
        }

        public static List<SortData> PerformancesTest(List<int> sizes, int count)
        {
            //TODO

            return new List<SortData>();
        }

        public static SortData PerformanceTest(int size, int count)
        {
            //TODO
            double sommeQ = 0;
            double sommeI = 0;
            for (int i = 0; i <= count; i++)
            {
                sommeQ += UseQuickSort(ArraysGenerator(size)[0]);
                sommeI += UseInsertionSort(ArraysGenerator(size)[1]);
            }
            double moyenneQ = sommeQ / count;
            double moyenneI = sommeI / count;
            return new SortData();
        }

        private static List<int[]> ArraysGenerator(int size)
        {
            //TODO
            List<int[]> list = new List<int[]>();
            int[] tab1 = new int[size];
            int[] tab2 = new int[size];
            Random rdm = new Random();
            
            for (int i = 0; i < size; i++)
            {
                int rmp = rdm.Next(-1000, 1001);
                tab1[i] = rmp;
                tab2[i] = rmp;
            }
            list.Add(tab1);
            list.Add(tab2);
            return new List<int[]>();
        }
        
        public static long UseInsertionSort(int[] array)
        {
            //TODO
            Stopwatch watch = new Stopwatch();
            watch.Start();
            InsertionSort(array);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours,ts.Minutes,ts.Seconds,ts.Milliseconds/10);
            Console.WriteLine("RunTime " + elapsedTime);
            return ts.Milliseconds;
        }

        public static long UseQuickSort(int[] array)
        {
            int left = 0;
            int right = array.Length-1;
            //TODO
            Stopwatch watch = new Stopwatch();
            watch.Start();
           QuickSort(array,left,right);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            return -1;
        }

        private static void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int tmp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = tmp;
                    }
                }
            };
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                QuickSort(array, left, pivot - 1);
                QuickSort(array, pivot + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                }
            }
            int tmp = array[i];
            array[i] = array[right];
            array[right] = tmp;
            return i;
        }
    }
}
