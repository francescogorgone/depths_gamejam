using UnityEngine;

public class StartManager : MonoBehaviour
{

    public EventManager eventManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventManager = FindFirstObjectByType<EventManager>();
        eventManager.Restart();
        Destroy(gameObject);
    }
}
