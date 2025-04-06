using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{

    private EventManager eventManager; //accellerazione

    private float baseSpeed = 1f;  // Velocità di salita lungo l'asse Y
    private float Speed = 0f;
    public float targetY = 100f;  // Altezza target raggiunta la quale l'oggetto viene distrutto

    void Start(){
        eventManager = FindFirstObjectByType<EventManager>();
    }

    void Update()
    {
        Speed = baseSpeed + 40 * eventManager.speed;

        // Muovi l'oggetto lungo l'asse Y
        transform.Translate(Vector3.up * Speed * Time.deltaTime);

        // Controlla se l'oggetto ha raggiunto o superato il targetY
        if (transform.position.y >= targetY)
        {
            // Distruggi l'oggetto
            Destroy(gameObject);
        }
    }
}