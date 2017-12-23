using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public long Money = 100;
	public int Day = 1;
	public PlayerTaskTypes PlayerTask = PlayerTaskTypes.None;
	public MonsterTaskTypes MonsterTask = MonsterTaskTypes.None;
	public Monster TaskMonster = null;

	public long CollectAnimalsCash = 0;

	public Animal FuseMonsterAnimal = null;
	public Monster FuseMonsterMonster = null;
	public Animal CreateMonsterAnimal = null;
	public Crime Heist = null;
	public Stats TrainingStat = Stats.None;

	public List<Animal> Animals = new List<Animal>() { new Animal() };
	public List<Monster> Monsters = new List<Monster>();

	public Text DayText;
	public Text MoneyText;
	public Text TaskText;

	public Button PlayerCancelButton;
	public Button MonsterCancelButton;
	public MessageBox MessageBox;
	public CreateMonster CreateMonster;

	public GameObject KongImage;
	public Text KongLevelText;
	public GameObject ZaatImage;
	public Text ZaatLevelText;
	public GameObject WolfImage;
	public Text WolfLevelText;
	public GameObject DraculaImage;
	public Text DraculaLevelText;

	public Monster KingKong
	{
		get { return Monsters.Where(m => m.Type == MonsterType.KingKong).FirstOrDefault(); }
	}

	public Monster Zaat
	{
		get { return Monsters.Where(m => m.Type == MonsterType.Zaat).FirstOrDefault(); }
	}

	public Monster Dracula
	{
		get { return Monsters.Where(m => m.Type == MonsterType.Dracula).FirstOrDefault(); }
	}

	public Monster Wolfman
	{
		get { return Monsters.Where(m => m.Type == MonsterType.Wolfman).FirstOrDefault(); }
	}

	public List<Monster> AvailableMonsters
	{
		get { return Monsters.Where(m => m != TaskMonster && m != FuseMonsterMonster).ToList(); }
	}

	public List<Animal> AvailableAnimals
	{
		get { return Animals.Where(a => a != CreateMonsterAnimal && a != FuseMonsterAnimal).ToList(); }
	}

	void Start()
	{
	}

	void Update()
	{
		DayText.text = "Day " + Day;
		var money = Money.ToString("C");
		MoneyText.text = money.Substring(0, money.Length - 3);
		TaskText.text =
			"Player Task: " + Util.UpperCamelCaseToWords(PlayerTask.ToString()) +
			"\nMonster Task: " + Util.UpperCamelCaseToWords(MonsterTask.ToString()) + (TaskMonster != null ? " (" + TaskMonster.Name + ")" : "");

		PlayerCancelButton.interactable = PlayerTask != PlayerTaskTypes.None;
		MonsterCancelButton.interactable = MonsterTask != MonsterTaskTypes.None;

		KongImage.SetActive(Monsters.Where(a => a.Type == MonsterType.KingKong).Any());
		if(KingKong != default(Monster))
			KongLevelText.text = KingKong.Level.ToString();
		ZaatImage.SetActive(Monsters.Where(a => a.Type == MonsterType.Zaat).Any());
		if(Zaat != default(Monster))
			ZaatLevelText.text = Zaat.Level.ToString();
		WolfImage.SetActive(Monsters.Where(a => a.Type == MonsterType.Wolfman).Any());
		if(Wolfman != default(Monster))
			WolfLevelText.text = Wolfman.Level.ToString();
		DraculaImage.SetActive(Monsters.Where(a => a.Type == MonsterType.Dracula).Any());
		if(Dracula != default(Monster))
			DraculaLevelText.text = Dracula.Level.ToString();
	}

	public void ResetPlayerTask()
	{
		PlayerTask = PlayerTaskTypes.None;
		Money += CollectAnimalsCash;
		if(FuseMonsterMonster != null)
		{
			Money += FuseMonsterMonster.FusingCost();
		}
		FuseMonsterMonster = null;
		FuseMonsterAnimal = null;
		CollectAnimalsCash = 0;
		CreateMonsterAnimal = null;
	}

	public void ResetMonsterTask()
	{
		if(TrainingStat != Stats.None)
		{
			Money += TaskMonster.TrainingCost();
		}

		TrainingStat = Stats.None;
		MonsterTask = MonsterTaskTypes.None;
		TaskMonster = null;
		Heist = null;
	}

	public void NextDay()
	{
		if(PlayerTask == PlayerTaskTypes.CollectAnimals)
		{
			var animal = new Animal() { Tier = Random.Range(0, 6) };
			Animals.Add(animal);
			MessageBox.Show("Animal Found", "A " + Util.UpperCamelCaseToWords(animal.Type.ToString()) + " was found.\nThis animal is tier " + (animal.Tier + 1) + ".");
			CollectAnimalsCash = 0;
		}
		else if(PlayerTask == PlayerTaskTypes.CreateMonsters)
		{
			var monster = Monster.GenerateNewMonster((MonsterType)(int)CreateMonsterAnimal.Type, CreateMonsterAnimal.Tier);
			Monsters.Add(monster);
			MessageBox.Show("Monster Created!", Util.UpperCamelCaseToWords(monster.Type.ToString()) + " has been created!");
			Animals.Remove(CreateMonsterAnimal);
		}
		else if(PlayerTask == PlayerTaskTypes.FuseAnimals)
		{
			FuseMonsterMonster.XP += FuseMonsterAnimal.GetXP();
			Animals.Remove(FuseMonsterAnimal);
			
			if(FuseMonsterMonster.XP >= Monster.GetLevelXP(FuseMonsterMonster.Level + 1) && MonsterTask != MonsterTaskTypes.Heist)
			{
				FuseMonsterMonster.Level++;
				FuseMonsterMonster.Credits++;
				FuseMonsterMonster.XP = 0;
				MessageBox.Show("Fusing Results", FuseMonsterMonster.Name + " leveled up!");
			}
			FuseMonsterMonster = null;
		}

		if(MonsterTask == MonsterTaskTypes.Heist)
		{
			var randNum = Random.value;
			if(randNum > Heist.SuccessChance(TaskMonster))
			{
				MessageBox.Show("Heist Failed!", "Your evil minion just couldn't do it. Try improving your creation!");
			}
			else
			{
				var heistIndex = System.Array.IndexOf(CrimeData.Crimes, Heist);
				var profit = Random.Range(Heist.MinMoney, Heist.MaxMoney);
				Money += profit;
				var xpBoost = 5 + (int)Mathf.Ceil(2.5f * Mathf.Pow(heistIndex + 1, 2));
				TaskMonster.XP += xpBoost;
				if(heistIndex < CrimeData.Crimes.Length - 1)
				{
					CrimeData.Crimes[heistIndex + 1].Enabled = true;
				}

				var levelText = "";
				if(TaskMonster.XP >= Monster.GetLevelXP(TaskMonster.Level + 1))
				{
					TaskMonster.Level++;
					TaskMonster.Credits++;
					TaskMonster.XP = 0;
					levelText = "\n" + TaskMonster.Name + " leveled up!";
				}

				Heist.TimesCompleted++;
				MessageBox.Show("Heist Completed",
					"Successfully completed " + Heist.Name + "!" +
					"\nMoney gained: " + profit.ToString("C0") + "." +
					"\n" + TaskMonster.Name + " XP gained: " + xpBoost + "." + levelText);
			}
		}
		else if(MonsterTask == MonsterTaskTypes.Training)
		{
			if(TrainingStat == Stats.Strength)
			{
				TaskMonster.Strength++;
			}
			else if(TrainingStat == Stats.Agility)
			{
				TaskMonster.Agility++;
			}
			else if(TrainingStat == Stats.Vitality)
			{
				TaskMonster.Vitality++;
			}
			else if(TrainingStat == Stats.Stealth)
			{
				TaskMonster.Stealth++;
			}
		}

		Day++;

		ResetPlayerTask();
		ResetMonsterTask();
		CreateMonster.UpdateDropdown();
	}
}


public enum PlayerTaskTypes
{
	None,
	CollectAnimals,
	CreateMonsters,
	FuseAnimals
}

public enum MonsterTaskTypes
{
	None,
	Heist,
	Training
}

public enum Stats
{
	None,
	Strength,
	Agility,
	Vitality,
	Stealth
}