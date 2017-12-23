using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CreateMonster : MonoBehaviour
{
	public GameManager GameManager;
	public Dropdown AnimalDropdown;
	public Text AnimalDesc;
	public Button OKButton;

	public GameObject MonsterPanel;
	public GameObject CoverUp;

	private Animal[] _animals;

	void Start()
	{
		UpdateDropdown();
	}

	void Update()
	{
		OKButton.interactable = AnimalDropdown.options.Count > 0;
	}

	public void UpdateDropdown()
	{
		_animals = GameManager.AvailableAnimals.Where(a => !GameManager.Monsters.Any(m => (int)m.Type == (int)a.Type)).OrderBy(a => (int)a.Type * 10 + a.Tier).ToArray();
		AnimalDropdown.options = new List<Dropdown.OptionData>(
				_animals.Select(a => new Dropdown.OptionData(a.Type + " - " + Animal.RarityNames[a.Tier]))
		);
		DropdownChanged();
	}

	public void DropdownChanged()
	{
		if(AnimalDropdown.options.Count == 0) return;
		var monsterType = (MonsterType)(int)_animals[AnimalDropdown.value].Type;
		AnimalDesc.text = "...will result in " + Util.UpperCamelCaseToWords(monsterType.ToString()).Trim() + ".";
	}

	public void OnOKButton()
	{
		MonsterPanel.SetActive(false);
		CoverUp.SetActive(false);
		GameManager.ResetPlayerTask();
		GameManager.PlayerTask = PlayerTaskTypes.CreateMonsters;
		GameManager.CreateMonsterAnimal = _animals[AnimalDropdown.value];
	}

	public void OnCancelButton()
	{
		MonsterPanel.SetActive(false);
		CoverUp.SetActive(false);
	}
}