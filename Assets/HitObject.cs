using UnityEngine;

public class HitObject : MonoBehaviour
{
    // Variabile pubblica per il punteggio, che può essere manipolata da altri script
    public static int score = 0;

    // Metodo che viene chiamato quando l'oggetto entra in collisione con un altro
    private void OnTriggerEnter(Collider other)
    {
        // Puoi aggiungere un controllo per verificare che la collisione avvenga con un oggetto specifico tag: Player
        if (other.CompareTag("Player"))
        {
            // Incrementa il punteggio
            score+= 100;

            // Mostra il punteggio nella console per il debug
            Debug.Log("Score: " + score);

            // Distruggi l'oggetto colpito (questo oggetto stesso)
            Destroy(gameObject);
        }
    }
}