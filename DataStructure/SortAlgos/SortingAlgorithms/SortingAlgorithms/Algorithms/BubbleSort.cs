using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Algorithms
{
    /// <summary>
    /// Stable Sorting Algo
    /// </summary>
    public class BubbleSort : DisplayArray
    {
        public int[] PerformBubbleSort(int[] unsortedArray, int lengthOfUnSortedArray)
        {
            for (int round = lengthOfUnSortedArray - 1; round >= 0; round--)
            {
                for (int i = 0; i < round; i++)
                {
                    if (unsortedArray[i] > unsortedArray[i +1])
                    {
                        int temp = unsortedArray[i];
                        unsortedArray[i] = unsortedArray[i + 1];
                        unsortedArray[i + 1] = temp;
                    }
                }
            }
            return unsortedArray;
        }
    }
}
