using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveController : MonoBehaviour
{
    public float speedObject = 30;
    public Transform uplimit;
    public Transform spawnPoint;
    private Transform myTransform;

    void Start(){
        myTransform = GetComponent<Transform>();
    }

    void Update()
    {
        myTransform.Translate(Vector3.up* Time.deltaTime * speedObject);
        if (transform.position.y >= uplimit.position.y){
            transform.position = new Vector3(0, spawnPoint.position.y, 0);
        }
    }
}

