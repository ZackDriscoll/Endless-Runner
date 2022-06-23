using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float randomMin;
    public float randomMax;

    private GameObject spawnedObject;
    private float countdown;
    private float respawnTime;


    // Start is called before the first frame update
    void Start()
    {
        //Set a random respawn time
        respawnTime = Random.Range(randomMin, randomMax);

        //Display the respawn time in the console
        Debug.Log(respawnTime);

        countdown = respawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Countdown our timer
        countdown -= Time.deltaTime;
        //If our countdown hits zero--
        if (countdown <= 0)
        {
            //Set a random respawn time
            respawnTime = Random.Range(randomMin, randomMax);

            //Display the respawn time in the console
            Debug.Log(respawnTime);

            //Spawn (and store) the object
            spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);

            //Have the spawned object move towards the player after spawning
            spawnedObject.transform.position -= transform.right * Time.deltaTime;

            //Reset the countdown
            countdown = respawnTime;
        }
    }
}
