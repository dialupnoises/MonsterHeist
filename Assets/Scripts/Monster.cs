using UnityEngine;
using System;
using System.Collections;

public class Monster
{
	public MonsterType Type;
	public int Strength = 0;
	public int Agility = 0;
	public int Vitality = 0;
	public int Stealth = 0;
	public int XP = 0;
	public int Level = 1;
	public int Credits = 0;
	
	public string Name
	{
		get
		{
			return Util.UpperCamelCaseToWords(Type.ToString());
		}
	}

	public static int GetLevelXP(int level)
	{
		return (int)Mathf.Pow(2 * level, 2);
	}

	public static Monster GenerateNewMonster(MonsterType type, int tier)
	{
		var strength = 1 + tier / 2;
		var agility = 1 + tier / 2;
		var vitality = 1 + tier / 2;
		var stealth = 1 + tier / 2;

		if(type == MonsterType.KingKong)
		{
			vitality += 3;
			strength += 2;
		}
		else if(type == MonsterType.Zaat)
		{
			strength += 3;
			stealth += 2;
		}
		else if(type == MonsterType.Wolfman)
		{
			agility += 3;
			strength += 2;
		}
		else
		{
			stealth += 3;
			agility += 2;
		}

		return new Monster()
		{
			Type = type,
			Strength = strength,
			Agility = agility,
			Vitality = vitality,
			Stealth = stealth,
		};
	}

	public int TrainingCost()
	{
		return (int)Math.Floor(0.1953125 * Math.Pow(Strength + Agility + Vitality + Stealth, 4));
	}

	public int FusingCost()
	{
		return (int)Math.Floor(0.1 * 3.125 * Math.Pow(Strength + Agility + Vitality + Stealth, 2));
	}
}

public enum MonsterType
{
	KingKong,
	Zaat,
	Wolfman,
	Dracula
}
