using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Animal
{
	public static string[] RarityNames = 
	{
		"Consumer Grade",
		"Industrial Grade",
		"Mil-Spec",
		"Restricted",
		"Classified",
		"Covert",
		"Endangered"
	};

	public int Tier = 0;
	public AnimalType Type;

	public int GetXP()
	{
		return (int)(Math.Pow(2 * (Tier + 1), 2) * 0.75);
	}

	public Animal(AnimalType type)
	{
		Type = type;
	}

	public Animal()
	{
		var names = Enum.GetNames(typeof(AnimalType));
		var name = names[new System.Random().Next(0, names.Length)];
		Type = (AnimalType)Enum.Parse(typeof(AnimalType), name);
	}
}

public enum AnimalType
{
	Monkey,
	Catfish,
	Wolf,
	Bat
}