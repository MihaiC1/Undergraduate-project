//Cod sursa aplicare formule aferente legii lui Ohm

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LegeaLuiOhm : MonoBehaviour
{
	private float valoareI = 0f;
	private float valoare_r = 0f;
	private float valoare_E = 0f;
	private float valoare_U = 0f;
	private TMP_InputField[] inputFields = null;


	public void Start()
	{
		inputFields = gameObject.GetComponentsInChildren<TMP_InputField>();
	}

	public void setValoareI()
	{
		
		foreach (TMP_InputField i in inputFields)
		{
			if (i.name.Equals("Input I"))
			{
				valoareI = float.Parse(i.text);
			}
		}


	}
	public float getValoareI()
	{
		return valoareI;
	}

	public void setValoare_r()
	{
		foreach (TMP_InputField i in inputFields)
		{
			if (i.name.Equals("Input r"))
			{
				valoare_r = float.Parse(i.text);
			}
		}

	}
	public float getValoare_r()
	{
		return valoare_r;
	}

	public void setValoare_E()
	{
		foreach (TMP_InputField i in inputFields)
		{
			if (i.name.Equals("Input E"))
			{
				valoare_E = float.Parse(i.text);
			}
		}

	}
	public float getValoare_E()
	{
		return valoare_E;
	}

	public void setValoare_U()
	{
		foreach (TMP_InputField i in inputFields)
		{
			if (i.name.Equals("Input U"))
			{
				valoare_U = float.Parse(i.text);
			}
		}

	}
	public float getValoare_U()
	{
		return valoare_U;
	}
}
