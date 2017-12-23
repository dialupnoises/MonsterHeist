using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Fusing : MonoBehaviour
{
	public GameManager GameManager;
	public GameObject FusePanel;
	public GameObject CoverUp;
	public Text DescText;
	public Dropdown AnimalDropdown;
	public Dropdown MonsterDropdown;
	public Button OKButton;

	private List<Animal> _animals;

	void Update()
	{
		if(AnimalDropdown.options.Count == 0)
		{
			OKButton.interactable = false;
			DescText.text = "";
			return;
		}

		var animal = _animals[AnimalDropdown.value];
		var monster = GameManager.AvailableMonsters[MonsterDropdown.value];
		DescText.text =
			"This will result in " + animal.GetXP() + " XP for " + monster.Name + "." +
			"\nThis will cost " + monster.FusingCost().ToString("C0") + ".";

		OKButton.interactable = monster.FusingCost() <= GameManager.Money;
	}

	public void UpdateDropdown()
	{
		MonsterDropdown.options = GameManager.AvailableMonsters.Select(m => new Dropdown.OptionData(m.Name)).ToList();
		MonsterDropdownUpdate();
	}

	public void MonsterDropdownUpdate()
	{
		if(MonsterDropdown.options.Count == 0)
		{
			AnimalDropdown.ClearOptions();
		}

		var monster = GameManager.AvailableMonsters[MonsterDropdown.value];
		_animals = GameManager.AvailableAnimals.Where(a => (int)a.Type == (int)monster.Type).ToList();
		AnimalDropdown.options = _animals.Select(a => new Dropdown.OptionData(a.Type + " - " + Animal.RarityNames[a.Tier])).ToList();
	}

	public void OnOKButton()
	{
		GameManager.ResetPlayerTask();
		GameManager.PlayerTask = PlayerTaskTypes.FuseAnimals;
		GameManager.FuseMonsterAnimal = _animals[AnimalDropdown.value];
		GameManager.FuseMonsterMonster = GameManager.AvailableMonsters[MonsterDropdown.value];
		GameManager.Money -= GameManager.FuseMonsterMonster.FusingCost();
		FusePanel.SetActive(false);
		CoverUp.SetActive(false);
	}

	public void OnCancelButton()
	{
		FusePanel.SetActive(false);
		CoverUp.SetActive(false);
	}
}