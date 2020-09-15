using UnityEngine;
using System.Collections;

public class mapTrigger : MonoBehaviour {

    public bool Triggered = false;

    void OnTriggerEnter2D(Collider2D spawn)
    {
        if(spawn.gameObject.name == "Player")
        {
            Triggered = true;
            Destroy(gameObject);
        }
    }

}
