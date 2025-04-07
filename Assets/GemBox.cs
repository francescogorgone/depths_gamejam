using UnityEngine;

public class GemBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private EventManager eventManager;

    public int scoreNeeded;

    void Start()
    {
        eventManager = FindFirstObjectByType<EventManager>();
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (eventManager.points >= scoreNeeded)
        {
          GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
          GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
