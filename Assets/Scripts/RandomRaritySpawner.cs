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
    public float spawnY=-1.0f;  

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
            // Genera una posizione di spawn casuale per ogni zona
            Vector3 spawnPoint = Vector3.zero;

            // Scegli una zona di spawn casualmente
            int zone = UnityEngine.Random.Range(0, 3); // 0 = Left, 1 = Right, 2 = Center

            switch (zone)
            {
                case 0: // Wall Left
                    float spawnXleft = UnityEngine.Random.Range(wallLeftCollider.bounds.min.x, wallLeftCollider.bounds.max.x);
                    float spawnZleft = UnityEngine.Random.Range(wallLeftCollider.bounds.min.z, wallLeftCollider.bounds.max.z);
                    spawnPoint = new Vector3(spawnXleft, spawnY, spawnZleft);
                    break;

                case 1: // Wall Right
                    float spawnXright = UnityEngine.Random.Range(wallRightCollider.bounds.min.x, wallRightCollider.bounds.max.x);
                    float spawnZright = UnityEngine.Random.Range(wallRightCollider.bounds.min.z, wallRightCollider.bounds.max.z);
                    spawnPoint = new Vector3(spawnXright, spawnY, spawnZright); 
                    break;

                case 2: // Wall Center
                    float spawnXcenter = UnityEngine.Random.Range(wallCenterCollider.bounds.min.x, wallCenterCollider.bounds.max.x);
                    float spawnZcenter = UnityEngine.Random.Range(wallCenterCollider.bounds.min.z, wallCenterCollider.bounds.max.z);
                    spawnPoint = new Vector3(spawnXcenter, spawnY, spawnZcenter); 
                    break;
            }

            // Determina quale oggetto spawnare in base alla probabilità
            float spawnRandom = UnityEngine.Random.Range(0.0f, 1.0f); // 0.0f a 1.0f

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
            lastSpawnTime = 0;
            currentSpawnTimer = spawnTime;
        }
    }
}