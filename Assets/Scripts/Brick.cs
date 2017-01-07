using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Brick class handles everything about it (getting hit, changing sprites, destroying...etc.)
public class Brick : MonoBehaviour {
	// Public static variable so we can access this instance in other classes
	// This variable keeps track of how many breakable bricks are left
	public static int breakableCount = 0;
	public Sprite[] hitSprites; // We load our different sprites in the inspector using an array

	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;

	// We check if this brick instance is breakable. If it is then add t
	void Start () {
		isBreakable = this.tag == "Breakable";

		// Keep track of breakable bricks in the level
		if (isBreakable)
		{
			breakableCount++;
			print(breakableCount);
		}

		// Initialize the times this brick has been hit.
		// Since it hasn't been hit yet, set it to 0
		timesHit = 0;

		// Attach the level manager to the brick as we need it to transition levels.
		// LevelManager class also needs to know what to do if there are no more breakable bricks
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	// On collision, call HandleHits()
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (isBreakable)
		{
			HandleHits();
		}
	}

	void HandleHits()
	{
		timesHit++; // If hit, increment the times it's been hit

		int maxHits; // maxHits determines how many times a brick needs to be hit before its destroyed
		maxHits = hitSprites.Length + 1; // Max hits is just the number of sprites we want + 1 since the sprite index starts at 0

		// If times hit == max hits, then there is now one less breakable brick and we destroy it.
		// We let the level manager know by checking its BrickDestroyed method
		if (timesHit >= maxHits)
		{
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		}
		// If not then load the next sprite
		else
		{
			LoadSprites();
		}
	}

	// Loads a sprite if there are still hits to be made to this brick
	void LoadSprites()
	{
		// This makes sure we reference the correct index since TimesHit starts at 1, we reference teh sprite index by substracting 1
		int spriteIndex = timesHit - 1;

		// If a sprite exists then replace it with the next sprite
		// by accessing the sprite renderer component (in the inspector) of the instance of this brick
		if (hitSprites[spriteIndex])
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
}
