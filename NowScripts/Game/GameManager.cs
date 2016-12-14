using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public int score;
	public GameObject pointsText;

	// Use this for initialization
	void Start () 
	{
		score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		pointsText.transform.GetChild(1).GetComponent<TextMesh>().text = score.ToString();
	}
}
