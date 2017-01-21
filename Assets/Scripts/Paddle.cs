using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	float mousePosInBlocks = 0;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{ 
		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, 1f, 15f);
		this.transform.position = paddlePos;



	
	}
}
