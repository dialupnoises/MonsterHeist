using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CollectAnimals : MonoBehaviour
{
	public long MinPrice = 50;
	public long MaxPrice = 100000000000;

	public Text LeftLabel;
	public Text RightLabel;
	public Slider CashSlider;
	public GameObject AnimalPanel;
	public GameObject CoverUp;
	public PlayerButtons PlayerButtons;
	public GameManager GameManager;
	public Button OKButton;

	void Start()
	{
		var rightText = MaxPrice.ToString("C");
		RightLabel.text = rightText.Substring(0, rightText.Length - 3);
	}

	void Update()
	{
		var currentValue = (long)Math.Floor((MinPrice + (MaxPrice - MinPrice) * (double)CashSlider.value) / 50) * 50;
		var currentText = currentValue.ToString("C");
		LeftLabel.text = currentText.Substring(0, currentText.Length - 3);
		OKButton.interactable = (GameManager.Money + GameManager.CollectAnimalsCash) >= currentValue;
	}

	public void OnOKButton()
	{
		GameManager.ResetPlayerTask();
		GameManager.PlayerTask = PlayerTaskTypes.CollectAnimals;
		GameManager.CollectAnimalsCash = (long)Math.Floor((MinPrice + (MaxPrice - MinPrice) * (double)CashSlider.value) / 50) * 50;
		GameManager.Money -= GameManager.CollectAnimalsCash;
		AnimalPanel.SetActive(false);
		CoverUp.SetActive(false);
	}

	public void OnCancelButton()
	{
		AnimalPanel.SetActive(false);
		CoverUp.SetActive(false);
	}
}
