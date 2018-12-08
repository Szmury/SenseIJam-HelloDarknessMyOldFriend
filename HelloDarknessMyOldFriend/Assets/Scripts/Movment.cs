using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour {


    public float moveSpeed = 0.5f;
    private Rigidbody rigidBody;
    private Transform myTransform;


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatedPosition("d", Vector3.right, 90);
        UpdatedPosition("a", Vector3.left, 270);
        UpdatedPosition("w", Vector3.forward, 0);
        UpdatedPosition("s", Vector3.back, 180);
    }

    private void UpdatedPosition(string key, Vector3 moveVector, int rotation)
    {
        if (Input.GetKey(key))
        {
            myTransform.position += moveVector * Time.deltaTime * moveSpeed;
            myTransform.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }
 }

