using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSearchEg101
{
    public class Search
    {
        public int linearSearch(int[] arrayData, int arrayLength, int searchKey, out int searchIndex)
        {
            int index = searchIndex  = 0;
            while (index < arrayLength)
            {
                if (arrayData[index] == searchKey)
                {
                    searchIndex = index;
                    return index;
                }

                index += 1;
            }
            searchIndex = -1;
            return -1;
        }
    }
}
