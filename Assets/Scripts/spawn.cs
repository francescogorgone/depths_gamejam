using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    // Prefab dell'entità che vogliamo generare (in questo caso un cubo)
    public GameObject entityPrefab;

    // Parametri per il numero di entità da generare e la distanza tra loro
    public int numberOfEntities = 1000;
    public float spacing = 6.0f;

    // Start è chiamato all'inizio del gioco o quando l'oggetto è attivo
    void Start()
    {
        // Creazione delle entità
        SpawnEntities();
    }

    // Funzione che genera le entità
    void SpawnEntities()
    {
        for (int i = 0; i < numberOfEntities; i++)
        {
            // Calcola la posizione in cui spawnare l'entità
            Vector3 position = new Vector3(0, i * spacing, 0);

            // Istanzia l'entità nel mondo
            Instantiate(entityPrefab, position, Quaternion.identity);
        }
    }
}