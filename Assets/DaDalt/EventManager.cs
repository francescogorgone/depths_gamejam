using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    private ChangeScene changeScene;

    public Slider airSlider;
    public float air = 100f;
    public float maxAir = 100f;

    public float drainSpeed = 10f;

    public Image targetImage;


    public Slider speedSlider;
    public float speed = 0f;
    public float maxSpeed = 100f;

    public int points = 0;
    public float weight = 30f;
    public Image targetImage2;

    public bool GameOn = true;


    public bool restart = false;


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
            airSlider = GameObject.Find("AirSlider").GetComponent<Slider>();
            speedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();
            targetImage = GameObject.Find("AirFill").GetComponent<Image>();
            targetImage2 = GameObject.Find("SpeedFill").GetComponent<Image>();
        }

    // Update is called once per frame
    void Update()
    {
       
       if (GameOn){
            if ((airSlider == null) || (speedSlider == null)){
                 
            }
             else {
            
                     airSlider.value = air;
                      speedSlider.value = speed;
                       
                       if(points <= maxSpeed){
                       
                       speed = points / weight;
                        }

                        if (air > 0)
                        {
                             if (air <= 20) {
                                targetImage.color = Color.Lerp(Color.red, Color.white, air/maxAir);
                                DeepAudioManager.Instance.PlayMusic(DeepAudioManager.BackgroundMusic.low_oxygen);
                            }
                            else if (air <=50){
                                targetImage.color = Color.Lerp(Color.red, Color.yellow, air/maxAir);
                                DeepAudioManager.Instance.PlayMusic(DeepAudioManager.BackgroundMusic.normal_oxygen);
                            }

                            else {
                                targetImage.color = Color.Lerp(Color.yellow, Color.green, air/maxAir);
                            DeepAudioManager.Instance.PlayMusic(DeepAudioManager.BackgroundMusic.high_oxygen);
                            }


                            air -= Time.deltaTime * drainSpeed;
                           
                        }

                       if (air <= 0)
                       {
                            Debug.Log("Game Over");
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

    public void Restart(){
        airSlider = GameObject.Find("AirSlider").GetComponent<Slider>();
        speedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();
        targetImage = GameObject.Find("AirFill").GetComponent<Image>();
        targetImage2 = GameObject.Find("SpeedFill").GetComponent<Image>();
        points = 0;
        air = 100;
    }
}
