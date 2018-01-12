using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {
	
	public float paddleSpeed = 1f;

	private Vector3 screenPoint;
	private Vector3 offset;

	float distance_to_screen;
	Vector3  pos_move;
	

	void OnMouseDrag()
	{
		distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
		transform.position = new Vector3(pos_move.x, -11.79f, 0f);
	}
	

	public void Update()
	{
		OnMouseDrag();
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		pos_move = new Vector3 (Mathf.Clamp (xPos, -19.6f, 19.6f), -11.79f, 0f);
		transform.position = pos_move;
	}


}