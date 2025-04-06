using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    private ChangeScene changeScene;

    public Slider AirSlider;
    public float air = 100f;
    public float maxAir = 100f;

    public float drainSpeed = 0.02f;

    public bool GameOn = true;

    public Image targetImage;


    public Slider SpeedSlider;
    public float speed = 0f;
    public float maxSpeed = 100f;

    public int points = 0;
    public float weight = 30f;
    public Image targetImage2;


        //Oggetto permanente
        public static EventManager Instance;

        void Awake(){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    private void Start()
    {
        changeScene = GetComponent<ChangeScene>();


    }

    // Update is called once per frame
    void Update()
    {
       
       if (GameOn){
            if ((AirSlider == null) || (SpeedSlider == null)){
                 
            }
             else {
            
                     AirSlider.value = air;
                      SpeedSlider.value = speed;
                       speed = points / weight;

                        if (air > 0)
                     {
                            targetImage.color = Color.Lerp(Color.cyan, Color.white, air);
                            air -= Time.deltaTime * drainSpeed;
                        }

                       if (air <= 0)
                       {
                            Debug.Log("Game Over");
                            GameOn = false;
                            SceneManager.LoadScene(1);
                       }
                        if (air >= maxAir)
                        {
                            air = maxAir;
                        }


                        if (speed >= maxSpeed)
                        {
                            speed = maxSpeed;
                        }

                       if (speed > 0)
                        {
                          targetImage2.color = Color.Lerp(Color.yellow, Color.red, speed);
                       }
                  }
             }
        
    }
    public void AddOxygen(float value)
    {
       air += value;
    }

    public void AddPoints(int value){
        points +=value;
        Debug.Log("Punti aggiunti: " + value);
        Debug.Log("Punteggio totale: " + points);
    }
}
