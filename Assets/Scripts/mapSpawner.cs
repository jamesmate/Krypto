using UnityEngine;
using System.Collections;

public class mapSpawner : MonoBehaviour
{
    public GameObject[] prefabs;

    mapTrigger hasTriggered;

	PlayerMovement map;

    void Start()
    {
        hasTriggered = GameObject.FindGameObjectWithTag("Trigger").GetComponent<mapTrigger>();
		map = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
    }

    void Update()
    {
        if (hasTriggered.Triggered == true)
        {
            Spawn();
            hasTriggered.Triggered = false;
        }
    }

    void Spawn()
    {
		while (map.i == map.lastLoaded) 
		{
			map.i = Random.Range (0, prefabs.GetLength (0));
		}

		Instantiate (prefabs [map.i], transform.position, Quaternion.identity);
		map.lastLoaded = map.i;
    }
}









