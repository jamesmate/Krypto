using UnityEngine;
using System.Collections;

public class FloorFall : MonoBehaviour
{

    bool isFalling = false; // bool to tell if floor has been touched by player
    float fallSpeed = 0;

    void OnTriggerEnter2D(Collider2D fall) // collision detection 
    {
        if (fall.gameObject.tag == "FloorTrigger")
        {
            isFalling = true;
        }
    }

    void floorFall() // falling function
    {
        if (isFalling == true) // if it has been touched by player
        {
            fallSpeed += Time.deltaTime / 3; // fall speed
            transform.position = new Vector3(transform.position.x, // transform the floors position - same x, y - fallspeed, same z
            transform.position.y - fallSpeed,
            transform.position.z);
        }
    }

    void FixedUpdate() // when the game is running (fixed update is always called at same time, update is every frame)
    {
        if (isFalling == true) // if the floor has been touched by player
        {
            Invoke("floorFall", 0.1f); // calling function ("function name as string", float time to wait)
        }
    }

}
