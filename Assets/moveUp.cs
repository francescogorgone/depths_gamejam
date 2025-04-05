using UnityEngine;

public class MoveUp : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f; // Velocità del movimento verso l'alto

    // Update is called once per frame
    void Update()
    {
        // Muovi l'oggetto verso l'alto lungo l'asse Y
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}