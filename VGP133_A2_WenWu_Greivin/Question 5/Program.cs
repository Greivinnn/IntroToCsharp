// See https://aka.ms/new-console-template for more information

//Question 5
using Question_5;

//spells
Spell spell1 = new Spell("WaterBall", 5, 2, "Water");
Spell spell2 = new Spell("DragonBreath", 20, 5, "Fire");
Spell spell3 = new Spell("Dissolution", 50, 3, "Acid");

//magician
Magician magician1 = new Magician("Alfred", "Male", 50);

magician1.ViewSpellbook();
magician1.LearnSpell(spell1);
magician1.LearnSpell(spell1);
magician1.LearnSpell(spell2);
magician1.LearnSpell(spell3);
magician1.ViewSpellbook();
magician1.UnlearnSpell(spell1);
magician1.UnlearnSpell(spell1);
magician1.ViewSpellbook();