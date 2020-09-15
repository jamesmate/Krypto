using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody2D rb2d;

	public float Acceleration;
	public float JumpPower;

    private float MaxSpeed = 1000;
	private float RollPower;
	private bool Jumps = true;
	private float CurrentSpeed = 0f;

	public int HP = 100;

	public int i;
	public int lastLoaded;

	void FixedUpdate ()
	{
        var velocity = rb2d.velocity;
        CurrentSpeed = velocity.magnitude;

		if (HP > 0) // if the player is alive 
		{
			if (CurrentSpeed < MaxSpeed)  // hasnt reached maximum speed
			{
				rb2d.AddForce (new Vector2 (Acceleration * Time.deltaTime, 0));  // increase speed over time
			}

			if (Input.GetKeyDown (KeyCode.Space) && Jumps == true) 
			{
				rb2d.velocity = new Vector2 (rb2d.velocity.x, JumpPower);
				Jumps = false;
			}

			RollPower = CurrentSpeed / 2;

			//if (Input.GetKeyDown ("e")) 
			//{
			//	rb2d.velocity = new Vector2 (CurrentSpeed + RollPower, rb2d.velocity.y);
			//	Invoke ("Roll", 1f);
			//}
		}

		if (HP < 1) 
		{
			rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
		}
	}

    void Roll()
    {
        CurrentSpeed = CurrentSpeed - RollPower;
    }

	void OnCollisionEnter2D(Collision2D ground)
	{
		if(ground.gameObject.tag == "Ground")
		{
			Jumps = true;
		}
	}

	void OnTriggerEnter2D(Collider2D dead)
	{
		if (dead.gameObject.tag == "DeleteFloor") 
		{
			HP = 0;
		}
	}
}
