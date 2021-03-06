﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private Vector3 paddleToBallVector;
	private Paddle paddle;
	public Rigidbody2D rb;
	private bool hasStarted = false;
	AudioSource audioClip;
	private string colName;
	private int baseDamage = 1;
	private int currentDamage = 1;
	private int currentCharge = 0;
	private int baseCharge = 0;
	private int maxCharge = 10;
	private int chargeMultiplier = 5;




	// Use this for initialization
	void Start ()
	{
		audioClip = GetComponent <AudioSource> ();
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;

	}

	public void PowerUp ()
	{
		if (currentCharge < maxCharge) {
			currentCharge++;
		}

		if (currentCharge >= maxCharge && currentDamage == baseDamage) {
			currentDamage *= chargeMultiplier;

		}






	}

	public void PowerDown ()
	{
		if (currentCharge >= maxCharge) {
			currentDamage = baseDamage;
			currentCharge = baseCharge; 

		}

	}

	public int GetDamage ()
	{
		PowerUp ();
		int tempDamage = currentDamage;
		PowerDown ();
		return tempDamage;
	}


	// Update is called once per frame

	void OnCollisionEnter2D (Collision2D collision)
	{
		Vector2 velocityTweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		audioClip.Play ();
		this.rb.velocity += velocityTweak;

	}



	void Update ()
	{
		if (!hasStarted) {

			this.transform.position = paddle.transform.position + paddleToBallVector;

			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;

				this.rb.AddForce (paddle.GetMousePositionTranslated () * 30f);
			}
		}	
	
	}
}
