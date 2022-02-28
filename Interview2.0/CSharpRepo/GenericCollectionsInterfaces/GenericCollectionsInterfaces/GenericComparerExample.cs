using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GenericCollectionsInterfaces
{
    // Assuming Character class is immutable 
    // cannot be changed & Hence we used IComparer 
    // for comparing complex data
    public class GenericComparerExample : IComparer<Character>
    {
        public int Compare([AllowNull] Character character1, 
                           [AllowNull] Character character2)
        {
            //Greater Than 
            if (character1.PowerLevel > character2.PowerLevel)
                return 1;
            //Else Than 
            else if (character1.PowerLevel < character2.PowerLevel)
                return -1;
            //Equal To
            else
                return 0;
        }
    }
    public class TestGenericComparerExample
    {
        public static void DisplayData<T>(List<T> lst) where T : class
        {
            foreach (var lstValue in lst)
                Console.Write(lstValue.ToString());
            Console.WriteLine("----------------");
        }
        public static void Main()
        {
           Character character1 = new Character
                { CharacterId = 120, CharacterName = "SuperMan", 
                PowerLevel = 200000 };
            Character character3 = new Character
                { CharacterId = 109, CharacterName = "Goku", 
                PowerLevel = 10000000 };
            Character character2 = new Character
                { CharacterId = 150, CharacterName = "Vegata", 
                PowerLevel = 200000 };
            Character character5 = new Character
                { CharacterId = 100, CharacterName = "One Punch Man", 
                PowerLevel =20100};
            Character character10 = new Character
                { CharacterId = 1, CharacterName = "Batman", 
                PowerLevel = 9999 };
            List<Character> characters = new List<Character> 
                { character1, character5, character2, character10, character3 };
            DisplayData<Character>(characters);
            //Create Object of Class which has implemented the IComparer
            GenericComparerExample genericComparerExample = new GenericComparerExample();
            //Provide the object to Sort method.
            characters.Sort(genericComparerExample);
            DisplayData<Character>(characters);
        }
    }
}
