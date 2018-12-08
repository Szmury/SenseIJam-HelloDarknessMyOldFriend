using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {


    public float moveSpeed = 0.5f;
    private Transform myTransform;
    private float yObj;

    // Use this for initialization
    void Start () {
        myTransform = transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        yObj = myTransform.position.y;
        UpdatedPosition("d", Vector3.right, 90);
        UpdatedPosition("a", Vector3.left, 270);
        UpdatedPosition("w", Vector3.forward, 0);
        UpdatedPosition("s", Vector3.back, 180);
    }

    private void UpdatedPosition(string key, Vector3 moveVector, int rotation)
    {
        if (yObj < 1)
        {
            if (Input.GetKey(key))
            {
                myTransform.position += moveVector * Time.deltaTime;
                myTransform.rotation = Quaternion.Euler(0, rotation, 0);
            }
        }
    }
 }

