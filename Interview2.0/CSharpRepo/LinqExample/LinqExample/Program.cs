using System;
using System.Linq;
namespace LinqExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayData = { 12, 10, 5, 48, 9, 80, 39, 85, 11, 16, 
                                75, 88, 74, 55, 9, 1, -1, 5 };

            var getValueGreaterThan40 = from arrayValue in arrayData  //<alias> in <collection> 
                                        where arrayValue > 40         //<clauses>
                                        orderby arrayValue descending //<clauses>
                                        select arrayValue;            //select <alias>
            foreach (var item in getValueGreaterThan40)
                Console.Write(item +"\t");

        }
    }
}
