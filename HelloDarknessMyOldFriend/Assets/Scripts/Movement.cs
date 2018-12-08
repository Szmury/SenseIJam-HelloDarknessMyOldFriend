using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed = 0.5f;
    private Transform myTransform;
    private float yObj;
    private float angle = 2;
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
            yObj = myTransform.position.y;
            Boping(UpdatedPosition("d", Vector3.right, 90));
            Boping(UpdatedPosition("a", Vector3.left, 270));
            Boping(UpdatedPosition("w", Vector3.forward, 0));
            Boping(UpdatedPosition("s", Vector3.back, 180));
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



    public void Boping(bool flag)
    {
        
        if (flag)
        {
            if (angle > maxAngle || angle < -maxAngle)
            {
                speedBop *= (-1);
            }
            angle -= speedBop * Time.deltaTime;
            myTransform.rotation = Quaternion.Euler(0, 0, angle );

        }
    }
}

