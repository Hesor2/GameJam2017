using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTime : MonoBehaviour {

    public float forcetoapply = 10;
    public float swingDelay = 0.2f;
    public int swingSection = 16;
    private bool swinging = false;

    private int currentSection = 0;
    private float lastSwingTime = -1;
    private bool flipped = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(swinging)
        {
            if(lastSwingTime == -1)
            {
                lastSwingTime = Time.time;
                currentSection = 0;
            }
            else
            {
                if(Time.time - lastSwingTime>= swingDelay)
                {
                    lastSwingTime = Time.time;
                    //print("i get here");
                    float angle = 360 / swingSection;
                    int h;
                    if (flipped) h = 1;
                    else h = -1;
                    transform.Rotate(0, 0, angle * h);
                    if(currentSection == swingSection)
                    {
                        swinging = false;
                        transform.rotation = Quaternion.identity;
                        lastSwingTime = -1;
                    }
                    else
                    {
                        currentSection++;
                    }
                }
            }
        }
	}

    public void Swing(bool flipX)
    {
        swinging = true;
        flipped = flipX;
        //print("i got called");
    }

    public bool isSwinging()
    {
        return swinging;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
             Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            var pcposition = gameObject.GetComponentInParent<Transform>().position;
            Vector2 pos = (Vector2)pcposition;

            Vector2 colpos = (Vector2)collision.gameObject.transform.position;

            Vector2 difference = pos - colpos;

            Vector2 direction = difference.normalized;

            rb.AddForce(-direction * forcetoapply);
            print("did it");

        }
    }
}
