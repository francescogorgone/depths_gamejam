using UnityEngine;
using UnityEngine.UI;

public class AirManager : MonoBehaviour
{

    public Slider AirSlider;
    public float air = 100f;
    public float maxAir = 100f;

    public float drainSpeed = 0.2f;

    public bool GameOn = true;

    public Image targetImage;

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
        }
        
    }
    public void IncreaseAir(float value)
    {
       air += value;
    }
}
