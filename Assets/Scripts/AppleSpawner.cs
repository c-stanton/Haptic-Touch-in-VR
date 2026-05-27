using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [Header("Apple Prefabs")]
    public GameObject RedApple; 
    public GameObject YellowApple;
    public GameObject GreenApple;
    
    [Header("Spawn Settings")]
    public int totalApples = 80;
    public float spawnHeightY = 1.0f;
    public float timeBetweenSpawns = 0.05f;

    void Start()
    {   
        StartCoroutine(SpawnApples());
    }

    IEnumerator SpawnApples()
    {
        Vector3 spawnerPos = transform.position;

        for (int i = 0; i < totalApples; i++)
        {
            float randomX = spawnerPos.x + Random.Range(-0.1f, 0.1f);     
            float randomZ = spawnerPos.z + Random.Range(-0.1f, 0.1f);
            float targetY = spawnerPos.y + spawnHeightY;
            Vector3 spawnPosition = new Vector3(randomX, targetY, randomZ);
            Quaternion randomRotation = Random.rotation;
            GameObject spawnedApple = null;

            if (i % 3 == 0) 
            {
                spawnedApple = Instantiate(RedApple, spawnPosition, randomRotation);
            }
            else if (i % 3 == 1)
            {
                spawnedApple = Instantiate(YellowApple, spawnPosition, randomRotation);
            }
            else if (i % 3  == 2)
            {
                spawnedApple = Instantiate(GreenApple, spawnPosition, randomRotation);
            }

            if (spawnedApple != null)
            {
                spawnedApple.tag = "Apple";

                if (spawnedApple.GetComponent<Collider>() == null) spawnedApple.AddComponent<SphereCollider>();
                if (spawnedApple.GetComponent<Rigidbody>() == null) spawnedApple.AddComponent<Rigidbody>();
                
            }

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}