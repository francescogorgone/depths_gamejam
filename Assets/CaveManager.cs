using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator : MonoBehaviour
{
    private EventManager eventManager; //manager velocità

    public float scrollSpeed = 0f;

     public float baseScrollSpeed = 1f;
    public List<GameObject> caveSegments;

    private float segmentHeight;
    private Transform cameraTransform;

    void Start()
    {
        eventManager = FindObjectOfType<EventManager>(); //manager velocità


        if (caveSegments == null || caveSegments.Count == 0)
        {
            Debug.LogError("Nessun segmento assegnato!");
            return;
        }

        SpriteRenderer sr = caveSegments[0].GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogError("Il segmento manca del componente SpriteRenderer!");
            return;
        }

        segmentHeight = sr.bounds.size.y;
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        scrollSpeed = baseScrollSpeed * eventManager.speed;

        transform.position += Vector3.up * scrollSpeed * Time.deltaTime;

        foreach (GameObject segment in caveSegments)
        {
            debugSegment = segment.transform.position.y - segmentHeight / 2;
            deubgCamera = cameraTransform.position.y + Camera.main.orthographicSize;
            if (debugSegment> deubgCamera)
            {
                RecycleSegment(segment);
            }
        }
    }
    
    float debugSegment;
    float deubgCamera;
    
    void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(new Vector3(0, debugSegment, 0), 5);
        //Gizmos.color=Color.red;
        Gizmos.DrawSphere(new Vector3(0, deubgCamera, 0), 5);
        Gizmos.color=Color.blue;
    }
    void RecycleSegment(GameObject segment)
    {
        float lowestY = float.MaxValue;
        foreach (GameObject seg in caveSegments)
        {
            if (seg.transform.position.y < lowestY)
            {
                lowestY = seg.transform.position.y;
            }
        }

        Vector3 newPosition = segment.transform.position;
        newPosition.y = lowestY - segmentHeight;
        segment.transform.position = newPosition;
    }
}
