using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public List<Vector3> vectors;
    public List<float> speed;
    public float defaultSpeed = 5;
    public bool loop = true;

    bool stop = false;
    int index = -1;
    float currentSpeed;
    Vector3 currentVector;
    Vector3 endPoint;

    Quaternion startRotation;

    public void Start()
    {
        if (vectors.Count == 0)
        {
            Debug.Log("NIE MA WEKTORÓW DLA CARCONTROLLER!!!");
        }
        NewDestination();
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (!stop)
        {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

            if ((transform.position - endPoint).magnitude <= 0.3)
                NewDestination();
        }
    }

    void NewDestination()
    {
        index++;
        if(index == vectors.Count)
        {
            if (loop)
                index = 0;
            else
            {
                stop = true;
                Debug.Log("Koniec podróży");
                return;
            }
                
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

        //Quaternion rotation = Quaternion.identity;
        
        transform.rotation = Quaternion.LookRotation(currentVector, Vector3.up);
        transform.Rotate(startRotation.eulerAngles);
    }

}
