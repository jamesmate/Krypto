using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb2d; // assign the rigidbody on the player

    public float Acceleration;
    public float MaxSpeed;
    public float JumpPower;
	public float RollPower;

    private bool Jumps = true; // bool for telling whether player is on the ground or not 

    private float CurrentSpeed = 0f; // declare & assign current speed to start at 0

	private float fps;

    void FixedUpdate() // if using rigidbody physics, use fixed update
    {
		fps = 1.0f / Time.deltaTime; // fps counter
		Debug.Log(fps);

		MaxSpeed = MaxSpeed + (Time.fixedDeltaTime /4); // slow increase of max speed over time

        if (CurrentSpeed < MaxSpeed) // if not at max speed value 
        {
			rb2d.AddForce(new Vector2(Acceleration * Time.deltaTime, 0)); // apply acceleration force to the player
        }

		var velocity = rb2d.velocity; // local variable velocity - get from the players rigidbody
        CurrentSpeed = velocity.magnitude; // current speed is the players velocity * magnitude

        if (Input.GetKeyDown(KeyCode.Space) && Jumps == true) // if space is pressed and player is on the ground 
        {
			rb2d.velocity = new Vector2(rb2d.velocity.x, JumpPower); // add force JumpPower to the rigidbody

            Jumps = false; // not on the ground 
        }

		if (Input.GetKeyDown("e")) // if e is pressed
		{
			rb2d.velocity = new Vector2 (rb2d.velocity.x, rb2d.velocity.y); // x, y 
		}
    }

    void OnCollisionEnter2D(Collision2D col) // if player collides with something (Collision2D, variable name)
    {
        if (col.gameObject.tag == "Ground") // if the object is tagged "ground"
        {
            Jumps = true; // they are on the ground 
        }
    }

}