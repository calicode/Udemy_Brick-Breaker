using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
	public int timesHit = 0;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	public GameObject smoke;
	public FireBall fireBall;
	private GameObject fb;

	void Start ()
	{
		if (this.tag == "Breakable") {
			breakableCount++;
		}
	}



	// Use this for initialization
	void OnCollisionEnter2D (Collision2D trigger)
	{

		HandleHits ();
	}

	/// <summary>
	/// Handles the hits.
	/// </summary>
	void HandleHits ()
	{
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (gameObject.tag == "Breakable") {
			timesHit++;
			int maxHits = hitSprites.Length + 1;  

			if (timesHit >= maxHits) {
				GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
			
				ParticleSystem.MainModule main = smokePuff.GetComponent<ParticleSystem> ().main;
				main.startColor = GetComponent<SpriteRenderer> ().color;

				FireBall fb = (FireBall)Instantiate (fireBall, gameObject.transform.position, Quaternion.identity);
				fb.fbHealth = maxHits;
				Destroy (gameObject);
				breakableCount--;

				if (breakableCount <= 0) {
					LevelManager.LoadNextLevel ();
				}
			} else {
				LoadSprites ();
			}
		}
	}

	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent <SpriteRenderer> ().sprite = hitSprites [spriteIndex]; 
		} else {
			Debug.LogError ("Sprite missing in hitSprites Array ");
		}
	}
}

