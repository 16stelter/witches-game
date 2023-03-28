using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public float range;

    public Rigidbody2D rb;
    public GameObject go;

    float distanceTravelled = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        distanceTravelled += 1.0f;
        if(distanceTravelled > range)
        {
            Destroy(go);
        }
    }
}
