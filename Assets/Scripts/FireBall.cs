using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
	public Rigidbody2D rb;
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (Random.Range (-2.0f, 2.0f), Random.Range (-1.5f, 3.5f));
	}

	void OnCollisionEnter2D (Collision2D trigger)
	{
		

	}
	// Update is called once per frame
	void Update ()
	{
		
	}
}
