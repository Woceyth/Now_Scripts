using UnityEngine;
using System.Collections;

public class EnemieAI : MonoBehaviour 
{
	public Vector3 originalPosition;
	public GameObject treasure;
	public GameObject gameManager;
	public float speed;
	public float minSpeed;
	public float maxSpeed;
	public bool move;

	// Use this for initialization
	void Awake ()
	{
		originalPosition = gameObject.transform.localPosition;
		minSpeed = 3;
		maxSpeed = 6;
	}

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable()
	{
//		Debug.Log ("Start running");
		speed = Random.Range(minSpeed, maxSpeed);
//		Debug.Log ("Speed is: "+ speed);
		move = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( move == true )
		{
			MoveToTreasure ();	
		}
	}

	/// <summary>
	/// Moves this game object to the treasure.
	/// </summary>
	void MoveToTreasure()
	{
		gameObject.transform.localPosition = Vector3.MoveTowards ( gameObject.transform.localPosition, treasure.transform.localPosition, Time.deltaTime * speed );
	}

	/// <summary>
	/// Raises the disable event.
	/// </summary>
	void OnDisable()
	{
		gameObject.transform.localPosition = originalPosition;
	}

	/// <summary>
	/// Dissapears Animation ended. Add score and deactivate this game object
	/// </summary>
	void DissapearAnimationEnded()
	{
		gameObject.GetComponent<Animator>().SetBool("Stopped", false);
		gameManager.GetComponent<GameManager>().score++;
		gameObject.SetActive (false);
	}
}
