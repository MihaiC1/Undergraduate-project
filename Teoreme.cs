//Cod sursa aplicare teoreme fizice

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Teoreme : MonoBehaviour
{


	private Text rezultat;
	private float valoareI = 0f;
	private float valoare_r = 0f;
	private float valoareE = 0f;
	private float valoareU = 0f;
	private List<GameObject> rezistente = null;
	private List<GameObject> fire = null;
	private float rezistentaEchivalenta = 0f;
	public void Start()
	{
		rezistente = SelectareElement.getListaRezistente();
		fire = Click.getListaFire();
		rezultat = GameObject.Find("Rezultate").GetComponentInChildren<Text>();
	}

	public void folosireFunctii(int val)
	{
		switch (val)
		{
			case 1:
				{
					calculeazaRechivalent();
					break;
				}
			case 2:
				{
					legeaLuiOhm();
					break;
				}

		}
	
	}  
	public float calculeazaRechivalent()
	{

		float delta = 1f;
		float sumaRezistenteSerie = 0;
		float sumaRezistenteParalel = 0;
		float produsRezistente = 1;
		float rParalel = 0;

		List<GameObject> rezistenteInSerie = new List<GameObject>();
		List<GameObject> rezistenteInParalel = new List<GameObject>();

		for (int i= 1; i<rezistente.Count; i++) 
		{
			

			if (!Click.isParalel(rezistente[i], rezistente[i - 1]))
			{
				if (!rezistenteInSerie.Contains(rezistente[i]))
				{
					rezistenteInSerie.Add(rezistente[i]);
				}
				if (!rezistenteInSerie.Contains(rezistente[i-1]))
				{
					rezistenteInSerie.Add(rezistente[i-1]);
				}
				
			}

			else if (Click.isParalel(rezistente[i], rezistente[i - 1]))
			{
				if (!rezistenteInParalel.Contains(rezistente[i]))
				{
					rezistenteInParalel.Add(rezistente[i]);
				}
				if (!rezistenteInParalel.Contains(rezistente[i - 1]))
				{
					rezistenteInParalel.Add(rezistente[i - 1]);
				}
			}
		
			
		}
		
		if (rezistenteInSerie.Count > 0)
		{
			for (int i = 0; i < rezistenteInSerie.Count; i++)
			{
				if (true)
				{		
					sumaRezistenteSerie += rezistenteInSerie[i].GetComponent<SelectareElement>().getValoare();
				}
				
			}
		}
		if (rezistenteInParalel.Count > 0)
		{
			
			for (int i = 0; i < rezistenteInParalel.Count; i++)
			{
				if (true)
				{
					produsRezistente *= rezistenteInParalel[i].GetComponent<SelectareElement>().getValoare(); 
					sumaRezistenteParalel += rezistenteInParalel[i].GetComponent<SelectareElement>().getValoare();
				}

			}
		}
		
		if (sumaRezistenteParalel != 0)
		{
			rParalel = produsRezistente / sumaRezistenteParalel;
		}

		rezistentaEchivalenta = sumaRezistenteSerie + rParalel;
		rezultat.text = ("In acest circuit exista " + rezistenteInSerie.Count + " rezistente in serie si " +rezistenteInParalel.Count +" rezistente in paralel. "+ "\nR echivalent = " + rezistentaEchivalenta);
		return rezistentaEchivalenta;
	}

	private float getRezistentaEchivalenta()
	{
		return rezistentaEchivalenta;
	}
	public void legeaLuiOhm()
	{
		GameObject fereastraProprOhm = GameObject.Find("Fereastra Ohm");
		fereastraProprOhm.transform.position = new Vector3(8f, 3f, 0);

	}

	
	public void aplicaLegeaLuiOhm()
	{
		List<GameObject> surse = SelectareElement.getListaSurse();
		
		if (surse.Count != 0)
		{
			
			foreach (GameObject sursa in surse)
			{
				if (sursa.GetComponentInChildren<SelectareElement>().getValoare_E() != 0 && sursa.GetComponentInChildren<SelectareElement>().getValoare_r() != 0)
				{
					valoareE = sursa.GetComponentInChildren<SelectareElement>().getValoare_E();
					valoare_r = sursa.GetComponentInChildren<SelectareElement>().getValoare_r();
				}
				else
				{
					valoare_r = gameObject.GetComponent<LegeaLuiOhm>().getValoare_r();
					valoareE = gameObject.GetComponent<LegeaLuiOhm>().getValoare_E();
				}
				
			}
		}
		else
		{
			
			valoare_r = gameObject.GetComponent<LegeaLuiOhm>().getValoare_r();
			valoareE = gameObject.GetComponent<LegeaLuiOhm>().getValoare_E();
		}
		
		valoareI = gameObject.GetComponent<LegeaLuiOhm>().getValoareI();
		valoareU = gameObject.GetComponent<LegeaLuiOhm>().getValoare_U();
		
		

		rezistentaEchivalenta =calculeazaRechivalent();

		

		if (valoareE != 0 && valoareI != 0 && valoare_r != 0 && valoareU ==0 || valoareU == -1)
		{
			//afla U
			valoareU = valoareE - (valoare_r * valoareI);
			Debug.Log("Valoarea tensiunii U este " + valoareU + "V");
			rezultat.text = "Valoarea tensiunii U este " + valoareU + "V";
		}
		else if (valoareI != 0 && valoare_r ==0 && valoareE ==0)
		{
			Debug.Log(rezistentaEchivalenta);
			valoareU = rezistentaEchivalenta * valoareI;
			rezultat.text = "Valoarea tensiunii U este " + valoareU + "V";
		}
		else if (valoareU != 0 && valoareI != 0 && valoare_r != 0 && valoareE == 0 || valoareE == -1)
		{
			//aflu E
			valoareE = valoareU + (valoare_r * valoareI);
			rezultat.text = "Valoarea tensiunii electromotoare E este " + valoareE + "V";
		}
		else if (valoareI != 0 && valoare_r != 0)
		{
			valoareE = (valoareI * rezistentaEchivalenta) + (valoare_r * valoareI);
			valoareU = valoareI * rezistentaEchivalenta;
			rezultat.text = "Valoarea tensiunii electromotoare E este " + valoareE + "V" + "\n Valoarea tensiunii U este " + valoareU + "V.";
		}
		else if (valoareU != 0 && valoareI != 0 && valoareE != 0 && valoare_r == 0 || valoare_r == -1)
		{
			//aflu r
			valoare_r = (valoareE - valoareU) / (valoareI);
			rezultat.text = "Valoarea rezistentei interne, r, a sursei este " + valoare_r + "Ohm";
		}
		else if (valoareI != 0 && valoareE != 0)
		{
			valoare_r = (valoareE - (valoareI*rezistentaEchivalenta)) / (valoareI);
			valoareU = valoareI * rezistentaEchivalenta;
			rezultat.text = "Valoarea rezistentei interne, r, a sursei este " + valoare_r + "Ohm" + "\n Valoarea tensiunii U este " + valoareU + "V.";
		}
		else if (valoareU != 0 && valoareE != 0 && valoare_r != 0 && valoareI == 0 || valoareI == -1)
		{
			//aflu I
			valoareI = (valoareE-valoareU) / valoare_r;
			rezultat.text = "Valoarea intensitatii electrice I este " + valoareI + "A";
		}
		else if (valoareE != 0 && valoare_r != 0)
		{
			valoareI = valoareE / (valoare_r + rezistentaEchivalenta);
			valoareU = valoareI * rezistentaEchivalenta;
			rezultat.text = "Valoarea intensitatii electrice I este " + valoareI + "A. " + "\n Valoarea tensiunii U este " + valoareU + "V.";
		}
		else
		{
			rezultat.text = "Eroare in preluarea parametrilor. " + "\nI= " + valoareI + "U= " + valoareU + "r = " + valoare_r + "E= " + valoareE;
		}
		
	}

	
	public void closeWindow()
	{
		gameObject.transform.position = new Vector3(8f, 15f, 0f);
	}


	

}
