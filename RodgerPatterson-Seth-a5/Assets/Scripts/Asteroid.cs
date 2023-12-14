using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRen;
    private Rigidbody2D RigidBody;

    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 2.0f;
    public float speed = 50f;
    public float lifeTime = 40f;


    // Start is called before the first frame update
    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Start()
    {
        spriteRen.sprite = sprites[Random.Range(0, sprites.Length)];

        transform.eulerAngles = new Vector3(0.0f,0.0f,Random.value * 360.0f);
        transform.localScale = Vector3.one * size;

        RigidBody.mass = size;
    }

    public void SetTrajector(Vector3 direction)
    {
        RigidBody.AddForce(direction * speed);
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if ((size * 0.5f) >= minSize)
            {
                CreateSplit();
                CreateSplit();
            }
            FindObjectOfType<GameManager>().AsteroidDied(this);
            
            Destroy(gameObject);
        }

    }
    private void CreateSplit()
    {
        Vector2 Pos = transform.position;
        Pos += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this,Pos, transform.rotation);
        half.size = size * 0.5f;

        half.SetTrajector(Random.insideUnitCircle.normalized);
    }

}
