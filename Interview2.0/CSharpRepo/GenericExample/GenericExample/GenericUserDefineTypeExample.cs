using System;
using System.Collections.Generic;
using System.Text;

namespace GenericExample
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public double PowerLevel { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            return $"{nameof(CharacterId)} : {CharacterId} \n" +
                   $"{nameof(CharacterName)} : {CharacterName} \n" +
                   $"{nameof(City)} : {City} \n" +
                   $"{nameof(PowerLevel)} : {PowerLevel} \n";
        }
    }
    public class GenericUserDefineTypeExample
    {
        public static void Main()
        {
            //User Defined Type - Character is used with Generic Collections
            List<Character> characters = new List<Character>();
            Character character1 = new Character()
            {
                CharacterId = 101, CharacterName = "Vegata",
                City = "Delhi", PowerLevel = 250000.0
            };
            Character character2 = new Character()
            {
                CharacterId = 102, CharacterName = "Goku",
                City = "Mumbai",PowerLevel = 500000.0
            };
            characters.Add(new Character()
            {
                CharacterId = 103,CharacterName = "Beerus",
                City = "Chennai",  PowerLevel = 5000000.0
            });
            characters.Add(character1);
            characters.Add(character2);
            foreach (Character character in characters)            
                Console.WriteLine(character.ToString());
            
        }
    }
}
