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
    public int totalApples = 100;
    public float spawnHeightY = -5.0f;
    public float verticalSpacing = 0.3f;

    [Header("Haptic Prefab")]
    public GameObject HapticPrefab;

    void Awake()
    {
        SpawnApples();
    }

    void Start()
    {   
        if (HapticPrefab != null)
        {
            Instantiate(HapticPrefab, Vector3.zero, Quaternion.identity);
        }
    }

    private void SpawnApples()
    {
        Vector3 spawnerPos = transform.position;

        for (int i = 0; i < totalApples; i++)
        {
            float randomX = spawnerPos.x + Random.Range(-0.2f, 0.2f);     
            float randomZ = spawnerPos.z + Random.Range(-0.2f, 0.2f);
            float targetY = spawnerPos.y + spawnHeightY + (i * verticalSpacing);
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
        }
    }
}