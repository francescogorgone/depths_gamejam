using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class PlayerAttackScript : MonoBehaviour
{
    public float raggioAttacco = 1f;  // Raggio dell'area di attacco
    public LayerMask layerTrigger;  // Il layer del trigger che deve essere attivato
    public Vector3 sizeAttacco = new Vector3(1f, 1f, 1f);
    private Vector3 centroAttacco;

    public float offsetAttacco = 2f;  // Distanza dall'oggetto per posizionare il centro dell'attacco davanti al giocatore
    public float altezzaAttacco = 1f;  // Distanza sopra il giocatore per la posizione Y dell'area di attacco
    private AudioSource audioSource; // AudioSource per riprodurre il suono
    public AudioClip Audio; //Variabile audio visibile dall'inspector
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
    }

    void OnAttack(InputAction.CallbackContext cont){
        if(cont.performed){
             Debug.LogWarning("Lol");
             Attacco();
        }
    }

    public void Attacco()
    {
        // Calcola il centro dell'attacco davanti al giocatore, con un offset in Y (altezzaAttacco)
        centroAttacco = transform.position + transform.forward * offsetAttacco + Vector3.up * altezzaAttacco;

        // Crea una zona di attacco usando un BoxCollider (OverlapBox) con la stessa rotazione del personaggio
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
             if (audioSource != null)
            {
                audioSource.PlayOneShot(Audio);  // Riproduce il suono una volta
            }
        }
    }

    // Funzione per visualizzare il raggio di attacco (solo per debug)
    private void OnDrawGizmos()
    {
        // Calcola il centro dell'attacco davanti al giocatore, con un offset in Y (altezzaAttacco)
        Vector3 gizmoCentroAttacco = transform.position + transform.forward * offsetAttacco + Vector3.up * altezzaAttacco;

        // Applica la rotazione del personaggio a Gizmos per disegnare correttamente l'area di attacco
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(gizmoCentroAttacco, transform.rotation, Vector3.one);

        // Usa il centro calcolato per il disegno (gizmoCentroAttacco) invece di centroAttacco
        Gizmos.DrawWireCube(Vector3.zero, sizeAttacco); // Rappresenta un wireframe del BoxCollider per il debug
    }
}