using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    private bool Thrust;
    public float ThrustSpeed = 1;
    public float TurnSpeed = 1;
    private float turnDirect;
    private Rigidbody2D RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    private void Update()
    {
        Thrust = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirect = 1.0f;
        }else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirect = -1.0f;
        }
        else
        {
            turnDirect = 0.0f;
        }

    }

    private void FixedUpdate()
    {
        if (Thrust)
        {
            RigidBody.AddForce(this.transform.up * ThrustSpeed);
        }

        if (turnDirect != 0.0f)
        {
            RigidBody.AddTorque(turnDirect * this.TurnSpeed);

        }

    }


}
