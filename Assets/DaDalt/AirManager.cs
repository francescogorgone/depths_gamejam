using UnityEngine;
using UnityEngine.UI;

public class AirManager : MonoBehaviour
{

    public Slider AirSlider;
    public float air;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AirSlider.value = air;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
