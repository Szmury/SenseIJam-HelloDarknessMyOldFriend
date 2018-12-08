using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organizer : MonoBehaviour {

    [SerializeField]
    PeriodicallTicker ticker;
    [SerializeField]
    CameraController cameraController;
    [SerializeField]
    List<GameObject> GremlinsList;
    public float multiplyTick;
    public float force;

    void Start()
    {
        ticker.SetTickerAndCallback(multiplyTick, Multiply);

    }

    void Update()
    {
        cameraController.UpdateCamera(GremlinsList);
    }

    void Multiply()
    {
        int count = GremlinsList.Count;
        List<GameObject> newObjects = new List<GameObject>();

        for (int i = 0; i < 1; i++)
        {
            Vector2 position = GremlinsList[i].transform.position;
            position.y += 2;
            GameObject go = Instantiate(GremlinsList[0], position, Quaternion.identity, transform);
            Vector3 pushDirection = new Vector3(Random.Range(0.0f, 1.0f), 0, Random.Range(0.0f, 1.0f));
            go.GetComponent<Rigidbody>().AddForce(force * pushDirection.normalized);
            newObjects.Add(go);
        }
        GremlinsList.AddRange(newObjects);
    }
}
