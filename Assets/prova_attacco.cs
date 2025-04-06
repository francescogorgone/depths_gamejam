using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public float raggioAttacco = 1f;  // Raggio dell'area di attacco
    public LayerMask layerTrigger;  // Il layer del trigger che deve essere attivato

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
        // Crea una sfera intorno al giocatore per simulare un'area di attacco
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, raggioAttacco, layerTrigger);

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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raggioAttacco);
    }
}