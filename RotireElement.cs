//Cod sursa rotire element cu 90 grade


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotireElement : MonoBehaviour
{
	int count = 0;
	public void rotireElement90gr()
	{
		count++;
		List<GameObject> listaElemente = new List<GameObject>();
		if (gameObject.name.Contains("rezistenta "))
		{
			string numeFereastra =gameObject.name.Replace("Proprietati rezistenta ","");
			GameObject gj = GameObject.Find(numeFereastra);

			if (gj.transform.localEulerAngles.z != 90 && count != 2)
			{
				gj.transform.localEulerAngles = new Vector3(0, 0, 90);
			}

			else if (count == 2)
			{
				gj.transform.localEulerAngles = Vector3.zero;
				count = 0;
			}
		}
		else if (gameObject.name.Contains("sursa "))
		{
			string numeFereastra = gameObject.name.Replace("Proprietati sursa ", "");
			GameObject gj = GameObject.Find(numeFereastra);

			if (gj.transform.localEulerAngles.z != 90 && count != 2)
			{
				gj.transform.localEulerAngles = new Vector3(0, 0, 90);
			}
			
			else if (count == 2)
			{
				gj.transform.localEulerAngles = Vector3.zero;
				count = 0;
			}
		}
		else
		{
			Debug.Log("Nu am gasit niciun element corelat cu fereastra de proprietati");
		}
		


	}
}
