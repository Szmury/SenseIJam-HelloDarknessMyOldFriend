using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Movement : MonoBehaviour
{

    public float moveSpeed = 0.5f;
    private Transform myTransform;
    public float maxAngle = 40;
    GameManager gameManager;
    public float speedBop = 5;
    void Start()
    {
        myTransform = transform;
        gameManager = GameManager.gm;
        gameManager.runningGame = true;
    }

    void Update()
    {
        if (gameManager.runningGame)
        {
            UpdatedPosition("d", Vector3.right, 90);
            UpdatedPosition("a", Vector3.left, 270);
            UpdatedPosition("w", Vector3.forward, 0);
            UpdatedPosition("s", Vector3.back, 180);
        }
    }

    public bool UpdatedPosition(string key, Vector3 moveVector, int rotation)
    {
        
            if (Input.GetKey(key))
            {
                myTransform.position += moveVector * Time.deltaTime * moveSpeed;
                myTransform.rotation = Quaternion.Euler(0, rotation, 0);
                return true;
            }
        
        return false;
    }
}


