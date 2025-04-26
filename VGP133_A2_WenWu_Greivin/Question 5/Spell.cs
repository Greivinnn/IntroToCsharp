using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_5
{
    internal class Spell
    {
        //properties and getters/setters
        private string _spellName;
        private int _spellPower;
        private int _castTime;
        private string _element;
        public string SpellName
        {
            get { return _spellName; }
            set { _spellName = value; }
        }
        public int SpellPower
        {
            get { return _spellPower; }
            set { _spellPower = value; }
        }
        public int CastTime
        {
            get { return _castTime; }
            set { _castTime = value; }
        }
        public string Element
        {
            get { return _element; }
            set { _element = value; }
        }
        //methods
        public Spell(string spellName, int spellPower, int castTime, string element)
        {
            _spellName = spellName;
            _spellPower = spellPower;
            _castTime = castTime;
            _element = element;
        }
    }
}
