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

                gameObject.SetActive(true);
                Debug.Log("showup Working");
            }
            else {
                gameObject.SetActive(false);
                 
            }

        }

        else {
            if (showup) {

                gameObject.SetActive(false);
                Debug.Log("showup inverted");
            }
            else {
                gameObject.SetActive(true);
                 
            }
        }
    }
}
