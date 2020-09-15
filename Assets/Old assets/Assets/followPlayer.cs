using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

	public Rigidbody2D followRB2D; // locate objects rigidbody
	private float currentSpeed = 0f;
	public float maxSpeed;
	public float Acceleration;

	void FixedUpdate () 
	{
		followRB2D.constraints = RigidbodyConstraints2D.FreezePositionY; // freeze Y position - needed as its trigger and wont collide

		var velocity = followRB2D.velocity; 
		currentSpeed = velocity.magnitude; // calculate the currentspeed to cap it at ma	x speed

		maxSpeed = maxSpeed + (Time.fixedDeltaTime /0.5f); // gradual increase of max speed over time

		Invoke ("move", 5f); // wait 5 seconds, begin moving
	}

	void move() // function to move the dropper
	{
		if (currentSpeed < maxSpeed) 
		{
			followRB2D.AddForce (new Vector2 (Acceleration * Time.deltaTime, 0));
		}
	}
}
