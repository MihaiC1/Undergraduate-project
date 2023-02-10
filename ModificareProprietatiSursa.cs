//Cod sursa modificarea proprietatilor sursei

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModificareProprietatiSursa : MonoBehaviour
{
	float valoareTensiune;
	float valoareRinterior;
	private InputField valoareIntrodusa = null;

	public void setareValoare_E()
	{
		InputField iF = gameObject.GetComponentInChildren<InputField>();
		if (iF.name.Equals("Input_E"))
		{
			valoareIntrodusa = iF;
			List<GameObject> surse = SelectareElement.getListaSurse();
			if (float.TryParse(valoareIntrodusa.text, out float x))
			{
				valoareTensiune = float.Parse(valoareIntrodusa.text);
				string nume = gameObject.transform.parent.name.Substring(gameObject.transform.parent.name.IndexOf("S"));
				foreach (GameObject s in surse)
				{
					if (s.name.Equals(nume))
					{
						
						s.GetComponent<SelectareElement>().setValoare_E(valoareTensiune);
					}
				}

			}
		}
		
	}
	public void setareValoare_r()
	{
		InputField iF = gameObject.GetComponentInChildren<InputField>();
		if (iF.name.Equals("Input_r"))
		{
			valoareIntrodusa = iF;
			List<GameObject> surse = SelectareElement.getListaSurse();

			if (float.TryParse(valoareIntrodusa.text, out float x))
			{
				valoareRinterior = float.Parse(valoareIntrodusa.text);
				
				string nume = gameObject.transform.parent.name.Substring(gameObject.transform.parent.name.IndexOf("S"));
				foreach (GameObject s in surse)
				{
					
					if (s.name.Equals(nume))
					{
						s.GetComponent<SelectareElement>().setValoare_r(valoareRinterior);
						
					}
				}

			}
		}
	}
	public float getValoareTensiune()
	{
		
		return valoareTensiune;
	}
	public float getValoareRinterior()
	{
		return valoareRinterior;
	}

}
