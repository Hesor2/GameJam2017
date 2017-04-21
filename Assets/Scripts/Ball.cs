using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float rotationSpeed = 1;
    public float jumpHeight = 1;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void FixedUpdate()
    {
        //Rotation
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rb.AddTorque(-rotation);
        //rb.AddRelativeTorque(Vector3.back * rotation);

        //Jump
        if (Input.GetKey("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            
        }
    }
}
