using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalareFir : MonoBehaviour
{
	Vector2 offset = Vector2.zero;
	public void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(1))
		{
			gameObject.GetComponent<MutareElemente>().enabled = false;
		}
		//offset = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
		

	}
	public void OnMouseDrag()
	{
		//if (Input.GetMouseButtonDown(1))
		//{
			transform.localScale = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//}
		//
		
	}
}
