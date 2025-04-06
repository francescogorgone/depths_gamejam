using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Serializable]
    public class SpawnObject
    {
        public GameObject spawnObject;
        public float probability;
    }
    [SerializeField] private BoxCollider wallLeftCollider;
    [SerializeField] private BoxCollider wallRightCollider;
    [SerializeField] private BoxCollider wallCenterCollider;

    [SerializeField] private List<SpawnObject> spawnObjects = new List<SpawnObject>();
    [SerializeField] private float spawnTime = 3.0f; // Tempo tra un spawn e l'altro

    private float lastSpawnTime;
    private float currentSpawnTimer;
    private float[] probabilities;  
    private float IncSpawn=0;

    // Start is called before the first frame update
    void Start()
    {
        // Calcola le probabilità cumulative normalizzate
        probabilities = new float[spawnObjects.Count];
        float totalProbability = 0.0f;

        // Calcola la somma totale delle probabilità
        foreach (var spawnObj in spawnObjects)
        {
            totalProbability += spawnObj.probability;
        }

        // Normalizza le probabilità per farle sommare a 1
        float current_probability = 0.0f;
        for (int i = 0; i < spawnObjects.Count; ++i)
        {
            current_probability += spawnObjects[i].probability / totalProbability;  // Normalizza
            probabilities[i] = current_probability;
        }

        lastSpawnTime = 0;
        currentSpawnTimer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        lastSpawnTime += Time.deltaTime;

        if (lastSpawnTime > currentSpawnTimer)
        {
            float spawnXleft = UnityEngine.Random.Range(wallLeftCollider.bounds.min.x, wallLeftCollider.bounds.max.x);
            // Posizione di spawn casuale
            //float spawnX;

            float spawnZleft = UnityEngine.Random.Range(wallLeftCollider.bounds.min.x, wallLeftCollider.bounds.max.x);
            // Posizione di spawn casuale
            //float spawnZ;

            float spawnXright = UnityEngine.Random.Range(wallRightCollider.bounds.min.x, wallRightCollider.bounds.max.x);
            // Posizione di spawn casuale
            //float spawnX;

            float spawnZright = UnityEngine.Random.Range(wallRightCollider.bounds.min.x, wallRightCollider.bounds.max.x);
            // Posizione di spawn casuale
            //float spawnZ;

            float spawnXcenter = UnityEngine.Random.Range(wallCenterCollider.bounds.min.x, wallCenterCollider.bounds.max.x);
            // Posizione di spawn casuale
            //float spawnX;

            float spawnZcenter = UnityEngine.Random.Range(wallCenterCollider.bounds.min.x, wallCenterCollider.bounds.max.x);
            // Posizione di spawn casuale
            //float spawnZ;
           
            Vector3 spawnPoint = new Vector3(spawnXleft, spawnY, spawnZleft);
            Vector3 spawnPoint = new Vector3(spawnXright, spawnY, spawnZright);
            Vector3 spawnPoint = new Vector3(spawnXcenter, spawnY, spawnZcenter);

            // Determina quale oggetto spawnare in base alla probabilità
            float spawnRandom = UnityEngine.Random.Range(0.0f, 1.0f); // 0.0f a 1.0f, non più 2.0f

            int index = 0;
            while (index < probabilities.Length && spawnRandom > probabilities[index])
            {
                ++index;
            }

            if (index < probabilities.Length)
            {
                // Istanzia l'oggetto selezionato
                GameObject newObject = Instantiate(spawnObjects[index].spawnObject);
                newObject.transform.position = spawnPoint;
            }
            else
            {
                Debug.Log("Spawner: Probability out of range");
            }

            // Reset del timer di spawn
            IncSpawn++;
            lastSpawnTime = 0;
            currentSpawnTimer = spawnTime+ IncSpawn;
        }
    }
}