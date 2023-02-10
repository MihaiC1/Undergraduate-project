//Cod sursa mutare ferestre de proprietati


using UnityEngine;
using UnityEngine.EventSystems;

public class MutareUI : MonoBehaviour
{

	Vector2 offset = Vector2.zero;
	public void OnMouseDown()
	{
		offset = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;

	}
	public void OnMouseDrag()
	{
		transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
	}
	public void closeWindow()
	{
		gameObject.SetActive(false);
	}
}
