using UnityEngine;
using System.Collections;

public class DrawCircle : MonoBehaviour 
{

	public float ThetaScale = 0.01f;
	public float radius;
	private int Size;
	private LineRenderer LineDrawer;
	private float Theta = 0f;

	void Start ()
	{       
		LineDrawer = GetComponent<LineRenderer>();

		DrawCircleRange ();
	}

	void DrawCircleRange()
	{
		radius = this.GetComponent<CircleCollider2D> ().radius;
		Theta = 0f;
		Size = (int)((1f / ThetaScale) + 1f);
		LineDrawer.SetVertexCount(Size); 
		for(int i = 0; i < Size; i++)
		{          
			Theta += (2.0f * Mathf.PI * ThetaScale);
			float x = radius * Mathf.Cos(Theta) - 1.45f;
			float y = radius * Mathf.Sin(Theta) + 3.3f;          
			LineDrawer.SetPosition(i, new Vector3(x, y, -10.1f));
		}
	}
}
