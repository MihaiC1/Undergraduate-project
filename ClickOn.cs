using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{
    public Vector2 getPozitie()
	{
		return gameObject.transform.position;
	}

	public string getNume()
	{
		return gameObject.name;
	}
	public GameObject getGameObject()
	{
		return this.gameObject;
	}

}
