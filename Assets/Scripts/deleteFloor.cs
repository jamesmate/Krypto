using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteFloor : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D deleteFloor) // on collision 
	{
		if (deleteFloor.gameObject.tag == "DeleteFloor") // if object hit is tagged deleteFloor
		{
			Destroy (gameObject); // delete the game object the script is attached to 
		}
	}
}