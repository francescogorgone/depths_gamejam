using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public List<GameObject> caveSegments;

    private float segmentHeight;
    private Transform cameraTransform;

    void Start()
    {
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
        transform.position += Vector3.up * scrollSpeed * Time.deltaTime;

        foreach (GameObject segment in caveSegments)
        {
            if (segment.transform.position.y - segmentHeight / 2 > cameraTransform.position.y + Camera.main.orthographicSize)
            {
                RecycleSegment(segment);
            }
        }
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
