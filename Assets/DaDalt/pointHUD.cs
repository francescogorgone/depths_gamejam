using UnityEngine;
using UnityEngine.UI;

public class pointHUD : MonoBehaviour
{
    [SerializeField] Text pointText;
    

    private void Awake (){
        UpdateHud();
    }

     int points = 1234567890;
    public GameObject EventManager;
    //private eventManager pippo;

    public int score = 0;
            private void Start()
        {
         
        }
          private void Update()
        {
            
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
