using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{

    public Slider AirSlider;
    public float air = 100f;
    public float maxAir = 100f;

    public float drainSpeed = 0.2f;

    public bool GameOn = true;

    public Image targetImage;


    public Slider SpeedSlider;
    public float speed = 0f;
    public float maxSpeed = 100f;

    public int points = 0;
    public float weight = 30f;
    public Image targetImage2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
       if (GameOn)
        {
            
       AirSlider.value = air;
       SpeedSlider.value = speed;
       speed = points * points / weight;

        if (air > 0)
        {
            targetImage.color = Color.Lerp(Color.cyan, Color.white, air);
            air -= Time.deltaTime * drainSpeed;
        }

        if (air <= 0)
        {
            Debug.Log("Game Over");
            GameOn = false;
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
            targetImage2.color = Color.Lerp(Color.yellow, Color.red, speed / maxSpeed);
        }
        }
        
    }
    public void IncreaseAir(float value)
    {
       air += value;
    }
}
