using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the background music
public class MusicPlayer : MonoBehaviour {
	// Static variables shares its value with all instances of its class.
	// So if MusicPlayer were to be duplicated, this variable instance would persist across them
	static MusicPlayer instance = null;

	void Awake()
	{
		Debug.Log("Music player Awake " + GetInstanceID());

		// Singleton pattern
		// 1st run through, it will set the static var instance to this instance of MusicPlayer
		// and we make sure it doesn't get destroyed
		// Next time this script gets called, it will see that an instance already exists (!= null)
		// so it will destroy the instance it just created.
		// Singleton patterns ensure that only one instance of a class exists at all times
		// We do this on Awake to make sure that the MusicPlayer class runs before everything else
		if (instance != null)
		{
			Destroy(gameObject);
			print("Duplicate music player self-destructing");
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	void Start () {
		Debug.Log("Music player Start " + GetInstanceID());
	}
}
