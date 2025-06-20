using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Final_WenWu_Greivin
{
    public class Character
    {
        //character creation variables
        private string _name;
        private string _hairColor;
        private char _gender;
        private int _age;
        //character battle variables
        private int _maxHp;
        private int _currentHp;
        private int _atk;
        private int _def;
        private int _currentGold;
        private Weapon _currentWeapon;
        private Armor _currentArmor;
        private bool _hasDefeatedDragon;
        //character inventory
        private List<Item> _inventory;
        //Getters for the variables above
        public int CurrentGold { get { return _currentGold; } set { _currentGold = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string HairColor { get { return _hairColor; } set { _hairColor = value; } }
        public char Gender { get { return _gender; } set { _gender = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public int MaxHp { get { return _maxHp; } set { _maxHp = value; } }
        public int CurrentHp { get { return _currentHp; } set { _currentHp = value; } }
        public int Atk { get { return _atk; } set { _atk = value; } }
        public int Def { get { return _def; } set { _def = value; } }
        public List<Item> Items { get { return _inventory; } set { _inventory = value; } }
        public Weapon CurrentWeapon { get { return _currentWeapon; } set { _currentWeapon = value; } }
        public Armor CurrentArmor { get { return _currentArmor; } set { _currentArmor = value; } }
        public bool CanFlee { get; set; } = true;
        public bool HasDefeatedDragon { get { return _hasDefeatedDragon; } set { _hasDefeatedDragon = value; } }
        //constructor
        public Character()
        {
            _inventory = new List<Item>();
        }
        public Character(string name, string hairColor, char gender, int age)
        {
            _name = name;
            _hairColor = hairColor;
            _gender = gender;
            _age = age;
            _maxHp = 100;
            _currentHp = 100;
            _atk = 10;
            _def = 7;
            _currentGold = 50; //the gold players start with
            _inventory = new List<Item>();
            _currentWeapon = null;
            _currentArmor = null;
            _hasDefeatedDragon = false;
        }
        public void AddToInventory(Item item)
        {
            _inventory.Add(item);
        }
    }
}
