using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    private ChangeScene changeScene;

    public Slider AirSlider;
    public float air = 100f;
    public float maxAir = 100f;

    public float drainSpeed = 10f;

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
            DontDestroyOnLoad (this);
		
	if (Instance == null) {
		Instance = this;
	} else {
		Destroy(gameObject);
	}
        }

        void Start(){
            test = FindFirstObjectByType<AirSlider>();
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
                       
                       if(points <= maxSpeed){
                       
                       speed = points / weight;
                        }

                        if (air > 0)
                        {
                             if (air <= 20) {
                                targetImage.color = Color.Lerp(Color.red, Color.cyan, air/maxAir);
                            }
                            else {targetImage.color = Color.Lerp(Color.yellow, Color.white, air/maxAir);}

                            air -= Time.deltaTime * drainSpeed;
                           
                        }

                       if (air <= 0)
                       {
                            Debug.Log("Game Over");
                            GameOn = false;
                            points = 0;
                            SceneManager.LoadScene(1);
                       }
                        if (air > maxAir)
                        {
                            air = maxAir;
                        }


                        if (speed > maxSpeed)
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
