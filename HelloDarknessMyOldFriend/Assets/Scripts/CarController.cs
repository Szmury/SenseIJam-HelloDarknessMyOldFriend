using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public List<Vector3> vectors;
    public List<float> speed;
    public float defaultSpeed = 5;
    public bool loop = true;

    int index = -1;
    float currentSpeed;
    Vector3 currentVector;
    Vector3 endPoint;

    public void Start()
    {
        if (vectors.Count == 0)
        {
            Debug.Log("NIE MA WEKTORÓW DLA CARCONTROLLER!!!");
        }
        NewDestination();
    }

    private void Update()
    {
        transform.Translate(currentVector * currentSpeed * Time.deltaTime);

        if ((transform.position - endPoint).magnitude <= 0.3)
            NewDestination();
    }

    void NewDestination()
    {
        index++;
        if(index == vectors.Count)
        {
            if (loop)
                index = 0;
            else
                Debug.Log("Koniec podróży");
        }

        if(speed.Count <= index)
        {
            currentSpeed = defaultSpeed;
        }
        else
        {
            currentSpeed = speed[index];
            if (currentSpeed == 0)
                currentSpeed = defaultSpeed;
        }

        currentVector = vectors[index];
        endPoint = transform.position + currentVector;
        currentVector = currentVector.normalized;

        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = currentVector;
        transform.rotation = rotation;
    }

}
