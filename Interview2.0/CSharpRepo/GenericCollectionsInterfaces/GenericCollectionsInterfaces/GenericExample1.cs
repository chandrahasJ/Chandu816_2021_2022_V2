using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GenericCollectionsInterfaces
{
    public class Character : IComparable<Character>
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public long PowerLevel { get; set; }
        public int CompareTo([AllowNull] Character other)
        {
            //Greater Than 
            if (this.CharacterId > other.CharacterId)
                return 1;
            //Else Than 
            else if (this.CharacterId < other.CharacterId)
                return -1;
            //Equal To
            else
                return 0;
        }
        public override string ToString()
        {
            return $"{nameof(CharacterId)} - {CharacterId} \t" +
                   $"{nameof(CharacterName)} - {CharacterName} \t" +
                   $"{nameof(PowerLevel)} - {PowerLevel}\t \n";
        }
    }
    public class GenericComparableExample
    {
        public static void DisplayData<T>(List<T> lst) where T :  class
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
            characters.Sort();
            DisplayData<Character>(characters);
        }
    }
}
