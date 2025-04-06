using UnityEngine;

public class MoveUp : MonoBehaviour
{
    private EventManager eventManager;
    private float moveSpeed = 1f;

    private void Start(){
        eventManager = FindObjectOfType<EventManager>();

    }

    // Update is called once per frame
    void Update()
    {

        // Ricalcola la Velocità
        moveSpeed = eventManager.speed / 100f;

        // Muovi l'oggetto verso l'alto lungo l'asse Y
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

    }
}