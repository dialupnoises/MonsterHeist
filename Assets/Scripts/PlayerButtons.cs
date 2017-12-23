using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButtons : MonoBehaviour
{
	public int SelectedButton = 0;
	public CollectAnimals CollectAnimals;
	public CreateMonster CreateMonster;
	public Heists Heists;
	public GameManager GameManager;
	public GameObject ShowMonsterPanel;
	public ShowMonster ShowMonster;
	public Training Training;
	public Fusing Fusing;

	public GameObject AnimalPanel;
	public GameObject MonsterPanel;
	public GameObject HeistPanel;
	public GameObject FusePanel;
	public GameObject TrainingPanel;
	public GameObject ExperimentChoicePanel;
	public GameObject CoverUp;

	private ColorBlock _regularBlock;
	private ColorBlock _selectedBlock;

	void Start()
	{
		_regularBlock = ColorBlock.defaultColorBlock;
		_selectedBlock = ColorBlock.defaultColorBlock;
		_selectedBlock.normalColor = _regularBlock.pressedColor;
		_selectedBlock.highlightedColor = _regularBlock.pressedColor;
		_selectedBlock.pressedColor = _regularBlock.normalColor;
	}

	public void DoNothingButton()
	{
		SelectedButton = 0;
		GameManager.PlayerTask = PlayerTaskTypes.None;
	}

	public void GatherAnimalsButton()
	{
		AnimalPanel.SetActive(true);
		CoverUp.SetActive(true);
	}

	public void ExperimentChoiceButton()
	{
		ExperimentChoicePanel.SetActive(true);
		CoverUp.SetActive(true);
	}

	public void CreateMonstersButton()
	{
		ExperimentChoicePanel.SetActive(false);
		MonsterPanel.SetActive(true);
		CreateMonster.UpdateDropdown();
	}

	public void FuseAnimalsButton()
	{
		ExperimentChoicePanel.SetActive(false);
		FusePanel.SetActive(true);
		Fusing.UpdateDropdown();
	}

	public void CancelChoiceButton()
	{
		ExperimentChoicePanel.SetActive(false);
		CoverUp.SetActive(false);
	}

	public void HeistsButton()
	{
		HeistPanel.SetActive(true);
		CoverUp.SetActive(true);
		Heists.UpdateDropdown();
	}

	public void TrainingButton()
	{
		CoverUp.SetActive(true);
		TrainingPanel.SetActive(true);
		Training.UpdateDropdown();
	}

	public void PlayerCancelButton()
	{
		GameManager.ResetPlayerTask();
	}

	public void MonsterCancelButton()
	{
		GameManager.ResetMonsterTask();
	}

	public void NextDayButton()
	{
		GameManager.NextDay();
	}

	public void OpenZaat()
	{
		ShowMonster.Monster = GameManager.Monsters.First(m => m.Type == MonsterType.Zaat);
		ShowMonsterPanel.SetActive(true);
		CoverUp.SetActive(true);
	}

	public void OpenKong()
	{
		ShowMonster.Monster = GameManager.Monsters.First(m => m.Type == MonsterType.KingKong);
		ShowMonsterPanel.SetActive(true);
		CoverUp.SetActive(true);
	}

	public void OpenDracula()
	{
		ShowMonster.Monster = GameManager.Monsters.First(m => m.Type == MonsterType.Dracula);
		ShowMonsterPanel.SetActive(true);
		CoverUp.SetActive(true);
	}

	public void OpenWolf()
	{
		ShowMonster.Monster = GameManager.Monsters.First(m => m.Type == MonsterType.Wolfman);
		ShowMonsterPanel.SetActive(true);
		CoverUp.SetActive(true);
	}

	public void Chloe()
	{
		GameManager.MessageBox.Show("Trash Can", "Who would throw a perfectly good beanie in a trash can?");
	}
}