using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
	public int maxHits = 0;
	public int timesHit = 0;
	// Use this for initialization
	void OnCollisionEnter2D (Collision2D trigger)
	{
		print ("Collision triggered");
		timesHit++;

	}
}

