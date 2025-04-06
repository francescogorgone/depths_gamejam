using UnityEngine;
using UnityEngine.UI;

public class pointHUD : MonoBehaviour
{
    [SerializeField] Text pointText;
    
    public int points2 = 1234567890;
    private EventManager eventManager;


    private void Start (){
        eventManager = FindFirstObjectByType<EventManager>();
        if (eventManager == null) {
            Debug.LogError("EventManager not found in the scene.");
        }
        points2 = eventManager.points;
        UpdateHud();
    }

    public int Points {
        get { return points2; }
        set {
            points2 = eventManager.points;
            UpdateHud();
        }
    }

    private void UpdateHud() {
        points2 = eventManager.points;
        pointText.text = points2.ToString();
    }

}
