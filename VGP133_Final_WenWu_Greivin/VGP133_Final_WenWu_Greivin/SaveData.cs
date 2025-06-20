using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_Final_WenWu_Greivin
{
    public class SaveData
    {
        //all the stuff we need from the player
        public string PlayerName { get; set; }
        public string HairColor { get; set; }
        public char Gender { get; set; }
        public int Age { get; set; }
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int CurrentGold { get; set; }
        public bool DefeatedDragon { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public List<Item> Inventory { get; set; }
        public SaveData() { }
    }
}
