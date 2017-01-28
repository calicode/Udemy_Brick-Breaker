using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseCollider : MonoBehaviour
{
	public GameObject ball;

	void OnTriggerEnter2D (Collider2D trigger)
	{
		Instantiate (ball, startpos);

		//LevelManager.lastPlayedLevel = SceneManager.GetActiveScene ().buildIndex;
		//LevelManager.LoadLevel ("Lose");


	}





}

