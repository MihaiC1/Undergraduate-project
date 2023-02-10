//Cod sursa buton "Inapoi"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EcranPrincipal : MonoBehaviour
{
	public void intoarcereMeniuPrincipal()
	{
		SceneManager.LoadScene("Meniu");
	}
}
