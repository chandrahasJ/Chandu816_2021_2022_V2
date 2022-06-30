using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsInterfaces
{
    public class MetaVerseEnumerator : IEnumerator
    {
        private MetaVerse metaVerse;
        private int currentIndex;
        private Character currentCharacter;
        public MetaVerseEnumerator(MetaVerse metaVerse) 
        { 
            this.metaVerse = metaVerse;
            currentIndex = -1;
        }
        
        public object Current => currentCharacter;
        public bool MoveNext()
        {
            if (++currentIndex >= metaVerse.Count) return false;
            else currentCharacter = metaVerse[currentIndex];
            return true;
        }
        public void Reset() { }        
    }
    public class MetaVerse : IEnumerable
    {
        List<Character> characters = new List<Character>();
        public int Count { get { return characters.Count; } }
        public Character this[int index]
        {
            get { return characters[index]; }
        }
        public void Add(Character character)
        {
            characters.Add(character);
        }
        public void Remove(Character character)
        {
            characters.Remove(character);
        }
        public IEnumerator GetEnumerator()
        {
            return new MetaVerseEnumerator(this);
        }
    }

    public class TestMetaVerse
    {
        public static void DisplayData<T>(T lst) where T : class, IEnumerable
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
            MetaVerse metaVerse = new MetaVerse()
            { character1, character5, character2, character10, character3 };
            DisplayData<MetaVerse>(metaVerse);
        }
    }

    


}
