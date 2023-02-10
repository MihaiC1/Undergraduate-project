//Cod sursa afisare proprietati

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AfisareProprietati : MonoBehaviour
{
	public GameObject canvas;
	public GameObject proprietati;
	private static List<GameObject> listaFerestreProprietati = new List<GameObject>();
	GameObject fereastraPropr;
	string numeObiect = null;

	int contor = 0;
	public void OnMouseOver() 
	{
		numeObiect = gameObject.name;
	
		if (Input.GetMouseButtonDown(1))
		{
			if (proprietati != null)
			{ 
				if (!GameObject.Find(proprietati.name + gameObject.name))
				{
					fereastraPropr = Instantiate(proprietati);
					contor++;
					fereastraPropr.name = fereastraPropr.name.Remove(fereastraPropr.name.IndexOf("(")) + " " + gameObject.name;
					fereastraPropr.transform.parent = canvas.transform;
					fereastraPropr.GetComponent<RectTransform>().sizeDelta = proprietati.GetComponent<RectTransform>().sizeDelta;
					fereastraPropr.GetComponent<RectTransform>().localScale = proprietati.GetComponent<RectTransform>().localScale;
					fereastraPropr.GetComponent<RectTransform>().position = proprietati.GetComponent<RectTransform>().position;
					fereastraPropr.SetActive(true);
					listaFerestreProprietati.Add(fereastraPropr);
					
				}
				

			}
		
		}

	}
	
	public static List<GameObject> getListaFerestreProprietati()
	{
		return listaFerestreProprietati;
	}
	public static void stergeFereastraDinLista(GameObject fereastra)
	{
		listaFerestreProprietati.Remove(fereastra);
	}
	

}
