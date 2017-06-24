using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace XRHack{
    
	public class BombController : MonoBehaviour {

		GameObject explosionPrefab;
   

		void Awake ()
		{	
			explosionPrefab = Resources.Load("BloodFX_impact_col")as GameObject;


		}
		public void Explosion(){
			Vector3 pos =TransformToVector(Camera.main.transform,new Vector3(0,-0.1f,1.3f));
			GameObject explosionObject = Instantiate(explosionPrefab,pos,transform.rotation)as GameObject;
            Destroy(explosionObject,5);
			Destroy(this.gameObject);
		}

		Vector3 TransformToVector(Transform trans, Vector3 dir) {
           return  trans.position + trans.forward * dir.z + trans.right * dir.x + trans.up * dir.y;
        }
	}
}
