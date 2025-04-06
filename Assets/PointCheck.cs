using UnityEngine;

public class PointCheck : MonoBehaviour
{
    public bool showup = false;
     public EventManager eventManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventManager= FindObjectOfType<EventManager>();
        if (eventManager.points == 0) {

            if (showup) {
                Debug.Log("showup");
                gameObject.SetActive(true);
            }
            else {
                gameObject.SetActive(false);
            }
        }
        else if (showup) {
            gameObject.SetActive(false);
        }
    }
}
