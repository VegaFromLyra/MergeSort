using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 7, 3, 5, 6, 2 };

            MergeSort(input, 0, input.Length - 1);

            Console.WriteLine("Sorted array is");

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i] + " ");
            }
        }

        static void MergeSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                MergeSort(array, low, middle);
                MergeSort(array, middle + 1, high);
                Merge(array, low, middle, high);
            }
        }

        static void Merge(int[] array, int low, int middle, int high)
        {
            int[] helper = new int[array.Length];

            // Copy both halves into helper array
            for (int i = low; i <= high; i++)
            {
                helper[i] = array[i];
            }

            int helperLeft = low;
            int helperRight = middle + 1;

            int current = low;

            while ((helperLeft <= middle) && (helperRight <= high))
            {
                if (helper[helperLeft] < helper[helperRight])
                {
                    array[current] = helper[helperLeft];
                    current++;
                    helperLeft++;
                }
                else
                {
                    array[current] = helper[helperRight];
                    current++;
                    helperRight++;
                }
            }

            if (helperLeft <= middle)
            {
                while (helperLeft <= middle)
                {
                    array[current] = helper[helperLeft];
                    current++;
                    helperLeft++;
                }
            }
            else
            {
                while (helperRight <= high)
                {
                    array[current] = helper[helperRight];
                    current++;
                    helperRight++;
                }
            }
        }
    }
}
