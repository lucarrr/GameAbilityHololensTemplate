using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndFly : MonoBehaviour
{
    public GameObject correctObjectToSpawn; // Reference to the object to spawn
    public GameObject wrongObjectToSpawn; // Reference to the object to spawn
    public float minDelay = 1f; // Minimum delay before flying
    public float maxDelay = 3f; // Maximum delay before flying
    public float flySpeed = 15f; // Speed at which the object flies vertically
    private GameObject spawnedObject; 

    private void Start()
    {
        // Start the coroutine to spawn and fly
        StartCoroutine(SpawnAndFlyObject());
    }

    IEnumerator SpawnAndFlyObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay)); // Wait for a random time
            var pick = Random.Range(0, 2);
            if (pick == 0) spawnedObject = Instantiate(correctObjectToSpawn, transform.position, Quaternion.identity); // Spawn the correct object
            else spawnedObject = Instantiate(wrongObjectToSpawn, transform.position, Quaternion.identity); // Spawn the wrong object
            
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>(); // Get the Rigidbody component

            if (rb != null)
            {
                // Fly the object vertically
                rb.AddForce(Vector3.up * flySpeed);
            }
            else
            {
                Debug.LogWarning("Rigidbody component not found on the spawned object.");
            }

            yield return new WaitForSeconds(maxDelay);
            // Optionally destroy the spawned object after some time
            Destroy(spawnedObject);
        }
        
    }
}
