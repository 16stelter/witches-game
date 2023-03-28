using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourBase : MonoBehaviour
{
    public float speed;
	public Rigidbody2D rb;

	private Vector2 direction;
    

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
    	Move();
    }

    void ProcessInputs()
    {
    	float moveX = Input.GetAxis("Horizontal");
    	float moveY = Input.GetAxis("Vertical");

    	direction = new Vector2(moveX, moveY);
    }

    void Move()
    {
    	rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
}
