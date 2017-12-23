using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Training : MonoBehaviour
{
	public GameManager GameManager;
	public Text CostText;
	public Text SelectionSubText;
	public Button[] Buttons;
	public Dropdown MonsterDropdown;

	public GameObject TrainingPanel;
	public GameObject CoverUp;

	void Update()
	{
		if(MonsterDropdown.options.Count == 0)
		{
			CostText.text = "";
			SelectionSubText.text = "";
			foreach(var button in Buttons)
			{
				button.interactable = false;
			}
		}
		else
		{
			var monster = GameManager.AvailableMonsters[MonsterDropdown.value];
			SelectionSubText.text = "Training " + monster.Name + " will cost...";
			CostText.text = monster.TrainingCost().ToString("C0");
			foreach(var button in Buttons)
			{
				button.interactable = monster.TrainingCost() <= GameManager.Money;
			}
		}
	}

	public void UpdateDropdown()
	{
		MonsterDropdown.options = GameManager.AvailableMonsters.Select(m => new Dropdown.OptionData(m.Name)).ToList();
	}

	public void StrengthButton()
	{
		var monster = GameManager.AvailableMonsters[MonsterDropdown.value];
		GameManager.Money -= monster.TrainingCost();
		GameManager.ResetMonsterTask();
		GameManager.MonsterTask = MonsterTaskTypes.Training;
		GameManager.TrainingStat = Stats.Strength;
		CancelButton();
	}

	public void AgilityButton()
	{
		var monster = GameManager.AvailableMonsters[MonsterDropdown.value];
		GameManager.Money -= monster.TrainingCost();
		GameManager.MonsterTask = MonsterTaskTypes.Training;
		GameManager.TrainingStat = Stats.Agility;
		CancelButton();
	}

	public void VitalityButton()
	{
		var monster = GameManager.AvailableMonsters[MonsterDropdown.value];
		GameManager.Money -= monster.TrainingCost();
		GameManager.MonsterTask = MonsterTaskTypes.Training;
		GameManager.TrainingStat = Stats.Vitality;
		CancelButton();
	}

	public void StealthButton()
	{
		var monster = GameManager.AvailableMonsters[MonsterDropdown.value];
		GameManager.Money -= monster.TrainingCost();
		GameManager.MonsterTask = MonsterTaskTypes.Training;
		GameManager.TrainingStat = Stats.Stealth;
		CancelButton();
	}

	public void CancelButton()
	{
		TrainingPanel.SetActive(false);
		CoverUp.SetActive(false);
	}
}