// Cod sursa buton start + iesire
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeniuPrincipal : MonoBehaviour
{
	public void startAplicatie()
	{
		SceneManager.LoadScene("EcranPrincipal");
	}
	public void iesireAplicatie()
	{
		Application.Quit();
	}
}
