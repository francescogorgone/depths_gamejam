using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCaveManager1 : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.y/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < startPosition.y - repeatWidth)
            transform.position = startPosition;

    }
}