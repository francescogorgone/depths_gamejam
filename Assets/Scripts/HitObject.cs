using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    // Funzione che distrugge l'oggetto
    public void DestroyObject()
    {
        Debug.Log("Oggetto distrutto!");

        // Distruggi l'oggetto
        Destroy(gameObject);
    }
}