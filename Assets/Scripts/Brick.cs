using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
	public int timesHit = 0;
	public Sprite[] hitSprites;

	// Use this for initialization
	void OnCollisionEnter2D (Collision2D trigger)
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;  

		if (timesHit >= maxHits) {
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}


	}

	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent <SpriteRenderer> ().sprite = hitSprites [spriteIndex]; 
		}
	}
}

