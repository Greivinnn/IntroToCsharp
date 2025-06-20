using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VGP133_Final_WenWu_Greivin
{
    public class LocationManager
    {
        private List<Item> _storeItems;
        private List<Monsters> _weakMonstersPool;
        private List<Item> _commonLootPool;
        private List<Monsters> _strongMonsterPool;
        private List<Item> _rareLootPool;
        private List<Monsters> _bossLootPool;

        List<Item> StoreItems { get { return _storeItems; } set { _storeItems = value; } }
        List<Monsters> WeakMonsterPool { get { return _weakMonstersPool; } set { _weakMonstersPool = value; } }
        List<Item> CommonLootPool { get { return _commonLootPool; } set { _commonLootPool = value; } }
        List<Monsters> StrongMonsterPool { get { return _strongMonsterPool; } set { _strongMonsterPool = value; } }
        List<Item> RareLootPool { get { return _rareLootPool; } set { _rareLootPool = value; } }
        List<Monsters> BossLootPool { get { return _bossLootPool; } set { _bossLootPool = value; } }

        public LocationManager()
        {
            // initialize store items in constructor, this helps sorting out the quantity 
            _storeItems = new List<Item>()
            {
                new Item("Green Apple", 15, "Consumable", 5, 10),
                new Item("Small Health Potion", 10, "Consumable", 10, 20),
                new Item("Healing Tonic", 10, "Consumable", 20, 30),
                new Item("Big Health Potion", 10, "Consumable", 40, 50),
                new Item("Chug Jug", 5, "Consumable", 60, 100),
                new Weapon("Wooden Sword", 1, 10, 2),
                new Weapon("Iron Sword", 1, 25, 5),
                new Weapon("Steel Sword", 1, 50, 8),
                new Weapon("Magic Sword", 1, 80, 12),
                new Weapon("Dragon Sword", 1, 120, 20),
                new Weapon("Obsedian Sword", 1, 150, 30),
                new Armor("Cloth Armor", 1, 10, 1),
                new Armor("Leather Armor", 1, 25, 3),
                new Armor("Iron Armor", 1, 50, 6),
                new Armor("Steel Armor", 1, 80, 12),
                new Armor("Dragon Armor", 1, 120, 20),
                new Armor("Obsedian Armor", 1, 150, 30),
            };
            _weakMonstersPool = new List<Monsters>
            {
                new Witch("Wicked Witch", 10, 5, 25, 10),
                new Goblin("Green Goblin", 15, 6, 30, 20),
                new Barbarian("Raging Barb", 13, 7, 35, 15),
                new Snake("Amazon Snake", 20, 8, 30, 10),
                new Skeleton("Leader Larry", 10, 9, 30, 15),
                new Zombie("Zombie Fabio", 13, 8, 25, 10),
                
            };
            _commonLootPool = new List<Item>()
            {
                new Item("Small Health Potion", 1, "Consumable", 0, 10),
                new Item("Big Health Potion", 1, "Consumable", 0, 25),
                new Item("Green Apple", 1, "Consumable", 0, 5),
                new Item("Healing Tonic", 1, "Consumable", 0, 30),
            };
            _strongMonsterPool = new List<Monsters>
            {
                new Barbarian("King Barb", 28, 5, 45, 30),
                new Witch("Lady Witch", 17, 5, 40, 25),
                new Goblin("King Goblin", 25, 5, 35, 40),
                new Snake("King Snake", 25, 5, 30, 40),
                new Skeleton("King Larry", 20, 5, 45, 30),
                new Zombie("Zombie King", 27, 5, 35, 25),
            };
            _rareLootPool = new List<Item>()
            {
                new Item("Healing Tonic", 1, "Consumable", 0, 30),
                new Weapon("Metal Sword", 1, 0, 9),
                new Item("Big Health Potion", 10, "Consumable", 0, 50),
                new Armor("Leather Pants", 1, 0, 6),
                new Item("Chug Jug", 1, "Consumable", 0, 100),
                new Weapon("Katana Sword", 1, 0, 8),
                new Armor("Scales Armor", 1, 0, 13),
            };
            _bossLootPool = new List<Monsters>()
            {
                new DragonBoss("Inferno The Boss", 60, 20, 100, 100),
            };
        }
        public void PrintWeaponShopTitle()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
 _______  _______          _________ _______  _______  _______  _       _________   _______           _______  _______ 
(  ____ \(  ___  )|\     /|\__   __/(  ____ )(       )(  ____ \( (    /|\__   __/  (  ____ \|\     /|(  ___  )(  ____ )
| (    \/| (   ) || )   ( |   ) (   | (    )|| () () || (    \/|  \  ( |   ) (     | (    \/| )   ( || (   ) || (    )|
| (__    | |   | || |   | |   | |   | (____)|| || || || (__    |   \ | |   | |     | (_____ | (___) || |   | || (____)|
|  __)   | |   | || |   | |   | |   |  _____)| |(_)| ||  __)   | (\ \) |   | |     (_____  )|  ___  || |   | ||  _____)
| (      | | /\| || |   | |   | |   | (      | |   | || (      | | \   |   | |           ) || (   ) || |   | || (      
| (____/\| (_\ \ || (___) |___) (___| )      | )   ( || (____/\| )  \  |   | |     /\____) || )   ( || (___) || )      
(_______/(____\/_)(_______)\_______/|/       |/     \|(_______/|/    )_)   )_(     \_______)|/     \|(_______)|/       
                                                                                                                       
");
        }
        public void PrintShopTitle()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
__________________ _______  _______    _______           _______  _______ 
\__   __/\__   __/(  ____ \(       )  (  ____ \|\     /|(  ___  )(  ____ )
   ) (      ) (   | (    \/| () () |  | (    \/| )   ( || (   ) || (    )|
   | |      | |   | (__    | || || |  | (_____ | (___) || |   | || (____)|
   | |      | |   |  __)   | |(_)| |  (_____  )|  ___  || |   | ||  _____)
   | |      | |   | (      | |   | |        ) || (   ) || |   | || (      
___) (___   | |   | (____/\| )   ( |  /\____) || )   ( || (___) || )      
\_______/   )_(   (_______/|/     \|  \_______)|/     \|(_______)|/       
                                                                          
");
        }
        public void MonsterToArt(ref Monsters monster)
        {
            if (monster.MonsterType == "Skeleton")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(@"
                      :::!~!!!!!:.
                  .xUHWH!! !!?M88WHX:.
                .X*#M@$!!  !X!M$$$$$$WWx:.
               :!!!!!!?H! :!$!$$$$$$$$$$8X:
              !!~  ~:~!! :~!$!#$$$$$$$$$$8X:
             :!~::!H!<   ~.U$X!?R$$$$$$$$MM!
             ~!~!!!!~~ .:XW$$$U!!?$$$$$$RMM!
               !:~~~ .:!M""T#$$$$WX??#MRRMMM!
               ~?WuxiW*`   `""#$$$$8!!!!??!!!
             :X- M$$$$       `""T#$T~!8$WUXU~
            :%`  ~#$$$m:        ~!~ ?$$$$$$
          :!`.-   ~T$$$$8xx.  .xWW- ~""""##*""
.....   -~~:<` !    ~?T#$$@@W@*?$$      /`
W$@@M!!! .!~~ !!     .:XUW$W!~ `""~:    :
#""~~`.:x%`!!  !H:   !WM$$$$Ti.: .!WUn+!`
:::~:!!`:X~ .: ?H.!u ""$$$B$$$!W:U!T$$M~
.~~   :X@!.-~   ?@WTWo(""*$$$W$TH$! `
Wi.~!X$?!-~    : ?$$$B$Wu(""**$RM!
$R@i.~~ !     :   ~$$$$$B$$en:``
?MXT@Wx.~    :     ~""##*$$$$M~
");
                Console.ResetColor();
            }
            else if(monster.MonsterType == "Snake")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(@"
       ---_ ......._-_--.
      (|\ /      / /| \  \
      /  /     .'  -=-'   `.
     /  /    .'             )
   _/  /   .'        _.)   /
  / o   o        _.-' /  .'
  \          _.-'    / .'*|
   \______.-'//    .'.' \*|
    \|  \ | //   .'.' _ |*|
     `   \|//  .'.'_ _ _|*|
      .  .// .'.' | _ _ \*|
      \`-|\_/ /    \ _ _ \*\
       `/'\__/      \ _ _ \*\
      /^|            \ _ _ \*\
     '  `             \ _ _ \ \
                       \ ______\
");
                Console.ResetColor();
            }
            else if (monster.MonsterType == "Barbarian")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(@"
                           ,-----.
                         /'       `\
                        ; ----,---- ;
                        | `o- |`o-  |
                        |     |_    |
                        |   _____,  |
                         \_       _/
                         | `-----' |
                     __.-;         ;-.__
                 _,-'    ; :     ; ;    `-._
              _,'                           `.
            ,`-,_____     \ :   : /     ____,-'-,
          /'         ```----.   .----'''         `\
         /                   \_/                   \
        |                     |                     |
        |        ,            |            ,        |
        |        |            |            |        |
        |        \            |            /        |
        \        /\   o       |      o    /\       /
        /       | |`\        / \        /'| |      \
        |       | |  `------'   `------'  | |      |
        |       | \      _.--'|`--._      / |      |
        \       |  |    __|--'|`--|__    |  |      /
         |      |  |    __|--'|`--|__    |  |     |
");
                Console.ResetColor();
            }
            else if (monster.MonsterType == "Goblin")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(@"
             ,      ,
            /(.-""-.)\
        |\  \/      \/  /|
        | \ / =.  .= \ / |
        \( \   o\/o   / )/
         \_, '-/  \-' ,_/
           /   \__/   \
           \ \__/\__/ /
         ___\ \|--|/ /___
       /`    \      /    `\
      /       '----'       \
");
                Console.ResetColor();
            }
            else if (monster.MonsterType == "Zombie")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(@"
⠀⠀⠀⠀⠀⠀⠀⠀⢀⡠⠖⠊⠉⠉⠉⠉⢉⠝⠉⠓⠦⣄⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢀⡴⣋⠀⠀⣤⣒⡠⢀⠀⠐⠂⠀⠤⠤⠈⠓⢦⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣰⢋⢬⠀⡄⣀⠤⠄⠀⠓⢧⠐⠥⢃⣴⠤⣤⠀⢀⡙⣆⠀⠀⠀⠀
⠀⠀⠀⠀⢠⡣⢨⠁⡘⠉⠀⢀⣤⡀⠀⢸⠀⢀⡏⠑⠢⣈⠦⠃⠦⡘⡆⠀⠀⠀
⠀⠀⠀⠀⢸⡠⠊⠀⣇⠀⠀⢿⣿⠇⠀⡼⠀⢸⡀⠠⣶⡎⠳⣸⡠⠃⡇⠀⠀⠀
⢀⠔⠒⠢⢜⡆⡆⠀⢿⢦⣤⠖⠒⢂⣽⢁⢀⠸⣿⣦⡀⢀⡼⠁⠀⠀⡇⠒⠑⡆
⡇⠀⠐⠰⢦⠱⡤⠀⠈⠑⠪⢭⠩⠕⢁⣾⢸⣧⠙⡯⣿⠏⠠⡌⠁⡼⢣⠁⡜⠁
⠈⠉⠻⡜⠚⢀⡏⠢⢆⠀⠀⢠⡆⠀⠀⣀⣀⣀⡀⠀⠀⠀⠀⣼⠾⢬⣹⡾⠀⠀
⠀⠀⠀⠉⠀⠉⠀⠀⠈⣇⠀⠀⠀⣴⡟⢣⣀⡔⡭⣳⡈⠃⣼⠀⠀⠀⣼⣧⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⠀⠀⣸⣿⣿⣿⡿⣷⣿⣿⣷⠀⡇⠀⠀⠀⠙⠊⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣠⠀⢻⠛⠭⢏⣑⣛⣙⣛⠏⠀⡇⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡏⠠⠜⠓⠉⠉⠀⠐⢒⡒⡍⠐⡇⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠒⠢⠤⣀⣀⣀⣀⣘⠧⠤⠞⠁⠀⠀⠀⠀⠀⠀⠀
");
                Console.ResetColor();
            }
            else if(monster.MonsterType == "Witch")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(@"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣶⣿⣿⣿⣿⣦⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⣿⣟⣿⣿⣶⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⡀⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⣿⣿⣿⣿⣶⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡤⠔⠚⠋⠉⢡⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⢿⣿⣿⣿⣿⣦⣤⣀⠀⠀⣠⡀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣴⣶⣤⣀⡀⠀⠀⠀⠀⢀⡠⠖⠋⠁⠀⠀⠀⠀⣴⣿⣏⣿⣿⣿⣿⣼⣿⣿⣿⣿⣿⣿⣿⣦⣼⣿⡟⢿⣿⣿⣿⣿⣿⣿⡿⠟⠋⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⠿⣿⣷⣦⣤⣬⣄⣀⣀⣀⣀⣀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡍⣿⣿⣿⡿⣿⡆⠀⠀⠙⢯⣉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣿⣛⣿⣿⢿⡝⡛⠿⣿⣿⢸⡝⣿⣿⣿⡇⠀⠀⠀⠀⢩⣶⣆⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⡛⣻⣿⣿⣿⣿⣿⣿⣻⣿⣿⣿⣾⣯⣽⣿⣷⣘⣿⣧⣴⡾⣯⣿⢧⣿⣿⣿⡇⠀⠀⠀⢀⡀⠙⠏⢧⡀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⣿⣿⣟⣿⠿⢿⣿⣻⣿⣛⣿⣿⡇⠀⠀⠀⣸⣷⠀⠀⠀⠳⡄⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⣻⣿⣿⣿⣽⣿⣿⣿⣿⣿⣿⡆⠙⠻⣅⣨⠟⠒⠀⠀⠹⡄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣀⢿⣿⣿⣿⣿⣿⣿⠟⠋⠈⢙⣻⣿⣿⣿⣿⣿⣿⣿⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⡀⠀⠸⠃⠀⠴⡷⠄⠀⠸⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢰⡇⠈⢿⣿⣿⠟⠋⣠⡴⢚⣫⠽⠛⠉⠉⠛⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⣄⡀⠀⠀⠀⠀⠀⢳⠀⣤⠀⠀⠀
⠀⠀⠀⠀⠀⡾⠀⠀⢨⡟⠁⣠⠞⣡⠞⠉⠀⠀⠀⠀⠀⠀⢀⣀⡴⠞⣻⣿⣻⠿⣿⣿⣿⣿⣿⣿⣿⣞⣿⣿⣿⣿⣿⣿⣿⣿⣟⡿⣿⣷⣶⣤⣄⣀⣀⠇⠘⠀⠀⠀
⠀⣠⣷⣤⢀⡇⠘⢀⣿⠁⣰⠃⡼⠋⠀⠀⠀⢀⣀⠤⠴⠚⠉⣀⣴⣿⣷⣬⡝⠀⠀⠀⠙⣻⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⡄
⠀⠈⠿⠁⢸⠃⠀⢸⢧⠀⡇⣸⠃⠀⢀⣴⠞⠉⠁⢀⣤⠔⠟⡏⠻⢮⡭⠿⠃⠀⠀⠀⠘⠿⣭⣭⡿⢿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀
⠀⠷⠀⠀⢸⠀⠀⣸⣾⢇⣷⡇⠀⡴⢋⣀⣠⠶⠊⠁⠀⢀⣶⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⠃⡋⠙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⡿⠁⠀
⠀⠀⠀⣴⢸⡀⠀⢿⣸⡯⠙⢿⣼⣧⡿⠋⠀⠀⠀⠀⢀⣴⢯⣿⠀⠀⠀⠀⠀⠒⠄⠂⠀⠀⠀⠀⠀⣼⠀⡇⠀⠀⢇⣠⠿⢻⣫⠀⠙⣿⣆⠛⣿⣿⣿⣿⠟⠀⠀⠀
⠀⠀⣸⢿⣌⡇⠀⠈⣷⣙⣦⣈⣹⠏⠀⠀⠀⢀⡤⠖⡽⢣⠏⢹⣇⠀⠀⠐⢶⣿⣿⣷⡶⠂⠀⠀⡼⠹⡄⠘⣆⣠⠚⠁⠀⢸⢿⡇⠀⢹⣿⡆⢹⡿⠛⣵⠀⠀⠀⠀
⠈⠻⢧⢀⡽⢿⠓⠀⣇⠈⠙⠺⣏⠀⢀⣴⠞⠉⣠⢎⡵⠋⠀⣸⣿⣷⣄⠀⠀⠉⠛⠉⠀⠀⣠⣾⠁⠀⠙⣶⡞⠁⠀⠀⢀⡞⢸⡇⠀⢸⣟⣿⠏⠀⢀⡇⠀⠀⠀⠀
⠀⠀⠸⡿⠀⠸⣇⠀⠈⢳⣤⣀⢹⣄⡾⠁⢠⠊⣰⠋⠀⠀⢠⠏⡏⢿⣿⣷⡦⣤⣀⣤⠴⢋⣽⣼⡄⠀⣼⡏⠀⠀⢀⡠⢞⣠⠏⠀⠀⣸⠃⠀⠀⣰⣿⡀⠀⠀⠀⠀
⠀⠀⠀⠉⣴⣤⣽⡄⠀⠈⠙⣿⣿⡟⣇⠀⣿⡞⠁⠀⠀⢠⠏⢀⣧⡿⣿⣿⣿⣷⣶⣶⣿⣿⣿⣿⣷⣾⣹⠀⣠⠴⠟⣺⣿⠁⢀⣠⠞⠁⡀⠈⠛⣿⣿⠛⠃⠀⠀⠀
⠀⠀⠀⠀⠈⠀⠀⠻⡄⠀⣼⡟⣿⣇⠙⢦⣿⠀⠀⢀⠴⠁⢠⡾⠏⢹⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣤⣌⣿⡞⠁⣀⠔⢁⡿⠛⠉⠁⠀⢾⡷⠤⣰⠏⠃⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢀⠹⣆⠻⣷⢹⡈⠳⣄⣹⠀⢰⠏⣠⠞⠋⠀⠀⢸⢠⣿⣿⣿⣿⣿⣿⣿⣿⣽⣿⣿⢿⣿⣿⣷⣶⣯⣄⠀⢠⡄⠀⠈⠃⡴⠃⠐⠗⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠈⠀⠘⢶⡈⢳⣌⠢⢀⣉⣷⣯⡾⠁⠀⠀⠀⢀⣼⣿⣿⣿⣟⠛⣿⣿⣿⣿⣿⣿⣟⣷⡿⢿⣿⣿⣿⣿⣧⠀⠀⠀⣠⠞⠁⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⢦⡈⠓⠒⠤⠬⣿⣇⠀⠀⠀⣴⣿⣿⣿⣿⣷⣻⣿⣳⣿⣿⣿⣿⣿⣯⣵⣾⣿⣿⣿⡿⠿⠛⠀⣠⠾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢦⣄⣰⡀⠈⠻⣶⣴⣞⡵⠛⣉⣉⣉⠛⣿⣾⠻⣿⣿⣿⣿⣿⣿⣿⠿⠛⠋⠁⠀⢀⣤⠞⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠲⢾⡇⣻⣶⡀⠈⡿⢯⡛⠿⠶⣤⡙⢿⣾⣿⠿⣿⠿⠿⠟⠋⠁⠀⠀⠃⢀⣠⠶⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⠁⠀⠉⠓⠹⢬⣻⣷⡦⡄⢹⣿⠀⠀⠀⠀⠀⠀⣀⣀⣠⠤⠖⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠙⣿⣸⠃⠛⠒⠒⠛⠉⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
");
                Console.ResetColor();
            }
        }
        public void DragonArt(ref Character player)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($@"
                                                           _   __,----'~~~~~~~~~`-----.__
                                        .  .    `//====-              ____,-'~`
                        -.            \_|// .   /||\\  `~~~~`---.___./
                  ______-==.       _-~o  `\/    |||  \\           _,'`
            __,--'   ,=='||\=_    ;_,_,/ _-'|-   |`\   \\        ,'
         _-'      ,='    | \\`.    '',/~7  /-   /  ||   `\.     /
       .'       ,'       |  \\  \_  ""  /  /-   /   ||      \   /
      / _____  /         |     \\.`-_/  /|- _/   ,||       \ /
     ,-'     `-|--'~~`--_ \     `==-/  `| \'--===-'       _/`
               '         `-|      /|    )-'\~'      _,--""'
                           '-~^\_/ |    |   `\_   ,^             /\
                                /  \     \__   \/~               `\__
                            _,-' _/'\ ,-'~____-'`-/                 ``===\
           ({player.Name})        ((->/'    \|||' `.     `\.  ,                _||
             ./                       \_     `\      `~---|__i__i__\--~'_/
            <_n_                     __-^-_    `)  \-.______________,-~'
             `B'\)                  ///,-'~`__--^-  |-------~~~~^'
             /^>                           ///,--~`-\
            `  `                                       
");
            Console.ResetColor();
        }
        public void KnightArt()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
                   _.--.    .--._
                 .""  .""      "".  "".
                ;  .""    /\    "".  ;
                ;  '._,-/  \-,_.`  ;
                \  ,`  / /\ \  `,  /
                 \/    \/  \/    \/
                 ,=_    \/\/    _=,
                 |  ""_   \/   _""  |
                 |_   '""-..-""'   _|
                 | ""-.        .-"" |
                 |    ""\    /""    |
                 |      |  |      |
         ___     |      |  |      |     ___
     _,-"",  "",   '_     |  |     _'   ,""  ,""-,_
   _(  \  \   \""=--""-.  |  |  .-""--=""/   /  /  )_
 ,""  \  \  \   \      ""-'--'-""      /   /  /  /  "".
!     \  \  \   \                  /   /  /  /     !
:      \  \  \   \                /   /  /  /      ||

");
            Console.ResetColor();
        }
        public void PrintChest()
        {
            Console.WriteLine(@"
          |                   |                  |                     |
 _________|________________.=""""_;=.______________|_____________________|_______
|                   |  ,-""_,=""""     `""=.|                  |
|___________________|__""=._o`""-._        `""=.______________|___________________
          |                `""=._o`""=._      _`""=._                     |
 _________|_____________________:=._o ""=._.""_.-=""'""=.__________________|_______
|                   |    __.--"" , ; `""=._o."" ,-""""""-._ "".   |
|___________________|_._""  ,. .` ` `` ,  `""-._""-._   "". '__|___________________
          |           |o`""=._` , ""` `; ."". ,  ""-._""-._; ;              |
 _________|___________| ;`-.o`""=._; ."" ` '`.""\` . ""-._ /_______________|_______
|                   | |o;    `""-.o`""=._``  '` "" ,__.--o;   |
|___________________|_| ;     (#) `-.o `""=.`_.--""_o.-; ;___|___________________
____/______/______/___|o;._    ""      `"".o|o_.--""    ;o;____/______/______/____
/______/______/______/_""=._o--._        ; | ;        ; ;/______/______/______/_
____/______/______/______/__""=._o--._   ;o|o;     _._;o;____/______/______/____
/______/______/______/______/____""=._o._; | ;_.--""o.--""_/______/______/______/_
____/______/______/______/______/_____""=.o|o_.--""""___/______/______/______/____
");
        }
        public void PrintGameTitle()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(@"
_________ _______          _________ _______  _        _______  _______  _______ __________________ _______  _       
\__   __/(  ____ \|\     /|\__   __/(  ____ )( \      (  ___  )(  ____ )(  ___  )\__   __/\__   __/(  ___  )( (    /|
   ) (   | (    \/( \   / )   ) (   | (    )|| (      | (   ) || (    )|| (   ) |   ) (      ) (   | (   ) ||  \  ( |
   | |   | (__     \ (_) /    | |   | (____)|| |      | |   | || (____)|| (___) |   | |      | |   | |   | ||   \ | |
   | |   |  __)     ) _ (     | |   |  _____)| |      | |   | ||     __)|  ___  |   | |      | |   | |   | || (\ \) |
   | |   | (       / ( ) \    | |   | (      | |      | |   | || (\ (   | (   ) |   | |      | |   | |   | || | \   |
   | |   | (____/\( /   \ )   | |   | )      | (____/\| (___) || ) \ \__| )   ( |   | |   ___) (___| (___) || )  \  |
   )_(   (_______/|/     \|   )_(   |/       (_______/(_______)|/   \__/|/     \|   )_(   \_______/(_______)|/    )_)
");
            Console.ResetColor();
        }
        public void PrintEquipment()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(@"
 _______  _______          _________ _______  _______  _______  _       _________
(  ____ \(  ___  )|\     /|\__   __/(  ____ )(       )(  ____ \( (    /|\__   __/
| (    \/| (   ) || )   ( |   ) (   | (    )|| () () || (    \/|  \  ( |   ) (   
| (__    | |   | || |   | |   | |   | (____)|| || || || (__    |   \ | |   | |   
|  __)   | |   | || |   | |   | |   |  _____)| |(_)| ||  __)   | (\ \) |   | |   
| (      | | /\| || |   | |   | |   | (      | |   | || (      | | \   |   | |   
| (____/\| (_\ \ || (___) |___) (___| )      | )   ( || (____/\| )  \  |   | |   
(_______/(____\/_)(_______)\_______/|/       |/     \|(_______/|/    )_)   )_(   
                                                                                 
");
            Console.ResetColor();
        }
        public void PrintWeaponBox(ref Character character)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string weaponName = character.CurrentWeapon != null ? character.CurrentWeapon.ItemName : "No weapon equipped";
            string armorName = character.CurrentArmor != null ? character.CurrentArmor.ItemName : "No armor equipped";

            string messageWeapon = $"Current weapon: {weaponName}";
            string messageArmor = $"Current armor: {armorName}";
            string messagePrompt = "(\"m\" to open equipment inventory)";

            // Determine the widest line to make the box fit all lines nicely
            int boxWidth = Math.Max(Math.Max(messageWeapon.Length, messageArmor.Length), messagePrompt.Length) + 4;

            string top = "╔" + new string('═', boxWidth - 2) + "╗";
            string middleWeapon = "║ " + messageWeapon.PadRight(boxWidth - 4) + " ║";
            string middleArmor = "║ " + messageArmor.PadRight(boxWidth - 4) + " ║";
            string middlePrompt = "║ " + messagePrompt.PadRight(boxWidth - 4) + " ║";
            string bottom = "╚" + new string('═', boxWidth - 2) + "╝";

            Console.WriteLine(top);
            Console.WriteLine(middleWeapon);
            Console.WriteLine(middleArmor);
            Console.WriteLine(middlePrompt);
            Console.WriteLine(bottom);
            Console.ResetColor();
        }
        public void EquipmentChoice()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Needed for box-drawing characters

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("╔═══════════════════╗\t╔═══════════════════╗");
            Console.WriteLine("║     1. Weapon     ║\t║     2. Armor      ║");
            Console.WriteLine("╚═══════════════════╝\t╚═══════════════════╝");
            Console.ResetColor();
        }
        void LocationNameSafeTown()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Needed for box-drawing characters

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║     Current World: Safe Town       ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();
        }
        void LocationNameForest()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Needed for box-drawing characters

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║     Current World: Wicked Forest   ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();
        }
        void LocationNameMountains()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Needed for box-drawing characters

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║     Current World: Rocky Mountains ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();
        }
        void LocationNameBossCastle()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Needed for box-drawing characters

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║     Current World: Boss Castle     ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();
        }
        public void EquipmentInventory(ref Character character)
        {
            Console.Clear();

            if (!character.Items.Any(item => item.Type == "Weapon" || item.Type == "Armor"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Looks like you have no weapons nor armors in your inventory yet...");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }
            else
            {
                while (true)
                {
                    Console.Clear();
                    PrintEquipment();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"(""q"" to exit)" + "\n");
                    Console.ResetColor();
                    EquipmentChoice();
                    Console.Write("\nChoice: ");
                    string choice = Console.ReadLine();

                    if (choice == "q")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nExiting equipment inventory...");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    }

                    if (!int.TryParse(choice, out int outChoice))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nError, please input a valid number\n");
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }

                    if (outChoice == 1) // weapon
                    {
                        Console.Clear();
                        PrintEquipment();
                        if (character.Items.Any(item => item.Type == "Weapon"))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write($"Current Weapon: ");
                            if(character.CurrentWeapon == null)
                            {
                                Console.WriteLine("(No weapon eqipped)");
                            }
                            else
                            {
                                Console.WriteLine(character.CurrentWeapon.ItemName);
                            }
                            
                            Console.WriteLine("Change to another weapon\n");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(@"(""q"" to exit)");
                            Console.ResetColor();

                            var weaponList = from item in character.Items
                                             where item.Type == "Weapon"
                                             select item;

                            var weaponOnly = character.Items.Where(item => item.GetType() == typeof(Weapon)).ToList();

                            Console.WriteLine("\nAll your weapons");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("------------------------------------------------------------------------------------------------");
                            int i = 0;
                            foreach (var item in weaponList)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine($"{i + 1}. ||\t{item.ItemName}\t||\t{item.Type}\t|| Bonus (Atk): {item.HealBonus}\t||");
                                i++;
                            }
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("------------------------------------------------------------------------------------------------");
                            Console.ResetColor();

                            Console.Write("Choice: ");
                            string choice2 = Console.ReadLine();
                            if (choice2 == "q")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nExiting equipment inventory...");
                                Console.ResetColor();
                                Console.ReadKey();
                                continue;
                            }

                            if (!int.TryParse(choice2, out int outChoice2) && choice2 != "q")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nError, please input a valid number\n");
                                Console.WriteLine("\n(Press any key to coninue)");
                                Console.ResetColor();
                                Console.ReadKey();
                                continue;
                            }

                            Console.WriteLine();

                            if (outChoice2 > 0 && outChoice2 <= weaponOnly.Count && choice2 != "q" && choice2 != "m")
                            {
                                var selectedItem = weaponOnly[outChoice2 - 1];
                                if(selectedItem is Weapon weapon)
                                {
                                    if (character.CurrentWeapon == null)
                                    {
                                        character.CurrentWeapon = weapon;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"You just equipped {weapon.ItemName} as your new weapon!");
                                        Console.ResetColor();
                                        character.Items.Remove(weapon);
                                        character.Atk += weapon.AttackBonus;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine($"You currently have ({character.CurrentWeapon.ItemName} - ATK: {character.CurrentWeapon.AttackBonus}) eqipped as your current weapon");
                                        Console.Write($"Are you sure you want to switch it for ({weapon.ItemName})? (y/n): ");
                                        string playerAnswer = Console.ReadLine();

                                        if(playerAnswer == "y")
                                        {
                                            Console.WriteLine("Switching weapons...");
                                            character.AddToInventory(character.CurrentWeapon);
                                            character.Atk -= character.CurrentWeapon.AttackBonus;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You just equipped {weapon.ItemName} as your new weapon!");
                                            Console.ResetColor();
                                            character.CurrentWeapon = weapon;
                                            character.Items.Remove(weapon);
                                            character.Atk += weapon.AttackBonus;
                                        }
                                        else if(playerAnswer == "n")
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Cancelling weapon swap...");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid input. Please try again!");
                                            Console.ResetColor();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nLooks like you do not have any weapons yet...");
                            Console.ResetColor();
                            Console.ReadKey();
                            break;
                        }
                        
                    }
                    else if (outChoice == 2) // armor
                    {
                        Console.Clear();
                        PrintEquipment();
                        if (character.Items.Any(item => item.Type == "Armor"))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write($"Current Armor: ");
                            if (character.CurrentArmor == null)
                            {
                                Console.WriteLine("(No armor eqipped)");
                            }
                            else
                            {
                                Console.WriteLine(character.CurrentArmor.ItemName);
                            }

                            Console.WriteLine("Change to another armor\n");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(@"(""q"" to exit)");
                            Console.ResetColor();

                            var weaponList = from item in character.Items
                                             where item.Type == "Armor"
                                             select item;

                            var weaponOnly = character.Items.Where(item => item.GetType() == typeof(Armor)).ToList();

                            Console.WriteLine("\nAll your armors");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("------------------------------------------------------------------------------------------------");
                            int i = 0;
                            foreach (var item in weaponList)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine($"{i + 1}. ||\t{item.ItemName}\t||\t{item.Type}\t|| Bonus (Def): {item.HealBonus}\t||");
                                i++;
                            }
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("------------------------------------------------------------------------------------------------");
                            Console.ResetColor();

                            Console.Write("Choice: ");
                            string choice2 = Console.ReadLine();
                            if (choice2 == "q")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nExiting equipment inventory...");
                                Console.ResetColor();
                                Console.ReadKey();
                                continue;
                            }

                            if (!int.TryParse(choice2, out int outChoice2) && choice2 != "q")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nError, please input a valid number\n");
                                Console.WriteLine("\n(Press any key to coninue)");
                                Console.ResetColor();
                                Console.ReadKey();
                                continue;
                            }

                            Console.WriteLine();

                            if (outChoice2 > 0 && outChoice2 <= weaponOnly.Count && choice2 != "q" && choice2 != "m")
                            {
                                var selectedItem = weaponOnly[outChoice2 - 1];
                                if (selectedItem is Armor weapon)
                                {
                                    if (character.CurrentArmor == null)
                                    {
                                        character.CurrentArmor = weapon;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"You just equipped {weapon.ItemName} as your new armor!");
                                        Console.ResetColor();
                                        character.Items.Remove(weapon);
                                        character.Def += weapon.DefenseBonus;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine($"You currently have ({character.CurrentArmor.ItemName} - DEF: {character.CurrentArmor.DefenseBonus}) eqipped as your current armor");
                                        Console.Write($"Are you sure you want to switch it for ({weapon.ItemName})? (y/n): ");
                                        string playerAnswer = Console.ReadLine();

                                        if (playerAnswer == "y")
                                        {
                                            Console.WriteLine("Switching armors...");
                                            character.AddToInventory(character.CurrentArmor);
                                            character.Def -= character.CurrentArmor.DefenseBonus;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You just equipped {weapon.ItemName} as your new armor!");
                                            Console.ResetColor();
                                            character.CurrentArmor = weapon;
                                            character.Items.Remove(weapon);
                                            character.Def += weapon.DefenseBonus;
                                        }
                                        else if (playerAnswer == "n")
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Cancelling armor swap...");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid input. Please try again!");
                                            Console.ResetColor();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nLooks like you do not have any armors yet...");
                            Console.ResetColor();
                            Console.ReadKey();
                            break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
        public void RareLootCrate(ref Character character)
        {
            Random random = new Random();

            // Select a random item from the common loot pool
            Item randomItem = _rareLootPool[random.Next(_rareLootPool.Count)];

            // Add the item to the player's inventory
            character.AddToInventory(randomItem);

            Console.Clear();
            PrintGameTitle();
            LocationNameMountains();
            Console.WriteLine();
            // Check the type of the item and print a different message
            if (randomItem.Type == "Weapon")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                PrintChest();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"You found a rare weapon: {randomItem.ItemName} (ATK: {randomItem.HealBonus})! It looks powerful.");
            }
            else if (randomItem.Type == "Armor")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                PrintChest();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"You found a rare piece of armor: {randomItem.ItemName} (DEF: {randomItem.HealBonus})! It offers great protection.");
            }
            else if (randomItem.Type == "Consumable")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                PrintChest();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"You found a rare consumable: {randomItem.ItemName} (Heal: {randomItem.HealBonus})! It might come in handy.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                PrintChest();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"You found a rare item: {randomItem.ItemName}! It's quite unique.");
            }

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n(Press any key to continue)");
            Console.ResetColor();
            Console.ReadKey();
        }
        public void StrongFightEncounter(ref Character character)
        {
            Random random = new Random();
            // Select a random monster from the pool
            Monsters randomMonsterTemplate = _strongMonsterPool[random.Next(_strongMonsterPool.Count)];

            // Clone the monster so we do not touch any original values 
            Monsters randomMonster = randomMonsterTemplate.CreateCloneInstance();

            Console.Clear();
            PrintGameTitle();
            LocationNameMountains();
            Console.WriteLine();
            KnightArt();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You just stumbled with a {randomMonster.MonsterName}!");
            Console.WriteLine("Watch out! This monsters are stronger than before!");
            Console.WriteLine("\n(Press any key to coninue)");
            Console.ResetColor();
            Console.ReadKey();

            while (true)
            {
                Console.Clear();
                PrintGameTitle();
                LocationNameMountains();
                PrintBanner(ref character);
                PrintWeaponBox(ref character);
                MonsterToArt(ref randomMonster);
                PrintBannerWithMonsterStats(ref character, randomMonster);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\t\t\tWhat would you like to do?\n");
                Console.Write("||\t1. Attack\t||\t2. Use heals\t||");
                if (character.CanFlee)
                {
                    Console.WriteLine("\t3. Flee\t\t||");
                }
                Console.ResetColor();

                Console.Write("\nChoice: ");

                string inputChoice = Console.ReadLine();

                if (inputChoice == "m")
                {
                    EquipmentInventory(ref character);
                }

                if (!int.TryParse(inputChoice, out int choice) && inputChoice != "m")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nError, please input a valid number\n");
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                if (choice == 1 && inputChoice != "m")
                {
                    if (character.CurrentHp <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You are too weak to fight. Please heal yourself.");
                        Console.WriteLine("Going back...");
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    }

                    int attackDamage = Math.Max(character.Atk - randomMonster.MonstersDefense, 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nYou attacked {randomMonster.MonsterName} dealing a total of {attackDamage}");
                    Console.ResetColor();
                    randomMonster.MonstersHp -= attackDamage;

                    if (randomMonster.MonstersHp <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"You defeated the {randomMonster.MonsterName}!");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"You earned {randomMonster.GoldDropped} gold!");
                        character.CurrentGold += randomMonster.GoldDropped;
                        Console.ForegroundColor = ConsoleColor.Green;
                        character.CanFlee = true;
                        if (randomMonster is Skeleton skeleton)
                        {
                            skeleton.MonsterAtk = skeleton.OriginalAtk;
                        }
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    }

                    // Monster's turn
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nThe {randomMonster.MonsterName} is preparing to attack!\n");
                    Console.ResetColor();

                    // 70/30 for monster attacks
                    int chance = random.Next(10);   // creates a random number from 0 to 9
                    if (chance < 7) //70% (0 - 6) for Basic Attack
                    {
                        // Basic Attack
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"The {randomMonster.MonsterName} uses a Basic Attack!");
                        Console.ResetColor();
                        randomMonster.BasicAttack(ref character);
                    }
                    else // 30% special attack in case of (7 - 9)
                    {
                        randomMonster.SpecialAttack(ref character);
                    }

                    // check if player died
                    if (character.CurrentHp <= 1)
                    {
                        Console.Clear();
                        LocationNameForest();
                        PrintBanner(ref character);
                        PrintWeaponBox(ref character);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYou have been defeated...");
                        Console.WriteLine("You lost 50% of your gold!");
                        int minusGold = character.CurrentGold / 2;
                        character.CurrentGold -= minusGold;
                        character.CanFlee = true;
                        if (randomMonster is Skeleton skeleton)
                        {
                            skeleton.MonsterAtk = skeleton.OriginalAtk;
                        }
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    }
                }
                else if (choice == 2 && inputChoice != "m")
                {
                    // use healing logic
                    //var healingItems = from item in character.Items
                    //                  where item.Type == "Consumable"
                    //                  select item;

                    //switch to a one line LINQ to be able to use .Count
                    var healingItems = character.Items.Where(item => item.Type == "Consumable" && item.HealBonus > 0).ToList();

                    if (healingItems.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have no healing items!");
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Choose a healing item to use:");
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    for (int i = 0; i < healingItems.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"{i + 1}. {healingItems[i].ItemName} (Heals: {healingItems[i].HealBonus} HP)");
                    }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    Console.Write("Enter the number of the item you want to use: ");

                    // takes in a string and convers it to int (healingChoice) and checks if the choice made is withing correct parameters
                    if (int.TryParse(Console.ReadLine(), out int healingChoice) && healingChoice > 0 && healingChoice <= healingItems.Count)
                    {
                        // map the selected item
                        var selectedItem = healingItems[healingChoice - 1];

                        // Heal the player
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"You used a {selectedItem.ItemName} and restored {selectedItem.HealBonus} HP!");
                        //Math.Min ensures that we do not heal the player over the MaxHp
                        character.CurrentHp = Math.Min(character.MaxHp, character.CurrentHp + selectedItem.HealBonus);
                        selectedItem.Quantity--;

                        // Remove the item if its quantity reaches 0
                        if (selectedItem.Quantity <= 0)
                        {
                            character.Items.Remove(selectedItem);
                        }
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ResetColor();
                    }
                }
                else if (choice == 3 && character.CanFlee && inputChoice != "m" )
                {
                    // Flee logic
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You fled the fight!");
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n(Press any key to coninue)");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        public void LootCrate(ref Character character)
        {
            Random random = new Random();

            // Select a random item from the common loot pool
            Item randomLoot = _commonLootPool[random.Next(_commonLootPool.Count)];

            // Add the item to the player's inventory
            character.AddToInventory(randomLoot);

            // Display the loot to the player
            Console.Clear();
            PrintGameTitle();
            LocationNameForest();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintChest();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You found a common loot crate and received: {randomLoot.ItemName}!");
            Console.WriteLine($"(Quantity: {randomLoot.Quantity}, Heals: {randomLoot.HealBonus} HP)");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n(Press any key to continue)");
            Console.ResetColor();
            Console.ReadKey();
        }
        public void PrintBannerWithMonsterStats(ref Character character, Monsters monster)
        {
            // Print the player's stats
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Player: {character.Name,-15} | HP: {character.CurrentHp,-5} | ATK: {character.Atk,-5} | DEF: {character.Def,-5} | Gold: {character.CurrentGold,-5}");
            Console.ResetColor();
            Console.WriteLine("\t---------------------------vs---------------------------");
            // Print the monster's stats aligned with the player's stats
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Monster: {monster.MonsterName,-15}| HP: {monster.MonstersHp,-5} | ATK: {monster.MonsterAtk,-5} | DEF: {monster.MonstersDefense,-5} | Gold Value: {monster.GoldDropped,-5}");
            Console.ResetColor();
        }
        public void FightEncounter(ref Character character)
        {
            Random random = new Random();
            // Select a random monster from the pool
            Monsters randomMonsterTemplate = _weakMonstersPool[random.Next(_weakMonstersPool.Count)];

            // Clone the monster so we do not touch any original values 
            Monsters randomMonster = randomMonsterTemplate.CreateCloneInstance();

            Console.Clear();
            PrintGameTitle();
            LocationNameForest();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            KnightArt();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You just stumbled with a {randomMonster.MonsterName}!");
            Console.WriteLine("Watch out! they hit hard, good luck!");
            Console.WriteLine("\n(Press any key to coninue)");
            Console.ResetColor();
            Console.ReadKey();

            while (true)
            {
                Console.Clear();

                PrintGameTitle();
                LocationNameForest();
                PrintBanner(ref character);
                PrintWeaponBox(ref character);
                MonsterToArt(ref randomMonster);
                PrintBannerWithMonsterStats(ref character, randomMonster);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\t\t\tWhat would you like to do?\n");
                Console.Write("||\t1. Attack\t||\t2. Use heals\t||");
                if(character.CanFlee)
                {
                    Console.WriteLine("\t3. Flee\t\t||");
                }
                Console.ResetColor();

                Console.Write("\nChoice: ");

                string inputChoice = Console.ReadLine();

                if (inputChoice == "m")
                {
                    EquipmentInventory(ref character);
                }

                if (!int.TryParse(inputChoice, out int choice) && inputChoice != "m")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nError, please input a valid number\n");
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                if (choice == 1)
                {
                    if (character.CurrentHp <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You are too weak to fight. Please heal yourself.");
                        Console.WriteLine("Going back...");
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    }

                    int attackDamage = Math.Max(character.Atk - randomMonster.MonstersDefense, 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nYou attacked {randomMonster.MonsterName} dealing a total of {attackDamage}");
                    Console.ResetColor();
                    randomMonster.MonstersHp -= attackDamage;

                    if (randomMonster.MonstersHp <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"You defeated the {randomMonster.MonsterName}!");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"You earned {randomMonster.GoldDropped} gold!");
                        character.CurrentGold += randomMonster.GoldDropped;
                        Console.ForegroundColor = ConsoleColor.Green;
                        character.CanFlee = true;
                        if (randomMonster is Skeleton skeleton)
                        {
                            skeleton.MonsterAtk = skeleton.OriginalAtk;
                        }
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    }

                    // Monster's turn
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nThe {randomMonster.MonsterName} is preparing to attack!\n");
                    Console.ResetColor();

                    // 70/30 for monster attacks
                    int chance = random.Next(10);   // creates a random number from 0 to 9
                    if (chance < 7) //70% (0 - 6) for Basic Attack
                    {
                        // Basic Attack
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"The {randomMonster.MonsterName} uses a Basic Attack!");
                        Console.ResetColor();
                        randomMonster.BasicAttack(ref character);
                    }
                    else // 30% special attack in case of (7 - 9)
                    {
                        randomMonster.SpecialAttack(ref character);
                    }

                    // check if player died
                    if (character.CurrentHp <= 1)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nYou have been defeated...");
                        Console.WriteLine("You lost 50% of your gold!");
                        int minusGold = character.CurrentGold / 2;
                        character.CurrentGold -= minusGold;
                        character.CanFlee = true;
                        if (randomMonster is Skeleton skeleton)
                        {
                            skeleton.MonsterAtk = skeleton.OriginalAtk;
                        }
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    }
                }
                else if (choice == 2)
                {
                    // use healing logic
                    //var healingItems = from item in character.Items
                    //                  where item.Type == "Consumable"
                    //                  select item;

                    //switch to a one line LINQ to be able to use .Count
                    var healingItems = character.Items.Where(item => item.Type == "Consumable" && item.HealBonus > 0).ToList();

                    if (healingItems.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have no healing items!");
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Choose a healing item to use:");
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    for (int i = 0; i < healingItems.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"{i + 1}. {healingItems[i].ItemName} (Heals: {healingItems[i].HealBonus} HP)");
                    }
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    Console.Write("Enter the number of the item you want to use: ");

                    // takes in a string and convers it to int (healingChoice) and checks if the choice made is withing correct parameters
                    if (int.TryParse(Console.ReadLine(), out int healingChoice) && healingChoice > 0 && healingChoice <= healingItems.Count)
                    {
                        // map the selected item
                        var selectedItem = healingItems[healingChoice - 1];

                        // Heal the player
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"You used a {selectedItem.ItemName} and restored {selectedItem.HealBonus} HP!");
                        //Math.Min ensures that we do not heal the player over the MaxHp
                        character.CurrentHp = Math.Min(character.MaxHp, character.CurrentHp + selectedItem.HealBonus);
                        selectedItem.Quantity--;

                        // Remove the item if its quantity reaches 0
                        if (selectedItem.Quantity <= 0)
                        {
                            character.Items.Remove(selectedItem);
                        }
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ResetColor();
                    }
                }
                else if (choice == 3 && character.CanFlee)
                {
                    // Flee logic
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You fled the fight!");
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n(Press any key to coninue)");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        public void WeaponShop(ref Character character)
        {
            while (true)
            {
                Console.Clear();
                PrintWeaponShopTitle();
                PrintBanner(ref character);
                Console.WriteLine(@"Welcome to the equipment shop! Here are the available weapons & armor ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"(""q"" to exit)" + "\n");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                var equipmentOnly = _storeItems.Where(_storeItems => _storeItems.GetType() != typeof(Item)).ToList(); //print everything that is not Item, so armor and weapon

                for (int i = 0; i < equipmentOnly.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Quantity: {equipmentOnly[i].Quantity}\t||\t{equipmentOnly[i].ItemName}\t||\t{equipmentOnly[i].Type}\t||{equipmentOnly[i].Value} gold\t|| - Bonus (Atk or Def): {equipmentOnly[i].HealBonus}");
                }
                Console.ResetColor();

                Console.Write("\nPlease enter the number of the equipment you would like to buy: ");

                string choice = Console.ReadLine();

                if (choice == "q")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nExiting weapon shop...");
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }

                if (!int.TryParse(choice, out int outChoice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nError, please input a valid number\n");
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                if (outChoice > 0 && outChoice <= equipmentOnly.Count)
                {
                    var selectedItem = equipmentOnly[outChoice - 1];
                    if (selectedItem.Quantity > 0 && character.CurrentGold >= selectedItem.Value)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nYou have purchased: {selectedItem.ItemName}");
                        character.AddToInventory(selectedItem);
                        character.CurrentGold -= selectedItem.Value;
                        selectedItem.Quantity -= 1;
                        
                        if (selectedItem.Quantity <= 0)
                        {
                            _storeItems.Remove(selectedItem);
                        }

                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nSorry, {selectedItem.ItemName} is out of stock or not enough gold!");
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
        public void ItemShop(ref Character character)
        {
            while (true)
            {
                Console.Clear();
                PrintShopTitle();
                PrintBanner(ref character);
                Console.Write(@"Welcome to the item shop! Here are the available products ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"(""q"" to exit)" + "\n");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                var itemOnly = _storeItems.Where(_storeItems => _storeItems.GetType() == typeof(Item)).ToList();    // this is a one line LINQ function. It filters out the weapon and armor in our storeItems list.

                for (int i = 0; i < itemOnly.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Quantity: {itemOnly[i].Quantity} || {itemOnly[i].ItemName} || {itemOnly[i].Type} || {itemOnly[i].Value} gold || - Heals for ({itemOnly[i].HealBonus} HP)");
                }
                Console.ResetColor();
                Console.Write("\nPlease enter the number of the item you would like to buy: ");

                string choice = Console.ReadLine();

                if (choice == "q")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nExiting item shop...");
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }

                if (!int.TryParse(choice, out int outChoice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nError, please input a valid number\n");
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                if (outChoice > 0 && outChoice <= itemOnly.Count)
                {
                    Item selectedItem = itemOnly[outChoice - 1];
                    if (selectedItem.Quantity > 0 && character.CurrentGold >= selectedItem.Value)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nYou have purchased: {selectedItem.ItemName}");
                        character.AddToInventory(selectedItem);
                        character.CurrentGold -= selectedItem.Value;
                        selectedItem.Quantity -= 1;

                        if (selectedItem.Quantity <= 0)
                        {
                            _storeItems.Remove(selectedItem);
                        }

                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine($"\nSorry, {selectedItem.ItemName} is out of stock or not enough gold!");
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
        public void PrintInventory(ref Character character)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine($"{character.Name}'s Inventory:");
                Console.WriteLine("------------------------------------------------------------------------------------------------");

                // Group all items by name
                var groupedItems = character.Items
                    .GroupBy(item => item.ItemName)
                    .Select(group => new
                    {
                        Item = group.First(),
                        Count = group.Count()
                    });

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Total amount of items: {character.Items.Count}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.ResetColor();

                Console.WriteLine("Sort by:");
                Console.WriteLine("|| 1. Quantity || 2. Name || 3. Type ||");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n(\"q\" to exit)\n");
                Console.ResetColor();
                Console.Write("\nChoice: ");

                string choice = Console.ReadLine();

                if (choice == "q")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nExiting inventory...");
                    Console.WriteLine("\n(Press any key to continue)");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }

                if (!int.TryParse(choice, out int outChoice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nError, please input a valid number\n");
                    Console.WriteLine("(Press any key to continue)");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                // Sort items using LINQ
                var sortedItems = groupedItems;
                if (outChoice == 1)
                {
                    sortedItems = groupedItems.OrderByDescending(x => x.Count);
                }
                else if (outChoice == 2)
                {
                    sortedItems = groupedItems.OrderBy(x => x.Item.ItemName);
                }
                else if (outChoice == 3)
                {
                    sortedItems = groupedItems.OrderBy(x => x.Item.Type);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice.");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                // Print sorted results
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nSorted Inventory:");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                foreach (var entry in sortedItems)
                {
                    var item = entry.Item;
                    int quantity = entry.Count;

                    if (item is Weapon weapon)
                    {
                        Console.WriteLine($"|| Weapon Name: {weapon.ItemName} || Type: {weapon.Type} || Attack Bonus: {weapon.AttackBonus} ||  Quantity: {quantity} ||");
                    }
                    else if (item is Armor armor)
                    {
                        Console.WriteLine($"|| Armor Name: {armor.ItemName} || Type: {armor.Type} || Defense Bonus: {armor.DefenseBonus} || Quantity: {quantity} ||");
                    }
                    else
                    {
                        Console.WriteLine($"|| Item Name: {item.ItemName} || Type: {item.Type} || Heal Bonus: {item.HealBonus} || Quantity: {quantity} ||");
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n(Press any key to continue)");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        public void PrintCharacter(ref Character character)
        {
            Console.Clear();
            PrintGameTitle();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Character Info:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine($"Name: {character.Name}\n" +
                $"Hair Color: {character.HairColor}\nGender: {character.Gender}\nAge: {character.Age}\nHP: " +
                $"{character.CurrentHp}/{character.MaxHp}\nAttack: {character.Atk}\nDefense: {character.Def}");
            Console.WriteLine("-----------------------------------------------------------\n");
            if (character.Items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Looks like you have nothing in your inventory yet...");
                Console.ResetColor();
            }
            else
            {
                PrintInventory(ref character);
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n(Press any key to coninue)");
            Console.ResetColor();
            Console.ReadKey();
        }
        public void GoToTown(ref Character character)
        {
            character.CurrentHp = character.MaxHp;
            bool stayInTown = true; // Control variable for the loop

            while (stayInTown)
            {
                Console.Clear();

                PrintGameTitle();
                LocationNameSafeTown();
                PrintBanner(ref character);
                PrintWeaponBox(ref character);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("(HP restored 100%)");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. (Item Shop) Buy consumable items such as potions");
                Console.WriteLine("2. (Equipment Shop) Buy equippable weapons and armor");
                Console.WriteLine("3. (View Character) Review the player’s character appearance");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"""q"" to exit");
                Console.ResetColor();

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "m")
                {
                    EquipmentInventory(ref character);
                }

                if (choice == "q")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nExiting Safe Town...");
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }

                if (!int.TryParse(choice, out int outChoice) && choice != "q" && choice != "m")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nError, please input a valid number\n");
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                if (outChoice == 1)
                {
                    ItemShop(ref character);
                }
                else if (outChoice == 2)
                {
                    WeaponShop(ref character);
                }
                else if (outChoice == 3)
                {
                    PrintCharacter(ref character);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }
            }
        }
        public void GoToForest(ref Character character)
        {
            Random random = new Random();
            
            // 50/50 either a fight or a loot crate
            if(random.Next(2) == 0)
            {
                FightEncounter(ref character);
            }
            else
            {
                LootCrate(ref character);
            }
            return;
        }
        public void GoToMountains(ref Character character)
        {
            Random random = new Random();

            // 50/50 either a fight or a loot crate
            if (random.Next(2) == 0)
            {
                StrongFightEncounter(ref character);
            }
            else
            {
                RareLootCrate(ref character);
            }
            return;
        }
        public void GoToBossCastle(ref Character character)
        {
            Random random = new Random();

            DragonBoss dragonBoss = BossLootPool.OfType<DragonBoss>().FirstOrDefault();


            int index1 = random.Next(_strongMonsterPool.Count);
            int index2;
            do
            {
                index2 = random.Next(_strongMonsterPool.Count);
            } while (index2 == index1);

            Monsters randomMonsterTemplate = _strongMonsterPool[index1];
            Monsters randomMonsterTemplate2 = _strongMonsterPool[index2];

            Monsters randomMonster = randomMonsterTemplate.CreateCloneInstance();
            Monsters randomMonster2 = randomMonsterTemplate2.CreateCloneInstance();

            if (character.HasDefeatedDragon == false)  // if the dragon hasnt been defeted
            {
                int i = 1;

                while (i == 1)
                {
                    Console.Clear();
                    PrintGameTitle();
                    LocationNameBossCastle();
                    PrintBanner(ref character);
                    PrintWeaponBox(ref character);
                    MonsterToArt(ref randomMonster);

                    Console.WriteLine($"Fight {i}: A {randomMonster.MonsterName} has appearred, get ready {character.Name}!\n");
                    PrintBannerWithMonsterStats(ref character, randomMonster);

                    // Start the fight
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n\t\t\tWhat would you like to do?\n");
                    Console.Write("||\t1. Attack\t||\t2. Use heals\t||");
                    if (character.CanFlee)
                    {
                        Console.WriteLine("\t3. Flee\t\t||");
                    }
                    Console.ResetColor();

                    Console.Write("\nChoice: ");

                    string inputChoice = Console.ReadLine();

                    if (inputChoice == "m")
                    {
                        EquipmentInventory(ref character);
                    }

                    if (!int.TryParse(inputChoice, out int choice) && inputChoice != "m")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nError, please input a valid number\n");
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }

                    if (choice == 1 && inputChoice != "m")
                    {
                        if (character.CurrentHp <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You are too weak to fight. Please heal yourself.");
                            Console.WriteLine("Going back...");
                            Console.WriteLine("\n(Press any key to coninue)");
                            Console.ResetColor();
                            Console.ReadKey();
                            return;
                        }

                        int attackDamage = Math.Max(character.Atk - randomMonster.MonstersDefense, 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nYou attacked {randomMonster.MonsterName} dealing a total of {attackDamage}");
                        Console.ResetColor();
                        randomMonster.MonstersHp -= attackDamage;

                        if (randomMonster.MonstersHp <= 0)
                        {
                            Console.Clear();
                            PrintGameTitle();
                            LocationNameBossCastle();
                            PrintBanner(ref character);
                            PrintWeaponBox(ref character);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Good job {character.Name}! You defeted fight {i}");
                            Console.WriteLine($"Moving to next opponent...");
                            Console.ReadKey();
                            Console.ResetColor();
                            character.CurrentGold += randomMonster.GoldDropped;
                            character.CanFlee = true;

                            i++;
                            break;
                        }

                        // Monster's turn
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nThe {randomMonster.MonsterName} is preparing to attack!\n");
                        Console.ResetColor();

                        // 70/30 for monster attacks
                        int chance = random.Next(10);   // creates a random number from 0 to 9
                        if (chance < 7) //70% (0 - 6) for Basic Attack
                        {
                            // Basic Attack
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"The {randomMonster.MonsterName} uses a Basic Attack!");
                            Console.ResetColor();
                            randomMonster.BasicAttack(ref character);
                        }
                        else // 30% special attack in case of (7 - 9)
                        {
                            randomMonster.SpecialAttack(ref character);
                        }

                        // check if player died
                        if (character.CurrentHp <= 1)
                        {
                            Console.Clear();
                            PrintGameTitle();
                            LocationNameForest();
                            PrintBanner(ref character);
                            PrintWeaponBox(ref character);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nYou have been defeated...");
                            Console.WriteLine("You lost 50% of your gold!");
                            int minusGold = character.CurrentGold / 2;
                            character.CurrentGold -= minusGold;
                            character.CanFlee = true;
                            if (randomMonster is Skeleton skeleton)
                            {
                                skeleton.MonsterAtk = skeleton.OriginalAtk;
                            }
                            Console.WriteLine("\n(Press any key to coninue)");
                            Console.ResetColor();
                            Console.ReadKey();
                            return;
                        }
                    }
                    else if (choice == 2 && inputChoice != "m")
                    {
                        // use healing logic
                        //var healingItems = from item in character.Items
                        //                  where item.Type == "Consumable"
                        //                  select item;

                        //switch to a one line LINQ to be able to use .Count
                        var healingItems = character.Items.Where(item => item.Type == "Consumable" && item.HealBonus > 0).ToList();

                        if (healingItems.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have no healing items!");
                            Console.WriteLine("\n(Press any key to coninue)");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Choose a healing item to use:");
                        Console.WriteLine("------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        for (int j = 0; j < healingItems.Count; j++)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine($"{j + 1}. {healingItems[j].ItemName} (Heals: {healingItems[j].HealBonus} HP)");
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.Write("Enter the number of the item you want to use: ");

                        // takes in a string and convers it to int (healingChoice) and checks if the choice made is withing correct parameters
                        if (int.TryParse(Console.ReadLine(), out int healingChoice) && healingChoice > 0 && healingChoice <= healingItems.Count)
                        {
                            // map the selected item
                            var selectedItem = healingItems[healingChoice - 1];

                            // Heal the player
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"You used a {selectedItem.ItemName} and restored {selectedItem.HealBonus} HP!");
                            //Math.Min ensures that we do not heal the player over the MaxHp
                            character.CurrentHp = Math.Min(character.MaxHp, character.CurrentHp + selectedItem.HealBonus);
                            selectedItem.Quantity--;

                            // Remove the item if its quantity reaches 0
                            if (selectedItem.Quantity <= 0)
                            {
                                character.Items.Remove(selectedItem);
                            }
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Please try again.");
                            Console.ResetColor();
                        }
                    }
                    else if (choice == 3 && character.CanFlee && inputChoice != "m")
                    {
                        // Flee logic
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You fled the fight!");
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                }

                while (i == 2)
                {
                    Console.Clear();
                    PrintGameTitle();
                    LocationNameBossCastle();
                    PrintBanner(ref character);
                    PrintWeaponBox(ref character);
                    MonsterToArt(ref randomMonster2);

                    Console.WriteLine($"Fight {i}: A {randomMonster2.MonsterName} has appearred, get ready {character.Name}!\n");
                    PrintBannerWithMonsterStats(ref character, randomMonster2);

                    // Start the fight
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n\t\t\tWhat would you like to do?\n");
                    Console.Write("||\t1. Attack\t||\t2. Use heals\t||");
                    if (character.CanFlee)
                    {
                        Console.WriteLine("\t3. Flee\t\t||");
                    }
                    Console.ResetColor();

                    Console.Write("\nChoice: ");

                    string inputChoice = Console.ReadLine();

                    if (inputChoice == "m")
                    {
                        EquipmentInventory(ref character);
                    }

                    if (!int.TryParse(inputChoice, out int choice) && inputChoice != "m")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nError, please input a valid number\n");
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }

                    if (choice == 1 && inputChoice != "m")
                    {
                        if (character.CurrentHp <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You are too weak to fight. Please heal yourself.");
                            Console.WriteLine("Going back...");
                            Console.WriteLine("\n(Press any key to coninue)");
                            Console.ResetColor();
                            Console.ReadKey();
                            return;
                        }

                        int attackDamage = Math.Max(character.Atk - randomMonster2.MonstersDefense, 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nYou attacked {randomMonster2.MonsterName} dealing a total of {attackDamage}");
                        Console.ResetColor();
                        randomMonster2.MonstersHp -= attackDamage;

                        if (randomMonster2.MonstersHp <= 0)
                        {
                            Console.Clear();
                            PrintGameTitle();
                            LocationNameBossCastle();
                            PrintBanner(ref character);
                            PrintWeaponBox(ref character);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Good job {character.Name}! You defeted fight {i}");
                            Console.WriteLine($"Moving to Boss Fight...");
                            Console.ReadKey();
                            Console.ResetColor();
                            character.CurrentGold += randomMonster2.GoldDropped;
                            character.CanFlee = true;

                            i++;
                            break;
                        }

                        // Monster's turn
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nThe {randomMonster2.MonsterName} is preparing to attack!\n");
                        Console.ResetColor();

                        // 70/30 for monster attacks
                        int chance = random.Next(10);   // creates a random number from 0 to 9
                        if (chance < 7) //70% (0 - 6) for Basic Attack
                        {
                            // Basic Attack
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"The {randomMonster2.MonsterName} uses a Basic Attack!");
                            Console.ResetColor();
                            randomMonster2.BasicAttack(ref character);
                        }
                        else // 30% special attack in case of (7 - 9)
                        {
                            randomMonster2.SpecialAttack(ref character);
                        }

                        // check if player died
                        if (character.CurrentHp <= 1)
                        {
                            Console.Clear();
                            PrintGameTitle();
                            LocationNameForest();
                            PrintBanner(ref character);
                            PrintWeaponBox(ref character);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nYou have been defeated...");
                            Console.WriteLine("You lost 50% of your gold!");
                            int minusGold = character.CurrentGold / 2;
                            character.CurrentGold -= minusGold;
                            character.CanFlee = true;
                            if (randomMonster is Skeleton skeleton)
                            {
                                skeleton.MonsterAtk = skeleton.OriginalAtk;
                            }
                            Console.WriteLine("\n(Press any key to coninue)");
                            Console.ResetColor();
                            Console.ReadKey();
                            return;
                        }
                    }
                    else if (choice == 2 && inputChoice != "m")
                    {
                        // use healing logic
                        //var healingItems = from item in character.Items
                        //                  where item.Type == "Consumable"
                        //                  select item;

                        //switch to a one line LINQ to be able to use .Count
                        var healingItems = character.Items.Where(item => item.Type == "Consumable" && item.HealBonus > 0).ToList();

                        if (healingItems.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have no healing items!");
                            Console.WriteLine("\n(Press any key to coninue)");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Choose a healing item to use:");
                        Console.WriteLine("------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        for (int j = 0; j < healingItems.Count; j++)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine($"{j + 1}. {healingItems[j].ItemName} (Heals: {healingItems[j].HealBonus} HP)");
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.Write("Enter the number of the item you want to use: ");

                        // takes in a string and convers it to int (healingChoice) and checks if the choice made is withing correct parameters
                        if (int.TryParse(Console.ReadLine(), out int healingChoice) && healingChoice > 0 && healingChoice <= healingItems.Count)
                        {
                            // map the selected item
                            var selectedItem = healingItems[healingChoice - 1];

                            // Heal the player
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"You used a {selectedItem.ItemName} and restored {selectedItem.HealBonus} HP!");
                            //Math.Min ensures that we do not heal the player over the MaxHp
                            character.CurrentHp = Math.Min(character.MaxHp, character.CurrentHp + selectedItem.HealBonus);
                            selectedItem.Quantity--;

                            // Remove the item if its quantity reaches 0
                            if (selectedItem.Quantity <= 0)
                            {
                                character.Items.Remove(selectedItem);
                            }
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Please try again.");
                            Console.ResetColor();
                        }
                    }
                    else if (choice == 3 && character.CanFlee && inputChoice != "m")
                    {
                        // Flee logic
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You fled the fight!");
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                }

                while (i == 3)
                {
                    Console.Clear();
                    PrintGameTitle();
                    LocationNameBossCastle();
                    PrintBanner(ref character);
                    PrintWeaponBox(ref character);
                    DragonArt(ref character);
                    Console.WriteLine($"Last Fight: {dragonBoss.MonsterName} has appearred, defeat him {character.Name}!\n");
                    PrintBannerWithMonsterStats(ref character, dragonBoss);

                    // Start the fight
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n\t\t\tWhat would you like to do?\n");
                    Console.Write("||\t1. Attack\t||\t2. Use heals\t||");
                    if (character.CanFlee)
                    {
                        Console.WriteLine("\t3. Flee\t\t||");
                    }
                    Console.ResetColor();

                    Console.Write("\nChoice: ");

                    string inputChoice = Console.ReadLine();

                    if (inputChoice == "m")
                    {
                        EquipmentInventory(ref character);
                    }

                    if (!int.TryParse(inputChoice, out int choice) && inputChoice != "m")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nError, please input a valid number\n");
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }

                    if (choice == 1 && inputChoice != "m")
                    {
                        if (character.CurrentHp <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You are too weak to fight. Please heal yourself.");
                            Console.WriteLine("Going back...");
                            Console.WriteLine("\n(Press any key to coninue)");
                            Console.ResetColor();
                            Console.ReadKey();
                            return;
                        }

                        int attackDamage = Math.Max(character.Atk - dragonBoss.MonstersDefense, 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nYou attacked {dragonBoss.MonsterName} dealing a total of {attackDamage}");
                        Console.ResetColor();
                        dragonBoss.MonstersHp -= attackDamage;

                        if (dragonBoss.MonstersHp <= 0)
                        {
                            Console.Clear();
                            PrintGameTitle();
                            LocationNameBossCastle();
                            PrintBanner(ref character);
                            PrintWeaponBox(ref character);
                            Console.WriteLine();
                            dragonBoss.OnDefeat(ref character);
                            Console.ReadKey();
                            Console.ResetColor();
                            character.CurrentGold += dragonBoss.GoldDropped;
                            character.CanFlee = true;
                            character.HasDefeatedDragon = true;
                            i++;
                            break;
                        }

                        // Monster's turn
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nThe {dragonBoss.MonsterName} is preparing to attack!\n");
                        Console.ResetColor();

                        // 70/30 for monster attacks
                        int chance = random.Next(10);   // creates a random number from 0 to 9
                        if (chance < 7) //70% (0 - 6) for Basic Attack
                        {
                            // Basic Attack
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"The {dragonBoss.MonsterName} uses a Basic Attack!");
                            Console.ResetColor();
                            dragonBoss.BasicAttack(ref character);
                        }
                        else // 30% special attack in case of (7 - 9)
                        {
                            dragonBoss.SpecialAttack(ref character);
                        }

                        // check if player died
                        if (character.CurrentHp <= 1)
                        {
                            Console.Clear();
                            PrintGameTitle();
                            LocationNameForest();
                            PrintBanner(ref character);
                            PrintWeaponBox(ref character);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nYou have been defeated...");
                            Console.WriteLine("You lost 50% of your gold!");
                            int minusGold = character.CurrentGold / 2;
                            character.CurrentGold -= minusGold;
                            character.CanFlee = true;
                            if (randomMonster is Skeleton skeleton)
                            {
                                skeleton.MonsterAtk = skeleton.OriginalAtk;
                            }
                            Console.WriteLine("\n(Press any key to coninue)");
                            Console.ResetColor();
                            Console.ReadKey();
                            return;
                        }
                    }
                    else if (choice == 2 && inputChoice != "m")
                    {
                        // use healing logic
                        //var healingItems = from item in character.Items
                        //                  where item.Type == "Consumable"
                        //                  select item;

                        //switch to a one line LINQ to be able to use .Count
                        var healingItems = character.Items.Where(item => item.Type == "Consumable" && item.HealBonus > 0).ToList();

                        if (healingItems.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have no healing items!");
                            Console.WriteLine("\n(Press any key to coninue)");
                            Console.ResetColor();
                            Console.ReadKey();
                            continue;
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Choose a healing item to use:");
                        Console.WriteLine("------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        for (int j = 0; j < healingItems.Count; j++)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine($"{j + 1}. {healingItems[j].ItemName} (Heals: {healingItems[j].HealBonus} HP)");
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                        Console.Write("Enter the number of the item you want to use: ");

                        // takes in a string and convers it to int (healingChoice) and checks if the choice made is withing correct parameters
                        if (int.TryParse(Console.ReadLine(), out int healingChoice) && healingChoice > 0 && healingChoice <= healingItems.Count)
                        {
                            // map the selected item
                            var selectedItem = healingItems[healingChoice - 1];

                            // Heal the player
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"You used a {selectedItem.ItemName} and restored {selectedItem.HealBonus} HP!");
                            //Math.Min ensures that we do not heal the player over the MaxHp
                            character.CurrentHp = Math.Min(character.MaxHp, character.CurrentHp + selectedItem.HealBonus);
                            selectedItem.Quantity--;

                            // Remove the item if its quantity reaches 0
                            if (selectedItem.Quantity <= 0)
                            {
                                character.Items.Remove(selectedItem);
                            }
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Please try again.");
                            Console.ResetColor();
                        }
                    }
                    else if (choice == 3 && character.CanFlee && inputChoice != "m")
                    {
                        // Flee logic
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You fled the fight!");
                        Console.WriteLine("\n(Press any key to coninue)");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n(Press any key to coninue)");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
            else// if the dragon is defeated 
            {
                Console.Clear();
                PrintGameTitle();
                LocationNameBossCastle();
                PrintBanner(ref character);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You have already defetead the boss!");
                Console.WriteLine($"Looks like you are very strong! Good job {character.Name}!");
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n(Press any key to continue)");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        public void PrintBanner(ref Character character)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("+----------------------+----------------+----------------+----------------+----------------+------------------------------+");
            Console.WriteLine("|        Name          |     Health     |     Gold       |      ATK       |      DEF       |     Items in Inventory       |");
            Console.WriteLine("+----------------------+----------------+----------------+----------------+----------------+------------------------------+");
            // You can tweak the width (e.g., -20) depending on how tight/loose you want the alignment
            Console.WriteLine($"| {character.Name,-20} | {character.CurrentHp,-14} | {character.CurrentGold,-14} | {character.Atk,-14} | {character.Def,-14} | {character.Items.Count,-28} |");

            Console.WriteLine("+----------------------+----------------+----------------+----------------+----------------+------------------------------+");
            Console.ResetColor();
        }
    }
}

// fix the dragon after you fight with it you cannot go back
// include more art and polish
// figure out how to safe in text file