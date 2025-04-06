using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    // Questa funzione viene chiamata quando il giocatore entra in contatto con il trigger
    public void AttivaFunzione()
    {
        // Logica da eseguire quando il trigger viene attivato
        Debug.Log("Il trigger è stato attivato dal giocatore!");
        // Aggiungi altre azioni qui (ad esempio, distruggere l'oggetto, fare qualcosa nella scena, ecc.)
        Destroy(gameObject);
    }
}