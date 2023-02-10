//Cod sursa adaugare + stergere element din zona de lucru

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectareElement : MonoBehaviour
{

	public Button button;
	private int contor = 0;
	private float valoare = 0f;
	private float r = 0f;
	private float E = 0f;
	private static List<GameObject> listaSurse = new List<GameObject>();
	private static List<GameObject> listaRezistente = new List<GameObject>();

	public void adaugareElementInScena()
	{
		
		GameObject element = Instantiate(GameObject.Find(button.tag));
		Transform transformRezistenta = null;
		Transform transformSursa = null;

		if (listaRezistente.Contains(element))
		{
			transformRezistenta = element.transform;
		}
		if (listaSurse.Contains(element))
		{
			transformSursa = element.transform;
		}

		if (element != null)
		{
			
			if (GameObject.Find(element.name.Remove(element.name.IndexOf("(")) + contor))
			{
				element.name = element.name.Remove(element.name.IndexOf("(")) + (contor+1);
				element.transform.position = new Vector2(4f, 2f);
				contor++;

				if (!listaSurse.Contains(element) && element.name.Contains("Sursa"))
				{
					listaSurse.Add(element);

				}
				else if (listaSurse.Contains(element) && element.name.Contains("Sursa"))
				{
					updatePozitieElement(element, transformSursa);
				}

				if (!listaRezistente.Contains(element) && element.name.Contains("Rezistenta"))
				{
					listaRezistente.Add(element);

				}
				else if (listaRezistente.Contains(element) && element.name.Contains("Rezistenta"))
				{
					updatePozitieElement(element, transformRezistenta);
				}
			}
			else
			{
				element.name = element.name.Remove(element.name.IndexOf("(")) + contor;
				element.transform.position = new Vector2(4f, 2f);
				contor++;

				if (!listaSurse.Contains(element) && element.name.Contains("Sursa"))
				{
					listaSurse.Add(element);

				}
				else if (listaSurse.Contains(element) && element.name.Contains("Sursa"))
				{
					updatePozitieElement(element, transformSursa);
				}

				if (!listaRezistente.Contains(element) && element.name.Contains("Rezistenta"))
				{
					listaRezistente.Add(element);

				}
				else if (listaRezistente.Contains(element) && element.name.Contains("Rezistenta"))
				{
					updatePozitieElement(element, transformRezistenta);
				}
			}


		}

	}
	
	

	public static List<GameObject> getListaRezistente()
	{
		return listaRezistente;
	}
	public static List<GameObject> getListaSurse()
	{
		return listaSurse;
	}

	private static void removeFromListaRezistente(GameObject r)
	{
		listaRezistente.Remove(r);
	}
	public static void stergeDinListaRezistente(GameObject r)
	{
		removeFromListaRezistente(r);
	}

	private static void removeFromListaSurse(GameObject s)
	{
		listaRezistente.Remove(s);
	}
	public static void stergeDinListaSurse(GameObject s)
	{
		removeFromListaRezistente(s);
	}
	public static void updatePozitieElement(GameObject element, Transform pozitieNoua)
	{
		if (listaSurse.Contains(element))
		{	
			listaSurse.Remove(element);
			element.transform.position = pozitieNoua.position;
			listaSurse.Add(element);
		}
		if (listaRezistente.Contains(element))
		{
			listaRezistente.Remove(element);
			element.transform.position = pozitieNoua.position;
			listaRezistente.Add(element);
		}

	}

	
	public void setValoare(float v)
	{
		valoare = v;
	}
	public void setValoare_E(float v)
	{
		E = v;

	}
	public void setValoare_r(float v)
	{
		r = v;
	}
	public float getValoare_E()
	{
		return E;
	}
	public float getValoare_r()
	{
		return r;
	}
	public float getValoare()
	{
		return valoare;
	}


}
