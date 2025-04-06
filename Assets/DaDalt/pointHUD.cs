using UnityEngine;
using UnityEngine.UI;

public class pointHUD : MonoBehaviour
{
    [SerializeField] Text pointText;

    private int score;

    private void Awake (){
        UpdateHud();
    }




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
