using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Algorithms
{
    public class DisplayArray
    {
        public virtual void DisplayData(int[] ArrayData, int ArrayLength, bool isWriteLine = true)
        {
            for (int i = 0; i < ArrayLength; i++)
            {
                if (isWriteLine == true)
                {
                    Console.WriteLine(ArrayData[i] + " ");
                }
                else
                {
                    Console.Write(ArrayData[i] + " ");
                }
            }
            if (isWriteLine == false)
            {
                Console.WriteLine("");
            }            
        }
    }
}
