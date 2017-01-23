using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public static void LoadLevel (string name)
	{
		Debug.Log ("Loading level " + name);
		SceneManager.LoadScene (name);
		Brick.breakableCount = 0;

	}

	public void LoadLevelWrapper (string name)
	{
		LoadLevel (name);


	}

	public void QuitGame ()
	{
		Debug.Log ("quit called");
	
		Application.Quit ();
	
	}

	/// <summary>
	/// Loads the next level.
	/// </summary>
	public static void LoadNextLevel ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		Brick.breakableCount = 0;
	}

}

