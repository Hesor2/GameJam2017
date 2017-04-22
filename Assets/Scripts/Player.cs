using UnityEngine;
using System.Collections;
using System;

public class Player : Collidable
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    public float jumpSpeed = 10;
    public float walkSpeed = 4;
    public float maxVelocity = 500;

    private bool isFalling = false;

    //private Interactable interactable;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 velocity = Vector2.zero;
        float h = Input.GetAxis("Horizontal");
        if (rb.velocity.x * h < maxVelocity)
        {
            velocity.x = h * walkSpeed * rb.mass * Time.deltaTime;
        }

        //Jump
        if (Input.GetKeyDown("up") && !isFalling)
        {
            velocity.y = jumpSpeed * rb.mass * Time.deltaTime;
            isFalling = true;
        }
        /*
        //Interact
        if (Input.GetKeyDown("space"))
        {
            Vector2 pos = (Vector2)transform.position + boxCollider.offset;
            var size = boxCollider.size;
            Physics2D.BoxCastAll(pos, size);
        }*/

        rb.AddForce(velocity);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown("space"))
        {
            var interactable = collider.gameObject.GetComponent<Interactable>();
            if(interactable != null)
            {
                interactable.Interact(gameObject);
            }
        }
    }


    public override void EnterCollision(string tag, GameObject gameobject)
    {
        isFalling = false;
    }

    public override void StayCollision(string tag, GameObject gameobject)
    {
        isFalling = false;
    }

    public override void ExitCollision(string tag, GameObject gameobject)
    {
        isFalling = true;
    }
}
