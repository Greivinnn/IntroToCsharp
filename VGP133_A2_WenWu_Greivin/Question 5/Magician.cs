using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_5
{
    internal class Magician
    {
        //properties and getters/setters
        private string _name;
        private string _gender;
        private int _intelligence;
        private List<Spell> _spellBook;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Gender
        { 
            get { return _gender; } 
            set { _gender = value; } 
        }
        public int Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = value; }
        }
        public List<Spell> SpellBook
        {
            get { return _spellBook; }
        }

        //methods
        public Magician(string name, string gender, int intelligence)
        {
            _name = name;
            _gender = gender;
            _intelligence = intelligence;
            _spellBook = new List<Spell>();
        }
        public void LearnSpell(Spell spellInput)
        {
            if (_spellBook.Contains(spellInput))
            {
                Console.WriteLine("Spell already exists in the spellbook.");
            }
            else
            {
                _spellBook.Add(spellInput);
                Console.WriteLine("Spell successfully added to the spellbook.");
            }
        }
        public void UnlearnSpell(Spell spellInput)
        {
            if (_spellBook.Contains(spellInput))
            {
                _spellBook.Remove(spellInput);
                Console.WriteLine("Spell successfully removed from the spellbook.");
            }
            else
            {
                Console.WriteLine("Spell not found in the spellbook.");
            }
        }
        public void ViewSpellbook()
        {
            if (_spellBook == null || _spellBook.Count == 0)
            {
                Console.WriteLine("The spellbook is empty.");
                return;
            }

            Console.WriteLine("Spells in the spellbook:");
            foreach (var spell in _spellBook)
            {
                Console.WriteLine(spell.SpellName);
            }
        }
    }
}
