// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using Polymorphism_notes;

List<Animal> pets = new List<Animal>();

Animal animal = new Animal("Default animal");
Dog dog = new Dog("Fredo");
Cat cat = new Cat("JP");    

pets.Add(animal);
pets.Add(cat);
pets.Add(dog);

foreach(Animal pet in pets)
{
    pet.MakeSound();
}
