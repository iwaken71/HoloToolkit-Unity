using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XRHack{
	public class PlayerController : MonoBehaviour {
		RaycastHit hit;
		
		// Use this for initialization
		void Start () {
				
		}
			
			// Update is called once per frame
		void Update ()
		{
			Ray ray = new Ray (transform.position, -transform.up);
			if (Physics.SphereCast (ray, 0.05f ,out hit)) {
				if (hit.collider.tag == "Bomb") {
					hit.collider.GetComponent<BombController>().Explosion();
				}
			}

		}
	}
}
