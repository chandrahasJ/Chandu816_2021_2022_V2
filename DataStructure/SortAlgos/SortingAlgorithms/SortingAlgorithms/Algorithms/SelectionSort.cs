using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Algorithms
{
    /// <summary>
    /// UnStable Sorting Algo
    /// </summary>
    internal class SelectionSort : DisplayArray
    {
        public SelectionSort()
        {

        }

        public void StartSelectionSort(int[] unSortedData, int lengthOfUnSortedData)
        {
            int position = 0;
            for (int i = 0; i < lengthOfUnSortedData -1; i++)
            {
                position = i;
                for (int j = i+1; j < lengthOfUnSortedData; j++)
                {
                    if (unSortedData[j] < unSortedData[position])   
                    {
                        position = j;
                    }                    
                }

                int temp = unSortedData[i];
                unSortedData[i] = unSortedData[position];
                unSortedData[position] = temp;
            }
        }
    }
}
