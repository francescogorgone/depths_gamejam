using UnityEngine;
using UnityEngine.UI;

public class pointHUD : MonoBehaviour
{
    [SerializeField] Text pointText;

    GameObject gameObject = GameObject.Find("EventManager");
    

    private void Awake (){
        UpdateHud();
    }

    int points = GameObject.GetComponent<EventManager>().points;

    public int Points {
        get { return points; }
        set {
            points = value;
            UpdateHud();
        }
    }

    private void UpdateHud() {
        pointText.text = points.ToString();
    }

}
