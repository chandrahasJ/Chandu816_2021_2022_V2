using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvanceLinqSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            var characters = new CharacterRepo().GetCharacters();

            characters.Where(x => x.MetaVerseName == "D.C."); // Applies filters on the collection 
            characters.OrderBy(x => x.PowerLevel); // applies ascending or descending order
            characters.Select(x => new { MySuperHero = x.CharacterName }); // creates new Projections.

            characters.Single(x => x.MetaVerseName == "Sony"); // The collection should only contain one matching result 
                                                               // if this criteria is not full filled then exception is thrown.
            characters.SingleOrDefault(x => x.MetaVerseName == "D.C."); //The collection should only contain one matching result 
                                                                        // but if the criteria doesn't match then
                                                                        // it will not thrown an exception
                                                                        // it will just return null in such
                                                                        // cases

            characters.First(x => x.MetaVerseName == "D.C.");   // it will provide the first object in the collection
                                                                // but it criteria doesn't match then 
                                                                // it will thrown en exception
            characters.FirstOrDefault(x => x.MetaVerseName == "One Piece"); // it will also provide the first object in the 
                                                                // collection but it will not thrown exception if the 
                                                                // criteria doesn't matchs

            characters.Min(x => x.PowerLevel);  // Provides min value
            characters.Max(x => x.PowerLevel);  // Provides max value
            characters.Count();                 // Provides the total count
            characters.Sum(x => x.PowerLevel);  // Provides the sum 

            characters.Skip(2);                 //It skips the count 
            characters.Skip(1).Take(2);         //it skips count mentioned & Takes only mentioned objects 
            //And many more...
        }
    }
    public class Character
    {
        public string CharacterName { get; set; }
        public string MetaVerseName { get; set; }
        public int PowerLevel { get; set; }
    }
    public class CharacterRepo
    {
        public List<Character> GetCharacters()
        {
            return new List<Character>()
            {
                new Character (){ CharacterName = "Batman", MetaVerseName = "D.C.", PowerLevel =11 },
                new Character (){ CharacterName = "SuperMan", MetaVerseName = "D.C.", PowerLevel = 10 },
                new Character (){ CharacterName = "Goku", MetaVerseName = "DBZ", PowerLevel = 12 },
                new Character (){ CharacterName = "Vegeta", MetaVerseName = "DBZ", PowerLevel =9 },
                new Character (){ CharacterName = "Iron Man", MetaVerseName = "Marvel", PowerLevel = 8 },
                new Character (){ CharacterName = "Spider Man", MetaVerseName = "Sony", PowerLevel = 5 }
            };
        }
    }
}
