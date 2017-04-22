using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LugNutAI : MonoBehaviour
{
    public float torque = 5;
    public float aggroRange = 20;
    GameObject player;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        //print(player.transform.position);

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance <= aggroRange)
        {
            float hDistance = player.transform.position.x - transform.position.x;
            //right
            if(hDistance > 0)
            {
                rb.AddTorque(-torque);
                spriteRenderer.flipX = false;
            }
            //left
            else
            {
                rb.AddTorque(torque);
                spriteRenderer.flipX = true;
            }

            /*if (h < 0)
            {
                //transform.Rotate(new Vector3(0, 0, 180* h));
                
            }
            else if (h > 0)
            {
                
            }*/
        }
	}
}
