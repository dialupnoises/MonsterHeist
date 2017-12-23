using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Crime
{
	public string Name;
	public int StrengthRequired = 0;
	public int AgilityRequired = 0;
	public int VitalityRequired = 0;
	public int StealthRequired = 0;
	public int TimesCompleted = 0;
	public int MinMoney = 0;
	public int MaxMoney = 0;
	public bool Enabled = false;

	public double SuccessChance(Monster monster)
	{
		var minSkills = Math.Max(4, StrengthRequired + AgilityRequired + VitalityRequired + StealthRequired);
		var maxSkills = minSkills * 3;
		var monsterTotal = monster.Strength + monster.Agility + monster.Vitality + monster.Stealth;
		return Math.Min(0.95, ((double)monsterTotal - minSkills) / ((double)maxSkills - minSkills));
	}
}