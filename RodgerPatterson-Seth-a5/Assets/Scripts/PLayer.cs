using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    private bool Thrust;
    private float turnDirect;
    private Rigidbody2D RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        RigidBody = getCompinent<Rigidbody2D>();
    }


    // Update is called once per frame
    private void Update()
    {
        Thrust = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Up)

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Left))
        {
            turnDirect = 1.0f
        }else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Right))
        {
            turnDirect = -1.0f
        }
        else
        {
            turnDirect = 0.0f
        }

    }

    private void FixedUpdate()
    {



    }


}
