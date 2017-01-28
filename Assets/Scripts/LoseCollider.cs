using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoseCollider : MonoBehaviour
{
	private Ball ball;
	public GameObject ballPrefab;
	private Paddle paddle;




	void OnTriggerEnter2D (Collider2D trigger)
	{
		BallHandling ();
	}


	void BallHandling ()
	{
		ball = FindObjectOfType<Ball> (); 
		paddle = FindObjectOfType<Paddle> ();
	
		if (PlayerStats.LoseLive ()) {
			Destroy (ball);

			if (GameObject.FindObjectsOfType <Ball> ().Length < 2) {
				Instantiate (ballPrefab, new Vector2 (paddle.transform.position.x, paddle.transform.position.y + .3f), Quaternion.identity);
			}
		
		} else {
			Destroy (ball);
		}
	
	}


}

