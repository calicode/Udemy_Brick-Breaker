﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private Vector3 paddleToBallVector;
	private Paddle paddle;
	public Rigidbody2D rb;
	private bool hasStarted = false;

	// Use this for initialization
	void Start ()
	{
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted) {

			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;

				this.rb.velocity = new Vector2 (2f, 10f);
			}
		}	
	
	}
}
