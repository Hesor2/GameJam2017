using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject target;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 targetPos = target.transform.position;
        Vector3 position = new Vector3(targetPos.x, targetPos.y, transform.position.z);
        transform.position = position;
	}
}
