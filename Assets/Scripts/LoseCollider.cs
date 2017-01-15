using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoseCollider : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D trigger)
	{
		print ("Trigger"); 
		LevelManager.LoadLevel ("Level_01");


	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		print ("Collision");
		print (collision.transform);
	}




}

