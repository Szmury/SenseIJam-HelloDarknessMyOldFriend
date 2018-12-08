using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Movement : MonoBehaviour
{

    public float moveSpeed = 0.5f;
    private Transform myTransform;
    private float yObj;
    private float angle = 2;
    public float maxAngle = 40;
    GameManager gameManager;
    public float speedBop = 5;
    private bool[] isBop = new bool[4];
    void Start()
    {
        myTransform = transform;
        gameManager = GameManager.gm;
    }

        void Update()
        {
            if (gameManager.runningGame)
            {
                yObj = myTransform.position.y;
                UpdatedPosition("d", Vector3.right, 90);
                UpdatedPosition("a", Vector3.left, 270);
                UpdatedPosition("w", Vector3.forward, 0);
                UpdatedPosition("s", Vector3.back, 180);
            }

        }

        public bool UpdatedPosition(string key, Vector3 moveVector, int rotation)
        {
            if (yObj < 1)
            {
                if (Input.GetKey(key))
                {
                    myTransform.position += moveVector * Time.deltaTime * moveSpeed;
                    myTransform.rotation = Quaternion.Euler(0, rotation, 0);
                    return true;
                }
            }
            return false;
        }
    }


