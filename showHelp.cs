//Cod sursa afisare text ajutator

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showHelp : MonoBehaviour
{
	int nrClick = 0;
	public void showHelpText()
	{
		nrClick++;
		if (!gameObject.active)
		{
			gameObject.SetActive(true);
		}
		else
		{
			gameObject.SetActive(false);
		}
	}
}
