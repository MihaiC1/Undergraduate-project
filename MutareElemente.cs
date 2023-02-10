//Cod sursa mutare elemente prin zona de lucru

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MutareElemente : MonoBehaviour
{
	Vector2 offset = Vector2.zero;
	public void OnMouseDown()
	{
		offset = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
		
	}
	public void OnMouseDrag()
	{
		transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
		SelectareElement.updatePozitieElement(this.gameObject, transform);
	}

}
