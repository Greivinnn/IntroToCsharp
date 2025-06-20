using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VGP133_Final_WenWu_Greivin
{
    public static class SaveManager // helper class for our SaveData, also static so we do not need to create an instance of SaveManager
    {
        private const string SaveFolder = "SaveFiles";
        
        //Save player data function into a JSON FILE
        public static void SaveGame(Character player, int slot) 
        {
            if (!Directory.Exists(SaveFolder))
            {
                Directory.CreateDirectory(SaveFolder);
            }
            //gets all the revelant information to save
            SaveData data = new SaveData
            {
                PlayerName = player.Name,
                HairColor = player.HairColor,
                Gender = player.Gender,
                Age = player.Age,
                MaxHp = player.MaxHp,
                CurrentHp = player.CurrentHp,
                Atk = player.Atk,
                Def = player.Def,
                CurrentGold = player.CurrentGold,
                EquippedWeapon = player.CurrentWeapon,
                EquippedArmor = player.CurrentArmor,
                Inventory = player.Items,
                DefeatedDragon = player.HasDefeatedDragon
            };
            //converts the SaveData in data into a formatted JSON string, WriteIndented = true makes it human-readable
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            // Writes the JSON to a file named like: SaveFiles/slot1.json, slot2.json, or slot3.json
            File.WriteAllText($"{SaveFolder}/slot{slot}.json", json);
            Console.WriteLine($"\nGame saved to slot {slot}!");
        }

        public static Character LoadGame(int slot)
        {
            // builds a path to the selected slot by the user
            string filePath = $"{SaveFolder}/slot{slot}.json";
            // if the slot is empty 
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Save slot is empty.");
                return null;
            }
            // reads the entire JSON FILE where the info is stored
            string json = File.ReadAllText(filePath);
            // converts the JSON info into a SaveData object
            SaveData data = JsonSerializer.Deserialize<SaveData>(json);

            //
            Character loaded = new Character(data.PlayerName, data.HairColor, data.Gender, data.Age)
            {
                MaxHp = data.MaxHp,
                CurrentHp = data.CurrentHp,
                Atk = data.Atk,
                Def = data.Def,
                CurrentGold = data.CurrentGold,
                CurrentWeapon = data.EquippedWeapon,
                CurrentArmor = data.EquippedArmor,
                Items = data.Inventory,
                HasDefeatedDragon = data.DefeatedDragon
            };

            return loaded;
        }
        public static void ShowSaveSlots()
        {
            for (int i = 1; i <= 3; i++)
            {
                string path = $"{SaveFolder}/slot{i}.json";
                Console.OutputEncoding = System.Text.Encoding.UTF8; // Needed for box-drawing characters
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                string label;
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    SaveData data = JsonSerializer.Deserialize<SaveData>(json);
                    label = $"Slot {i}: {data.PlayerName}";
                }
                else
                {
                    label = $"Slot {i}: [Empty]";
                }

                int totalWidth = 35;
                int padding = totalWidth - label.Length;
                int padLeft = padding / 2 + label.Length;
                string middle = $"║ {label.PadLeft(padLeft).PadRight(totalWidth)} ║";

                Console.WriteLine("╔═════════════════════════════════════╗");
                Console.WriteLine(middle);
                Console.WriteLine("╚═════════════════════════════════════╝");
                Console.ResetColor();
            }
        }
    }
}
