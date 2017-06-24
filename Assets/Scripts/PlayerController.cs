using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace XRHack{
	public class PlayerController : MonoBehaviour,IInputClickHandler {
		RaycastHit hit;
		GameObject bombPrefab;

		GameObject[] bombs;

		void Awake(){
			bombPrefab = Resources.Load("Bomb") as GameObject;


		}
		
		// Use this for initialization
		void Start () {
			InputManager.Instance.PushFallbackInputHandler(gameObject);
            bombs = GameObject.FindGameObjectsWithTag("Bomb");
		
		}
			
			// Update is called once per frame
		void Update ()
		{
			
			
			
			Ray ray = new Ray (transform.position, Vector3.down);
			if (Physics.SphereCast (ray, 0.5f, out hit)) {
				if (hit.collider.tag == "Bomb") {
					hit.collider.GetComponent<BombController> ().Explosion ();
				}
			}
			#if UNITY_EDITOR
			if (Input.GetMouseButtonDown (0)) {
				Generate();
			}
			#endif

		}

		public void OnInputClicked(InputClickedEventData e){
			Generate();
		}



		void Generate(){
            Vector3 pos = TransformToVector(transform,new Vector3(0,3,3));
			Instantiate(bombPrefab,pos,transform.rotation);
		}

        Vector3 TransformToVector(Transform trans, Vector3 dir) {
           return  trans.position + trans.forward * dir.z + trans.right * dir.x + trans.up * dir.y;
        }
	}
}
