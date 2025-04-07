using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private EventManager eventManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventManager = FindFirstObjectByType<EventManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiaScena(int numeroscena)
    {
        if (numeroscena == 5)
            {
                
            }
        SceneManager.LoadScene(numeroscena);

    }
}
