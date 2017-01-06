using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelManager;

	private void OnTriggerEnter2D(Collider2D trigger)
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		print("Trigger");
		levelManager.LoadLevel("Win Screen");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		print("Collision");
	}
}
