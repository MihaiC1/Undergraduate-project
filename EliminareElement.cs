//Cod sursa eliminare element din zona de lucru

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EliminareElement : MonoBehaviour
{
	public Text afisare;
	string nume = null;
	public void eliminareElementDinScena()
	{

		if (gameObject.name.Contains(" rezistenta "))
		{
			nume = gameObject.name.Remove(0, 23);
			SelectareElement.stergeDinListaRezistente(GameObject.Find(nume));
			Destroy(GameObject.Find(nume));
			Destroy(gameObject);
			afisare.text = ("Rezistor eliminat cu succes.");
		}
		else if (gameObject.name.Contains(" sursa "))
		{
			nume = gameObject.name.Remove(0, 18);
			SelectareElement.stergeDinListaSurse(GameObject.Find(nume));
			Destroy(GameObject.Find(nume));
			Destroy(gameObject);
			afisare.text = ("Sursa eliminata cu succes.");
		}
		else if (gameObject.name.Contains(" fir "))
		{
			nume = gameObject.name.Remove(0, 16);
			Click.stergeDinListaFire(GameObject.Find(nume));
			Destroy(GameObject.Find(nume));
			Destroy(gameObject);
			afisare.text = ("Fir eliminat cu succes.");
		}

	}
}
