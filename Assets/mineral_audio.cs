using UnityEngine;

public class Minerale : MonoBehaviour
{
    // Assegna il file audio dall'Inspector
    public AudioClip suonoMiniera;
    private AudioSource audioSource;
    
    void Start()
    {
        // Recupera il componente AudioSource dal GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Questo metodo deve essere chiamato quando il minerale viene minato
    public void Minato()
    {
        // Riproduce il suono associato al file audio
        audioSource.PlayOneShot(suonoMiniera);
    }
}
