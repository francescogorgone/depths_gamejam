using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Serializable]
    public class SpawnObject {
        public GameObject spawnObject;
        public float probability;
    }

    [SerializeField] private List<SpawnObject> spawnObjects = new List<SpawnObject>();
    [SerializeField] float spawnTime;

    private float lastSpawnTime;
    private float currentSpawnTimer;
    private float[] probabilities; 
    private float IncSpawn=0;

    // Start is called before the first frame update
    void Start()
    {
        probabilities = new float[spawnObjects.Count];

        float current_probability = 0.0f;
        for(int index=0; index<spawnObjects.Count; ++index)
        {
            current_probability += spawnObjects[index].probability;
            probabilities[index] = current_probability;
        }

        lastSpawnTime = 0;
        currentSpawnTimer = spawnTime + IncSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        lastSpawnTime += Time.deltaTime;

        if(lastSpawnTime > currentSpawnTimer){

            float spawnX = UnityEngine.Random.Range(-20.0f,20.0f);
            float spawnY = 0.98f;
            float spawnZ = UnityEngine.Random.Range(-20.0f,20.0f);
            Vector3 spawnPoint = new Vector3(spawnX,spawnY,spawnZ);

            // Determine which object to spawn
            float spawnRandom = UnityEngine.Random.Range(0.0f,2.0f);
            int index = 0;
            while(index<probabilities.Length && spawnRandom > probabilities[index]){
                ++index;
            }

            if(index < probabilities.Length){
                GameObject newObject = Instantiate(spawnObjects[index].spawnObject);
                newObject.transform.position = spawnPoint;
            } else {
                Debug.Log("Spawner: Probability out of range");
            }

            IncSpawn ++;
            lastSpawnTime = 0;
            currentSpawnTimer = spawnTime + UnityEngine.Random.Range(-1.0f,1.0f);
        }
        
    }
}