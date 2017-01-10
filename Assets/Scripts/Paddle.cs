using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Paddle behaviour
public class Paddle : MonoBehaviour {
	public bool autoPlay = false;
	public float min, max;

	private Ball ball;

	private void Start()
	{
		ball = GameObject.FindObjectOfType<Ball>();
	}

	void Update () {
		if (!autoPlay)
		{
			MoveWithMouse();
		} else
		{
			AutoPlay();
		}
	}

	void MoveWithMouse()
	{
		// Create a Vector3 that will will use to set the position of the paddle.
		// In this case, we need to set the paddle to the current y position of the paddle
		// in the scene since it doesn't move veritcally
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

		// We've determined the game size to be 16 units wide so to get nice numbers
		// we divide the Input.mousePos.x (returns in pixel value) by the width of the screen which gives a value from 0 - 1
		// then multiply that by 16
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width) * 16;

		// We clamp to make sure it doesn't go past the left/right side of the screen.
		// Starts at 0.5f because our paddle's pivot is in the center of the brick, which is equal to 1 unit
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, min, max);

		// Set the position of the paddle to paddlePos which now has a x value that is controlled by the user
		// and a y value that we've captured from the scene
		this.transform.position = paddlePos;
	}

	void AutoPlay()
	{
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

		// Similar to MoveWithMouse function but this time we want to track the x position
		// of the ball, not the mouse
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, min, max);
		this.transform.position = paddlePos;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (Ball.hasStarted)
		{
			this.GetComponent<AudioSource>().Play();
		}
	}
}
