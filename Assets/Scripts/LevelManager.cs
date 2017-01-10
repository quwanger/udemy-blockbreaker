using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Manages scene transitions
public class LevelManager : MonoBehaviour {

	// To load levels manually using the inspector on button click
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		// Reset teh breakable count and game start on every load.
		// This makes sure the breakable count is counted on every scene load and
		// the ball will stick to the paddle waiting for user input
		Brick.breakableCount = 0;
		Ball.hasStarted = false;
		SceneManager.LoadScene(name);
	}

	// If the quit button is pressed, then we close it
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	// Load the next scene by getting the active scene's build index
	// and increment by 1 provided it's ordered correctly in the build settings
	public void LoadNextLevel()
	{
		Brick.breakableCount = 0;
		Ball.hasStarted = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	// If all the bricks are destroyed, load the next level
	// Note this is using the static variable we created in Brick.cs
	// We don't need to create an instance of it because it's a static
	// meaning we can reference it anywhere from any class and it will retain its value
	public void BrickDestroyed()
	{
		if (Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}

}
