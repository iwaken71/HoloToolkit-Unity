using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayObject : MonoBehaviour {

	Renderer rd;
	// Use this for initialization
	void Start () {

		rd = GetComponent<Renderer>();
		rd.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisoinEnter (Collision col)
	{
		//if (col.gameObject.tag != "Bomb" && col.gameObject.tag != "Fruit" && col.gameObject.tag != "SoccerBall") {
			rd.enabled = true;
		//}
	}
}
