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
            // Posizione di spawn casuale
            float spawnX;
            if (UnityEngine.Random.value < 0.5f) // 50% di probabilità per ogni intervallo
            {
                spawnX = UnityEngine.Random.Range(-7.0f, -6.0f); // Intervallo negativo
            }
            else
            {
                spawnX = UnityEngine.Random.Range(7.0f, 8.0f); // Intervallo positivo
            }
            float spawnY = 0.6f;
            float spawnZ;
            if (UnityEngine.Random.value < 0.5f) // 50% di probabilità per ogni intervallo
            {
                spawnZ = UnityEngine.Random.Range(7.0f, 1.00f); // Intervallo negativo
            }
            else
            {
                spawnZ = UnityEngine.Random.Range(7.0f, 1.0f); // Intervallo positivo
            }
            Vector3 spawnPoint = new Vector3(spawnX, spawnY, spawnZ);

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