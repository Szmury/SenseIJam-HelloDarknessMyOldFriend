using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

    public Vector3 offset;
    public float smoothTime= .5f;

    public float minZoom=40f;
    public float maxZoom=10f;
    public float zoomLimiter=50f;

    private Vector3 velocity;
    private Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    //public List<GameObject> targets;

    /*
    private void Update()
    {
        if (targets.Count == 0)
        {
            Debug.Log("UpdateCamera: List of targets is empty!");
            return;
        }

        MoveCamera(targets);
        ZoomCamera(targets);
    }*/
    
    public void UpdateCamera(List<GameObject> targets)
    {
        if(targets.Count == 0)
        {
            Debug.Log("UpdateCamera: List of targets is empty!");
            return;
        }

        MoveCamera(targets);
        ZoomCamera(targets);
        
    }

    void ZoomCamera(List<GameObject> targets)
    {
        float newZoom = Mathf.Lerp(maxZoom,minZoom, GetGreatestDistance(targets)/zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void MoveCamera(List<GameObject> targets)
    {
        Vector3 centerPoint = GetCenterPoint(targets);
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }


    float GetGreatestDistance(List<GameObject> targets)
    {
        var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
        foreach (GameObject t in targets)
        {
            bounds.Encapsulate(t.transform.position);
        }
        return bounds.size.x;
    }

    Vector3 GetCenterPoint(List<GameObject> targets)
    {
        if(targets.Count == 1)
        {
            return targets[0].transform.position;
        }

        var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
        foreach (GameObject t in targets)
        {
            bounds.Encapsulate(t.transform.position);
        }
        return bounds.center;
    }
}
