using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{


	public static int maxLives = 5;
	public static int currentLives = 5;
	public static Text livesCount;

	void Start ()
	{
		livesCount = GameObject.FindObjectOfType<Text> ();
	}

	public static bool LoseLive ()
	{
		
		if (currentLives <= 1) {

			currentLives = maxLives;
			LevelManager.lastPlayedLevel = SceneManager.GetActiveScene ().buildIndex;
			LevelManager.LoadLevel ("Lose");
			return false;
		} else {
			

			currentLives--;
			livesCount.text = "Lives: " + currentLives;
			return true;
		}
	}
}
