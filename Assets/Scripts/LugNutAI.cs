using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LugNutAI : MonoBehaviour
{
    public float torque = 5;
    public float aggroRange = 20;
    GameObject player;
    Rigidbody2D rb;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        //print(player.transform.position);

        rb = GetComponent<Rigidbody2D>();
		
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
            }
            //left
            else
            {
                rb.AddTorque(torque);
            }
        }
	}
}
