using UnityEngine;
using System.Collections;

public class Collider : MonoBehaviour {

    public string tag;
    Collidable parentScript;


	// Use this for initialization
	void Start ()
    {
        parentScript = GetComponentInParent<Collidable>();
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        parentScript.EnterCollision(tag, collision.gameObject);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        parentScript.EnterCollision(tag, collision.gameObject);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        parentScript.ExitCollision(tag, collision.gameObject);
    }
}
