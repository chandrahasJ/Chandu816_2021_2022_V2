using SortingAlgorithms.Algorithms;
using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ArrayData = { 5, 3, 6, 8, 2, 1 };
            SelectionSort selectionSort = new SelectionSort();

            selectionSort.DisplayData(ArrayData, ArrayData.Length, false);
            selectionSort.StartSelectionSort(ArrayData, ArrayData.Length);
            selectionSort.DisplayData(ArrayData, ArrayData.Length, false);

            Console.ReadLine();

        }
    }
}
