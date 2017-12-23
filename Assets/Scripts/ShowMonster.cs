using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ShowMonster : MonoBehaviour
{
	public Monster Monster;
	public Text TitleLabel;
	public Text BodyLabel;
	public GameObject ShowMonsterPanel;
	public GameObject CoverUp;

	public Button[] Buttons;

	void Update()
	{
		TitleLabel.text = Monster.Name;
		BodyLabel.text =
			"Level " + Monster.Level +
			"\nXP: " + Monster.XP + " / " + Monster.GetLevelXP(Monster.Level + 1) +
			"\n<i>" + Monster.Credits + " Credits</i>" +
			"\nStrength: " + Monster.Strength +
			"\nAgility: " + Monster.Agility +
			"\nVitality: " + Monster.Vitality +
			"\nStealth: " + Monster.Stealth;

		foreach(var button in Buttons)
		{
			button.interactable = Monster.Credits > 0;
		}
	}

	public void StrengthPlus()
	{
		Monster.Credits--;
		Monster.Strength++;
	}

	public void AgilityPlus()
	{
		Monster.Credits--;
		Monster.Agility++;
	}

	public void VitalityPlus()
	{
		Monster.Credits--;
		Monster.Vitality++;
	}

	public void StealthPlus()
	{
		Monster.Credits--;
		Monster.Stealth++;
	}
	
	public void OKButton()
	{
		ShowMonsterPanel.SetActive(false);
		CoverUp.SetActive(false);
	}
}
