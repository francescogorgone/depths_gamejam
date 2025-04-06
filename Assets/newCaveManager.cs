using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleController : MonoBehaviour
{
    private EventManager eventManager; //accellerazione
    
    public float baseSpeedObject = 1f;
    public float speedObject = 1f;
    public float leftBound = 15.0f;
    private PlayerController playerControllerScripts;
    public Transform uplimit;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {

        eventManager = FindFirstObjectByType<EventManager>();
        playerControllerScripts = GameObject.Find("miner").GetComponent<PlayerController>();

         //accellerazione
    }

    // Update is called once per frame
    void Update()
    {
        speedObject = baseSpeedObject/10 + 20 * eventManager.speed;
        
        transform.Translate(Vector3.up* Time.deltaTime * speedObject);
        if (transform.position.y >= uplimit.position.y){
            transform.position = new Vector3(0, spawnPoint.position.y, 0);
        }
    }
}

