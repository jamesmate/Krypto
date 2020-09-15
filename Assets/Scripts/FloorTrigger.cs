using UnityEngine;
using System.Collections;

public class FloorTrigger : MonoBehaviour
{

    public Rigidbody2D rb2d;

    public float Acceleration;
    public int delayTime;

    private float currentSpeed;
    private float maxSpeed = 1000;

    void FixedUpdate()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;

        var velocity = rb2d.velocity;
        currentSpeed = velocity.magnitude;

        Invoke("move", delayTime);
    }

    void move()
    {
        if (currentSpeed < maxSpeed)
        {
            rb2d.AddForce(new Vector2(Acceleration * Time.deltaTime, 0));
        }
    }
}
