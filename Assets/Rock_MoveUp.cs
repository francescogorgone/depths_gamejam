using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    public float speed = 5f;  // Velocità di salita lungo l'asse Y
    public float targetY = 100f;  // Altezza target raggiunta la quale l'oggetto viene distrutto

    void Update()
    {
        // Muovi l'oggetto lungo l'asse Y
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Controlla se l'oggetto ha raggiunto o superato il targetY
        if (transform.position.y >= targetY)
        {
            // Distruggi l'oggetto
            Destroy(gameObject);
        }
    }
}