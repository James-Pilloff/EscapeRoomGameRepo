using UnityEngine;
using System.Collections;

public class Mouse: MonoBehaviour 
{
	Vector3 pos;

	// Use this for initialization
	void Start() 
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pos.z = 0;
		transform.position = pos;

		GetComponent<Collider2D>().enabled = Input.GetMouseButton(0);
	}
}