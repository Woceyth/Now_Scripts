using UnityEngine;
using System;
using System.Collections;
using TouchScript.Gestures;

public class TouchCamera : MonoBehaviour 
{
	public int waitTimer;
	public int score;
	public bool touchable;
	float minCircleRange;
	float maxCircleRange;
	public GameObject pointsText;
	public GameObject enemie;
	public GameObject circle;

	// Use this for initialization
	void Start () 
	{
		score = 0;
		minCircleRange = 3f;
		maxCircleRange = 3.3f;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
		pointsText.GetComponent<TextMesh>().text = score.ToString();
	}

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	private void OnEnable()
	{
		// subscribe to gesture's Tapped event
		GetComponent<TapGesture>().Tapped += tappedHandler;
	}

	/// <summary>
	/// Raises the disable event.
	/// </summary>
	private void OnDisable()
	{
		// don't forget to unsubscribe
		GetComponent<TapGesture>().Tapped -= tappedHandler;
	}

	/// <summary>
	/// Tappeds the handler.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="e">E.</param>
	private void tappedHandler(object sender, EventArgs e)
	{
		if( touchable == true )
		{
//			Debug.Log ("Tapped");
			enemie.GetComponent<EnemieAI> ().move = false;
			enemie.GetComponent<EnemieAI> ().minSpeed += 0.2f;
			enemie.GetComponent<EnemieAI> ().maxSpeed += 0.4f;
			score++;
//			Set dissapear animation
			enemie.GetComponent<Animator>().SetBool("Stopped", true);
			touchable = false;
			minCircleRange -= 0.025f;
			maxCircleRange -= 0.015f;
			waitTimer = 1;
			InvokeRepeating ("WaitTimer", 0f, 1f);
			ChangeCircleRadius ();
		}
	}

	/// <summary>
	/// Changes the circle radius.
	/// </summary>
	void ChangeCircleRadius()
	{
		float newRadius = UnityEngine.Random.Range ( minCircleRange, maxCircleRange );
		circle.GetComponent<CircleCollider2D> ().radius = newRadius;
		circle.SendMessage ("DrawCircleRange");
	}

	/// <summary>
	/// Waits the timer.
	/// </summary>
	void WaitTimer()
	{
		if (waitTimer == 0) 
		{
			CancelInvoke ("WaitTimer");
			enemie.SetActive (true);
		}
		else 
		{
			waitTimer--;
		}
	}
}
