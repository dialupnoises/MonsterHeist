using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GhettoButton : MonoBehaviour
{
	public GameObject TitleObject;

	public void OnPointerEnter()
	{
		TitleObject.SetActive(true);
	}

	public void OnPointerExit()
	{
		TitleObject.SetActive(false);
	}
}