using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Heists : MonoBehaviour
{
	public GameManager GameManager;
	public GameObject HeistsPanel;
	public GameObject CoverUp;
	public Dropdown HeistDropdown;
	public Dropdown MonsterDropdown;
	public Text CrimeDesc;
	public Text MonsterInfoBox;
	public Button OKButtonObj;

	void Start()
	{
		UpdateDropdown();
	}
	
	void Update()
	{
		var crime = CrimeData.Crimes[HeistDropdown.value];
		CrimeDesc.text =
			"Requirements:\n\tStrength: " + crime.StrengthRequired +
			"\n\tAgility: " + crime.AgilityRequired +
			"\n\tVitality: " + crime.VitalityRequired +
			"\n\tStealth: " + crime.StealthRequired +
			"\nProfit: " + crime.MinMoney.ToString("C0") + " - " + crime.MaxMoney.ToString("C0");

		if(MonsterDropdown.options.Count == 0)
		{
			OKButtonObj.interactable = false;
			MonsterInfoBox.text = "";
		}
		else
		{
			var monster = GameManager.AvailableMonsters[MonsterDropdown.value];
			var canDo =
				monster.Strength >= crime.StrengthRequired &&
				monster.Agility >= crime.AgilityRequired &&
				monster.Vitality >= crime.VitalityRequired &&
				monster.Stealth >= crime.StealthRequired;
			OKButtonObj.interactable = canDo;

			MonsterInfoBox.text =
				"Strength: " + (monster.Strength < crime.StrengthRequired ? "X" : "✓") +
				"\nAgility: " + (monster.Agility < crime.AgilityRequired ? "X" : "✓") +
				"\nVitality: " + (monster.Vitality < crime.VitalityRequired ? "X" : "✓") +
				"\nStealth: " + (monster.Stealth < crime.StealthRequired ? "X" : "✓") +
				"\nChance of Success: " + (canDo ? crime.SuccessChance(monster) * 100 + "%" : "0%");
		}
	}

	public void UpdateDropdown()
	{
		HeistDropdown.options = CrimeData.Crimes.Where(c => c.Enabled).Select(c => new Dropdown.OptionData(c.Name)).ToList();
		MonsterDropdown.options = GameManager.AvailableMonsters.Select(m => new Dropdown.OptionData(m.Name)).ToList();
	}

	public void OKButton()
	{
		HeistsPanel.SetActive(false);
		CoverUp.SetActive(false);
		GameManager.ResetMonsterTask();
		GameManager.MonsterTask = MonsterTaskTypes.Heist;
		GameManager.TaskMonster = GameManager.AvailableMonsters[MonsterDropdown.value];
		GameManager.Heist = CrimeData.Crimes[HeistDropdown.value];
	}

	public void CancelButton()
	{
		HeistsPanel.SetActive(false);
		CoverUp.SetActive(false);
	}
}
