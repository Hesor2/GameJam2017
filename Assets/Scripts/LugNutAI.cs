using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LugNutAI : MonoBehaviour {

    GameObject player;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        print(player.transform.position);

        rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
