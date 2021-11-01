using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Algorithms
{
    public class ShellSort : DisplayArray
    {
        public int[] PerformShellSort(int[] unsortedArray, int lengthOfUnSortedArray)
        {
            int gap = lengthOfUnSortedArray / 2;
            while (gap > 0)
            {
                int i = gap;
                while (i < lengthOfUnSortedArray)
                {
                    int tempValue = unsortedArray[i];
                    int j = i - gap;
                    while (j >= 0 && unsortedArray[j] > tempValue)
                    {
                        unsortedArray[j + gap] = unsortedArray[j];
                        j = j - gap;
                    }
                    unsortedArray[j + gap] = tempValue;
                    i = i + 1;
                }
                gap = gap / 2;
            }
            return unsortedArray;
        }
    }
}
