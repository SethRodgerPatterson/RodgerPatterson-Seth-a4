using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    private bool Thrust;
    public float ThrustSpeed = 1;
    public float TurnSpeed = 1;
    public float respawnInvulnerability = 3f;
    private float turnDirect;
    private Rigidbody2D RigidBody;


    public Bullet Bullet;

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // Turn off collisions for a few seconds after spawning to ensure the
        // player has enough time to safely move away from asteroids
        TurnOffCollisions();
        Invoke(nameof(TurnOnCollisions), respawnInvulnerability);
    }

    // Update is called once per frame
    private void Update()
    {
        //Movement inputs
        Thrust = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirect = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirect = -1.0f;
        }
        else
        {
            turnDirect = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void TurnOffCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
    }

    private void TurnOnCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer("Player");
    }



    private void FixedUpdate()
    {

        //Collisions
        if (Thrust)
        {
            RigidBody.AddForce(this.transform.up * ThrustSpeed);
        }

        if (turnDirect != 0.0f)
        {
            RigidBody.AddTorque(turnDirect * this.TurnSpeed);

        }

    }

    private void Shoot()
    {
        // Calls bullet and applys player position and rotation
        Bullet bullet = Instantiate(this.Bullet, this.transform.position, this.transform.rotation);
        bullet.Projection(this.transform.up);



    }





    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Player Hits Asteroids (Dies)
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            RigidBody.velocity = Vector3.zero;
            RigidBody.angularVelocity = 0.0f;



            GameManager.Instance.PlayerDied(this);
        }


    }
}
