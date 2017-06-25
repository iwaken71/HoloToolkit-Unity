using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace XRHack{
	public class PlayerController : MonoBehaviour {
		RaycastHit hit;
		GameObject bombPrefab;

		GameObject[] bombs;

		void Awake(){
			//bombPrefab = Resources.Load("Bomb") as GameObject;


		}
		
		// Use this for initialization
		void Start () {
			//InputManager.Instance.PushFallbackInputHandler(gameObject);
           // bombs = GameObject.FindGameObjectsWithTag("Bomb");
		
		}
			
			// Update is called once per frame
		void Update ()
		{
			
			
			
			Ray ray = new Ray (transform.position, Vector3.down);
			if (Physics.SphereCast (ray, 0.5f, out hit)) {
				string tagName = hit.collider.tag;
				if (tagName == "Bomb") {
                    GameManager.Instance.ChangeState(State.GameOver);
                    GameManager.Instance.SetSelectBomb(hit.collider.gameObject);
					hit.collider.GetComponent<BombController> ().Explosion ();
				} 
			}
			if (Physics.SphereCast (ray, 1.5f, out hit)) {
				string tagName = hit.collider.tag;
				if (tagName == "SoccerBall") {
					KickBall(hit.collider.gameObject,100);
                    hit.collider.GetComponent<SoccerBallController>().PlayerKickSound();
                }
			}
//			#if UNITY_EDITOR
//			if (Input.GetMouseButtonDown (0)) {
//				Generate();
//			}
//			#endif

		}
/*
		public void OnInputClicked(InputClickedEventData e){
			Generate();
		}
        */

//        void AroundGenerate(int n) {
//            for (int i = 0; i < n; i++) {
//                Vector3 pos = transform.position + new Vector3(Random.Range(-3.0f,3.0f), 30,Random.Range(-3.0f, 3.0f));
//                Instantiate(bombPrefab, pos, transform.rotation);
//            }
//        }

//		void Generate(){
//            Vector3 pos = TransformToVector(transform,new Vector3(0,3,3));
//			Instantiate(bombPrefab,pos,transform.rotation);
//		}

        Vector3 TransformToVector(Transform trans, Vector3 dir) {
           return  trans.position + trans.forward * dir.z + trans.right * dir.x + trans.up * dir.y;
        }

        void KickBall (GameObject ball,float power)
		{	
			Vector3 vec = Vector3.Scale( (ball.transform.position - transform.position),new Vector3(1,0,1)).normalized;
			Vector3 kickForce = (vec + Vector3.up).normalized * power;

			ball.GetComponent<Rigidbody>().AddForce(kickForce);

		}
	}
}
