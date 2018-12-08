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

    List<GameObject> GremlinsPoolList;

    void Start()
    {
        ticker.SetTickerAndCallback(multiplyTick, Multiply);
        GremlinsPoolList = new List<GameObject>();
        // Dodawanie do gremlinController odwo�an do skrypt�w
        GremlinController gc = GremlinsList[0].GetComponent<GremlinController>();
        gc.ToPool = MoveGremlinToPool;
        gc.DeleteFromList = DeleteGremlinFromList;
    }

    void Update()
    {
        cameraController.UpdateCamera(GremlinsList);
    }

    void Multiply()
    {
        if (!GameManager.gm.runningGame)
            return;
        int count = GremlinsList.Count;
        if (count == 0)
            return;
        List<GameObject> newObjects = new List<GameObject>();

        for (int i = 0; i < 1; i++)
        {
            Vector3 position = GremlinsList[i].transform.position;
            position.y += 2;
            GameObject go;
            if (GremlinsPoolList.Count > 0)
            {
                go = GremlinsPoolList[0];
                GremlinsPoolList.Remove(go);
                go.SetActive(true);
                go.transform.position = position;
            }
            else
            {
                go = Instantiate(GremlinsList[0], position, Quaternion.identity, transform);
            }
            Vector3 pushDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            go.GetComponent<Rigidbody>().AddForce(force * pushDirection.normalized);

            // Dodawanie do gremlinController odwo�an do skrypt�w
            GremlinController gc = go.GetComponent<GremlinController>();
            gc.ToPool = MoveGremlinToPool;
            gc.DeleteFromList = DeleteGremlinFromList;
            newObjects.Add(go);
        }
        GremlinsList.AddRange(newObjects);
    }

    public void MoveGremlinToPool(GameObject gremlin)
    {
        GremlinsPoolList.Add(gremlin);

        //GameOver
        if(GremlinsList.Count == 0)
        {
            Score.score.GameOver();
        }
    }

    public void DeleteGremlinFromList(GameObject gremlin)
    {
        GremlinsList.Remove(gremlin);
    }
}
