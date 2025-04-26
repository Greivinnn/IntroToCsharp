// See https://aka.ms/new-console-template for more information
using Exercises;

Mage mage = new Mage("JP", "FIREBALLLLL", 1000);
mage.DisplayCry();

Warrior warrior = new Warrior("Alfred", "MAMAAMIA", 500);
warrior.DisplayCry();

 // Character charac = new Character("JP", "FIREBALLLLL", 1000); // cannot do this due to the abstract class
 // if using abstract you need to specify what type of derivation from the main class is. In this case Mage and Warrior are the derrived classses from Character