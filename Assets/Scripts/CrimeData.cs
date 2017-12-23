using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CrimeData
{
	public static Crime[] Crimes =
	{
		new Crime() {
			Name = "Stealing Purse",
			MinMoney = 25,
			MaxMoney = 100,
			Enabled = true
		},
		new Crime() {
			Name = "Robbing a Gas Station",
			StrengthRequired = 3,
			AgilityRequired = 2,
			VitalityRequired = 2,
			StealthRequired = 1,
			MinMoney = 150,
			MaxMoney = 300
		},
		new Crime()
		{
			Name = "Breaking Into Home (Low Income)",
			StrengthRequired = 3,
			AgilityRequired = 3,
			VitalityRequired = 2,
			StealthRequired = 4,
			MinMoney = 100,
			MaxMoney = 500
		},
		new Crime()
		{
			Name = "Robbing Diner",
			StrengthRequired = 3,
			AgilityRequired = 3,
			VitalityRequired = 4,
			StealthRequired = 1,
			MinMoney = 400,
			MaxMoney = 800
		},
		new Crime()
		{
			Name = "Stealing a Car",
			StrengthRequired = 4,
			AgilityRequired = 3,
			VitalityRequired = 2,
			StealthRequired = 3,
			MinMoney = 500,
			MaxMoney = 1000
		},
		new Crime()
		{
			Name = "Rob an ATM",
			StrengthRequired = 6,
			AgilityRequired = 4,
			VitalityRequired = 5,
			StealthRequired = 3,
			MinMoney = 1500,
			MaxMoney = 3000
		},
		new Crime()
		{
			Name = "Breaking Into House (Middle Income)",
			StrengthRequired = 4,
			AgilityRequired = 7,
			VitalityRequired = 6,
			StealthRequired = 7,
			MinMoney = 3000,
			MaxMoney = 8000
		},
		new Crime()
		{
			Name = "Small Bank Heist",
			StrengthRequired = 10,
			AgilityRequired = 7,
			VitalityRequired = 9,
			StealthRequired = 6,
			MinMoney = 15000,
			MaxMoney = 50000
		},
		new Crime()
		{
			Name = "Rob Pharmacy",
			StrengthRequired = 7,
			AgilityRequired = 8,
			VitalityRequired = 7,
			StealthRequired = 9,
			MinMoney = 10000,
			MaxMoney = 70000
		},
		new Crime()
		{
			Name = "Rob Large Scale Drug Lab",
			StrengthRequired = 12,
			AgilityRequired = 9,
			VitalityRequired = 10,
			StealthRequired = 13,
			MinMoney = 45000,
			MaxMoney = 200000
		},
		new Crime()
		{
			Name = "Rob Mansion",
			StrengthRequired = 11,
			AgilityRequired = 12,
			VitalityRequired = 8,
			StealthRequired = 15,
			MinMoney = 65000,
			MaxMoney = 150000
		},
		new Crime()
		{
			Name = "Hold Celebrity Hostage",
			StrengthRequired = 15,
			AgilityRequired = 11,
			VitalityRequired = 12,
			StealthRequired = 7,
			MinMoney = 125000,
			MaxMoney = 300000
		},
		new Crime()
		{
			Name = "Swiss Bank Heist",
			StrengthRequired = 18,
			AgilityRequired = 16,
			VitalityRequired = 17,
			StealthRequired = 14,
			MinMoney = 1000000,
			MaxMoney = 1000000
		}
	};
}
