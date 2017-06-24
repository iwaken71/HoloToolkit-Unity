using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

	GameObject explosionPrefab;

	void Awake ()
	{	
		explosionPrefab = Resources.Load("ExplosionMobile")as GameObject;

	}
	public void Explosion(){
		GameObject explosionObject = Instantiate(explosionPrefab,transform.position,transform.rotation)as GameObject;
		Destroy(explosionObject,5);
		Destroy(this.gameObject);
	}
}
