using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D RigidBody;
    public float BulletSpeed = 500.0f;
    public float lifeTime = 10.0f;

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    public void Projection(Vector2 direction)
    {
        //Adds speed to bullet
        RigidBody.AddForce(direction * BulletSpeed);

        //Removes bullet after designated life time
        Destroy(this.gameObject, this.lifeTime);
    }


}
