using UnityEngine;

public class GemBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private EventManager eventManager;

    void Start()
    {
        eventManager = FindFirstObjectByType<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
