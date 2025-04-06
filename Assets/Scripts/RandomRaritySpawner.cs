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
    public float spawnY=0.0f;  

    // Start is called before the first frame update
    void Start()
    {
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
                float xOffset = wallLeftCollider.transform.position.x;
                float zOffset = wallLeftCollider.transform.position.z;
                    float spawnXleft = UnityEngine.Random.Range(wallLeftCollider.bounds.min.x, wallLeftCollider.bounds.max.x);
                    float spawnZleft = UnityEngine.Random.Range(wallLeftCollider.bounds.min.z, wallLeftCollider.bounds.max.z);
                    spawnPoint = new Vector3(spawnXleft, 0, spawnZleft);
                    break;

                case 1: // Wall Right
                    float spawnXright = wallRightCollider.transform.position.x+UnityEngine.Random.Range(wallRightCollider.bounds.min.x, wallRightCollider.bounds.max.x);
                    float spawnZright = wallRightCollider.transform.position.z+UnityEngine.Random.Range(wallRightCollider.bounds.min.z, wallRightCollider.bounds.max.z);
                    spawnPoint = new Vector3(spawnXright, 0, spawnZright); 
                    break;

                case 2: // Wall Center
                    float spawnXcenter = wallCenterCollider.transform.position.x+ UnityEngine.Random.Range(wallCenterCollider.bounds.min.x, wallCenterCollider.bounds.max.x);
                    float spawnZcenter = wallCenterCollider.transform.position.z+UnityEngine.Random.Range(wallCenterCollider.bounds.min.z, wallCenterCollider.bounds.max.z);
                    spawnPoint = new Vector3(spawnXcenter, 0, spawnZcenter);
                    break;
            }
            Debug.Log("Spawn Position: "+spawnPoint);
            // Determina quale oggetto spawnare in base alla probabilità
            float spawnRandom = UnityEngine.Random.Range(0,100); // 0.0f a 1.0f
            int index = 0;
            if(spawnRandom<spawnObjects[0].probability){
                index = 0;
            }else if (spawnRandom<spawnObjects[1].probability){
                index = 1;
            }else{
                index = 2;
            }

            GameObject newObject = Instantiate(spawnObjects[index].spawnObject.gameObject, spawnPoint, Quaternion.identity);
            newObject.transform.position = spawnPoint;

            // Reset del timer di spawn
            lastSpawnTime = 0;
            currentSpawnTimer = spawnTime;
        }
    }
}