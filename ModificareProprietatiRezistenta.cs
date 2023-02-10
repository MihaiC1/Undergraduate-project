//Cod sursa modificarea proprietatilor rezistorilor

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModificareProprietatiRezistenta : MonoBehaviour
{
	private InputField valoareIntrodusa = null;
	private float valoareRezistenta = 0;
	

	public void setareValoare()
	{
		valoareIntrodusa = gameObject.GetComponentInChildren<InputField>();
		List<GameObject> rezistente = SelectareElement.getListaRezistente();

		if (float.TryParse(valoareIntrodusa.text, out float x))
		{
			valoareRezistenta = float.Parse(valoareIntrodusa.text);
			string nume = gameObject.transform.parent.name.Substring(gameObject.transform.parent.name.IndexOf("R"));
			foreach(GameObject r in rezistente)
			{
				if (r.name.Equals(nume))
				{
					Debug.Log(r.name);
					r.GetComponent<SelectareElement>().setValoare(valoareRezistenta);
				}
			}
			
		}

	}
	public float getValoare()
	{
		return valoareRezistenta;
	}


}
