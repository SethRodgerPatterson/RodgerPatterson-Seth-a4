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

        this.transform.eulerAngles = new Vector3(0.0f,0.0f,Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        RigidBody.mass = this.size;
    }

    public void SetTrajector(Vector3 direction)
    {
        RigidBody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if ((this.size * 0.5f) >= minSize)
            {
                CreateSplit();
                CreateSplit();
            }
            
            Destroy(this.gameObject);
        }

    }
    private void CreateSplit()
    {
        Vector2 Pos = this.transform.position;
        Pos += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this,Pos, this.transform.rotation);
        half.size = this.size * 0.5f;

        half.SetTrajector(Random.insideUnitCircle.normalized);
    }

}
