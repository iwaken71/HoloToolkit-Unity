using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {
	GameObject Leftleg;
	[SerializeField]
	GameObject bloodPrefab;
	void Awake(){
		Leftleg = transform.Find("LeftLeg").gameObject;

	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Dead();
		}
	}
	public void Dead ()
	{
		Instantiate(bloodPrefab,Leftleg.transform.position,Quaternion.identity);
		Leftleg.SetActive(false);

	}
}
