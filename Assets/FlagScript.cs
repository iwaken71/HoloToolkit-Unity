using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour {
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -2.0f) {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
        } else {
            rb.useGravity = true;
        }
	}
}
