using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace XRHack{
	public class PlayerController : MonoBehaviour,IInputClickHandler {
		RaycastHit hit;
		GameObject bombPrefab;

		void Awake(){
			bombPrefab = Resources.Load("Bomb") as GameObject;


		}
		
		// Use this for initialization
		void Start () {
			InputManager.Instance.PushFallbackInputHandler(gameObject);
		}
			
			// Update is called once per frame
		void Update ()
		{
			Ray ray = new Ray (transform.position, -transform.up);
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
			Instantiate(bombPrefab,transform.position + new Vector3(0,3,2),transform.rotation);
		}
	}
}
