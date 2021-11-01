using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Algorithms
{
    /// <summary>
    /// Stable Sorting Algo
    /// </summary>
    public class InsertionSort :DisplayArray
    {
        public InsertionSort()
        {

        }

        public int[] StartInsertinSorting(int[] unSortedArray, int lengthOfUnSortedArray)
        {
            int compareValue = 0;
            int comparePostion = 0;
            for (int i = 0; i < lengthOfUnSortedArray; i++)
            {
                compareValue = unSortedArray[i];
                comparePostion = i;
                while (comparePostion > 0 && unSortedArray[comparePostion -1] > compareValue)
                {
                    unSortedArray[comparePostion] = unSortedArray[comparePostion - 1];
                    comparePostion = comparePostion - 1;
                }
                unSortedArray[comparePostion] = compareValue;
            }
            return unSortedArray;
        }
    }
}
