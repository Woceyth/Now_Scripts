using UnityEngine;
using System.Collections;

public class TouchableTriggerScript : MonoBehaviour 
{
	public GameObject camera;

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D collider) 
	{
		if( collider.gameObject.tag.Equals("Enemy") == true && collider.gameObject.name.Equals("Objective") == false )
		{
			camera.GetComponent<TouchCamera> ().touchable = true;
		}
	}
}
