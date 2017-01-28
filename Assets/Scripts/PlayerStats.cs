using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{


	public static int maxLives = 5;
	public static int currentLives = 5;


	public static bool LoseLive ()
	{
		if (currentLives <= 0) {

			LevelManager.LoadLevel ("Lose");
			currentLives = maxLives;
			print ("Out of lives"); 
			return false;
		} else {
			
			currentLives--;
			print ("Current lives: " + currentLives); 
			return true;
		}
	}
}
