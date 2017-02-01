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
		print (trigger.name);
		if (trigger.name == "Ball" || trigger.name == "Ball(Clone)") {

		
			Destroy (trigger.gameObject);
			print ("Numb of balls is" + GameObject.FindObjectsOfType<Ball> ().Length);
			BallHandling ();
		} else
			Destroy (trigger.gameObject);
	}

	void BallHandling ()
	{
		ball = FindObjectOfType<Ball> (); 
		paddle = FindObjectOfType<Paddle> ();
	
		if (PlayerStats.LoseLive ()) {

			if (GameObject.FindObjectsOfType <Ball> ().Length < 2) {
				Instantiate (ballPrefab, new Vector2 (paddle.transform.position.x, paddle.transform.position.y + .3f), Quaternion.identity);
			}
		
	
		}


	}

}