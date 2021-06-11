using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamingFileFromData
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClass dc = new DataClass();
            dc.changeTheFileName();
            Console.ReadLine();
        }
    }
}
