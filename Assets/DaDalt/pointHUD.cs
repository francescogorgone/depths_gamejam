using UnityEngine;
using UnityEngine.UI;

public class pointHUD : MonoBehaviour
{
    [SerializeField] Text pointText;
    

    private void Awake (){
        UpdateHud();
    }

    int points = 1234567890;

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
