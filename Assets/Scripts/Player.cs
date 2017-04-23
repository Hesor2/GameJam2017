using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Player : Collidable
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;
    public float friction = 0.01f;
    public float jumpSpeed = 10;
    public float walkSpeed = 4;
    public float maxVelocity = 500;
    public bool canInteract = true;

    public string introText;
    public Rect textArea;
    public GUIStyle introStyle;

    private bool showText = true;
    public float timeShown = 5.0f;
    private float currentTime = 0.0f, executedTime = 0.0f;

    private bool isFalling = false;
    private bool facingRight = true;
    private HammerTime hammer;

    //private Interactable interactable;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hammer = GetComponentInChildren<HammerTime>();
        executedTime = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //intro text
        if (showText)
        {
            currentTime = Time.time;

            
                if (currentTime - executedTime > timeShown)
                {
                    executedTime = 0.0f;
                    showText = false;
                }
            
        }

        Vector2 velocity = Vector2.zero;
        float h = Input.GetAxis("Horizontal");
        if (rb.velocity.x * h < maxVelocity)
        {
            velocity.x = h * walkSpeed * rb.mass * Time.deltaTime;
            
            if(h<0)
            {
                //transform.Rotate(new Vector3(0, 0, 180* h));
                spriteRenderer.flipX = true;
            }
            else if(h>0)
            {
                spriteRenderer.flipX = false;
            }
        }

        //Jump
        if (Input.GetKeyDown("up") && !isFalling)
        {
            velocity.y = jumpSpeed * rb.mass;
            isFalling = true;
        }


        
        //Hammer
        if (Input.GetKeyDown("space") && hammer != null)
        {
            if(!hammer.isSwinging())
            {
                hammer.Swing(spriteRenderer.flipX);
            }
        }

        rb.AddForce(velocity, ForceMode2D.Impulse);
        //rb.velocity -= rb.velocity * (1 - friction);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (canInteract && Input.GetKeyDown("space"))
        {
            var interactable = collider.gameObject.GetComponent<Interactable>();
            if(interactable != null)
            {
                interactable.Interact(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Finish")
        {
            //change scene
            //Application.LoadLevel("HighScore");
            SceneManager.LoadScene("Lab");

        }
    }

    void OnGUI()
    {
        if (showText)
            GUI.Label(textArea, introText, introStyle);
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
