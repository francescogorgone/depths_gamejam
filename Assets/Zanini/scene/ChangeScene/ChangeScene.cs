using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private EventManager updatePoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updatePoints = FindAnyObjectByType<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiaScena(int numeroscena)
    {
        if (numeroscena == 5)
            {
                updatePoints.points = 0;
            }
        SceneManager.LoadScene(numeroscena);

    }
}
