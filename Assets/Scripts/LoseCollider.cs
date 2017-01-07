using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls what should happen if we lose
public class LoseCollider : MonoBehaviour {
	// To access methods of our LevelManager class
	private LevelManager levelManager;

	// If triggered, find the gameobject of type LevelManager and load the lose screen
	private void OnTriggerEnter2D(Collider2D trigger)
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		print("Trigger");
		levelManager.LoadLevel("Lose Screen");
	}
}
