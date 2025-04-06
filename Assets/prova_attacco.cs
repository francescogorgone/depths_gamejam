using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public float raggioAttacco = 1f;  // Raggio dell'area di attacco
    public LayerMask layerTrigger;  // Il layer del trigger che deve essere attivato
    public Vector3 sizeAttacco = new Vector3(1f, 1f, 1f);
    private Vector3 centroAttacco;

    void Update()
    {
        // Controlla se il giocatore preme il tasto "Spazio" per attaccare
        if (Input.GetKeyDown(KeyCode.Space))  // Usa il tasto "Spazio" per attaccare
        {
            Attacco();
        }
    }

    void Attacco()
    {   
        centroAttacco= new Vector3(transform.position.x,transform.position.y+2,transform.position.z-1);
        // Crea una sfera intorno al giocatore per simulare un'area di attacco
        Collider[] hitColliders = Physics.OverlapBox(centroAttacco, sizeAttacco, transform.rotation, layerTrigger);

        foreach (var hitCollider in hitColliders)
        {
            // Se l'oggetto colpito ha il tag "TriggerTag", attiva la funzione del trigger
            if (hitCollider.CompareTag("TriggerTag"))
            {
                TriggerScript trigger = hitCollider.GetComponent<TriggerScript>();
                if (trigger != null)
                {
                    trigger.AttivaFunzione();  // Chiama la funzione del trigger
                }
            }
        }
    }

    // Funzione per visualizzare il raggio di attacco (solo per debug)
    private void OnDrawGizmos()
    {
        Vector3 gizmoCentroAttacco = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z - 1);
    
        // Applica la rotazione del personaggio a Gizmos
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(gizmoCentroAttacco, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(centroAttacco, sizeAttacco);
    }
}