using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
	public int brickHealth;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	private Ball ball;

	void Start ()
	{
		if (this.tag == "Breakable") {
			breakableCount++;
		}
		ball = FindObjectOfType<Ball> ();
		brickHealth = hitSprites.Length + 1;
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
			brickHealth -= ball.GetDamage ();

			if (brickHealth <= 0) {


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
		int spriteIndex = brickHealth - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent <SpriteRenderer> ().sprite = hitSprites [spriteIndex]; 
		} else {
			Debug.LogError ("Sprite missing in hitSprites Array ");
		}
	}
}

