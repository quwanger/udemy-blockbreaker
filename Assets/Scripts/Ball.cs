using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ball physics
public class Ball : MonoBehaviour {
	// Prefabs will lose connection every time we create a copy of it
	// so we use a private variable of the class that we want to reference...
	private Paddle paddle;

	public static bool hasStarted = false;
	private Vector3 paddleToBallVector;

	void Start () {
		// And find it here. This way it finds the gameObject we want at runtime
		paddle = GameObject.FindObjectOfType<Paddle>();

		// We use this vector to determine the correct position to lock the ball
		// We subtract the paddles position to the balls position (since the ball is above the paddle)
		// to determine the distance between their pivots
		paddleToBallVector = this.transform.position - paddle.transform.position;		
	}
	
	void Update () {
		// If game hasn't started, that is, the player hasn't clicked the left mouse button...
		if (!hasStarted)
		{
			// Lock the ball to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for a mouse press to launch
			if (Input.GetMouseButtonDown(0))
			{
				print("Mouse clicked, launch ball");
				// Set it to true so that as it runs through update again, it knows to release the
				// ball with some velocity and not lock it down again
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2.0f, 10.0f);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 tweak = new Vector2(Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f));

		print(tweak);

		if (hasStarted)
		{
			this.GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
