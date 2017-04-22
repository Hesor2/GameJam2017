using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTime : MonoBehaviour {

    public float forcetoapply = 10;
    public float swingDelay = 0.2f;
    public int swingSection = 16;
    private bool swinging = false;

    private int currentSection = 0;
    private Time lastSwingTime;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(swinging)
        {
            if(lastSwingTime == null)
            {

            }
        }
	}

    public void Swing()
    {
        swinging = true;
    }

    public bool isSwinging()
    {
        return swinging;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
             Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            var pcposition = gameObject.GetComponentInParent<Transform>().position;
            Vector2 pos = (Vector2)pcposition;

            Vector2 colpos = (Vector2)collision.gameObject.transform.position;

            Vector2 difference = pos - colpos;

            Vector2 direction = difference.normalized;

            rb.AddForce(direction * forcetoapply);


        }
    }
}
