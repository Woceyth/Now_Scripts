using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class ConditionScript : MonoBehaviour 
{
	public GameObject enemy;
	public GameObject gameOver;
	public GameObject score;
	public GameObject camera;

	/// <summary>
	/// Raises the collision enter2d event.
	/// </summary>
	/// <param name="coll">Coll.</param>
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Enemy" ) 
		{
			Debug.Log ("Game Over");
			score.SetActive (false);
			gameOver.SetActive (true);
			gameOver.transform.GetChild(2).GetComponent<TextMesh>().text = camera.GetComponent<TouchCamera>().score.ToString();
			enemy.SetActive (false);
			camera.GetComponent<TapGesture> ().enabled = false;
			camera.GetComponent<TouchCamera> ().enabled = false;
			gameObject.SetActive (false);
		}
	}
}
