using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public List<Vector3> vectors;
    public bool loop = true;

    public float speed=5f;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private Vector3 currentTarget;
    private int currentIndex;

    public void Start()
    {
        if (vectors.Count != 0)
        {
            currentIndex = 0;
            currentTarget = vectors[0];
            // Keep a note of the time the movement started.
            startTime = Time.time;

            // Calculate the journey length.
            journeyLength = Vector3.Distance(transform.position, currentTarget);
        }
    }

    private void Update()
    {
        if (vectors.Count != 0)
        {
            if ((transform.position - currentTarget).magnitude >= 0.1f)
            {
                GoToTarget();
                RotateToTarget();
            }
            else
            {
                if(currentIndex < vectors.Count -1)
                {
                    currentIndex++;
                    currentTarget = vectors[currentIndex];
                }
            }
        }
    }

    void GoToTarget()
    {
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(transform.position, currentTarget, fracJourney);
    }

    void RotateToTarget()
    {
        transform.rotation = Quaternion.LookRotation(currentTarget - transform.position, Vector3.up);
    }
}
