using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRHack;
using HoloToolkit.Unity;
namespace XRHack {
    public class GameManager : SingletonMonoBehaviour<GameManager> {
        GameObject[] bombPrefabs;
        GameObject[] fruitPrefabs;
        GameObject soccerBallPrefab;
        public State state;
        public float countDownTimer = 5;

        GameObject bombParent;
        GameObject fruitParent;
        GameObject ballParent;

        GameObject selectedBomb = null;
        void Awake() {
			bombPrefabs = Resources.LoadAll<GameObject>("Bombs");
			fruitPrefabs = Resources.LoadAll<GameObject>("Fruits");
			soccerBallPrefab = Resources.Load<GameObject>("SoccerBall");
            bombParent = new GameObject("bombParent");
            fruitParent = new GameObject("fruitParent");
            ballParent = new GameObject("ballParent");
        }
        // Use this for initialization
        void Start() {
          
            //StartCoroutine(GenerateItems(20, 5));
            ChangeState(State.Ready);
        
        }



        // Update is called once per frame
        void Update ()
		{
			//Debug.Log(state);
			if (state == State.Ready) {
				countDownTimer -= Time.deltaTime;
				if (countDownTimer <= 0) {
					ChangeState (State.Play);
					countDownTimer = 5;
                  
				}
			} else if (state == State.Play) {
			} else if (state == State.GameOver) {
				if (selectedBomb != null) {

                    //selectedBomb.transform.position = TransformToVector(Camera.main.transform,new Vector3(0,0,1.5f));
                   
                    if (UIManager.Instance.panel.activeSelf) {
                        selectedBomb.SetActive(false);
                    } else {
                        selectedBomb.SetActive(true);
                    }

                    Vector3 cameraPos = Vector3.Scale(Camera.main.transform.position, new Vector3(1, 0, 1));
                    Vector3 bombPos = Vector3.Scale(selectedBomb.transform.position, new Vector3(1, 0, 1));
                    float distance = (cameraPos - bombPos).sqrMagnitude;
                    if(distance < 0.5f * 0.5f){
                        ChangeState(State.Ready);
                    }

                }
			}
            if (Input.GetMouseButtonDown(0)) {
				//StartCoroutine(GenerateItems(20,0));
            }

        }

        public void SetSelectBomb (GameObject input)
		{
            if (selectedBomb != null)
                Destroy(selectedBomb);
			selectedBomb = Instantiate(input) as GameObject;
			selectedBomb.GetComponent<Rigidbody>().useGravity = false;
            selectedBomb.transform.position = TransformToVector(Camera.main.transform, new Vector3(0, 0, 1.5f));
            selectedBomb.transform.rotation = Quaternion.identity;
            selectedBomb.transform.tag = "Model";
            // selectedBomb.SetActive(false);

        }

        void DeleteAllObject() {
            DeleteAllChildren(ballParent.transform);
            DeleteAllChildren(bombParent.transform);
            DeleteAllChildren(fruitParent.transform);
        }
        public void GenerateItems() {

            DeleteAllObject();
           // yield return new WaitForSeconds(timer);
           /* for (int i = 0; i < n; i++) {
                Vector3 pos = transform.position + new Vector3(Random.Range(-3.0f, 3.0f), -0.5f, Random.Range(1f, 5f));
                int index = Random.Range(0,bombPrefabs.Length);
                Instantiate(bombPrefabs[index], pos, Random.rotation);

				Vector3 pos2 = transform.position + new Vector3(Random.Range(-3.0f, 3.0f), -0.5f, Random.Range(1f, 5f));
                int index2 = Random.Range(0,fruitPrefabs.Length);
                Instantiate(fruitPrefabs[index2], pos, Random.rotation);
            }*/

            GenerateSoccerBalls(5);
			

        }

        void DeleteAllChildren(Transform tran) {
            if (tran.childCount == 0) return;

            for (int i = 0; i < tran.childCount; i++) {
                Destroy(tran.GetChild(i).gameObject);
            }
        }

        void GenerateBomb (int n,Vector3 center)
		{
			for (int i = 0; i < n; i++) {
               float theta = Random.Range(0f,360f);
               float r = Random.Range(1.0f,2.0f);
				Vector3 pos = center + new Vector3(Mathf.Cos(theta*Mathf.PI/180),0,Mathf.Sin(theta*Mathf.PI/180))*r;
				int index = Random.Range(0,bombPrefabs.Length);

               GameObject obj =  Instantiate(bombPrefabs[index], pos, Random.rotation)as GameObject;
               obj.transform.parent = bombParent.transform;
            }

		}
		void GenerateFruit (int n,Vector3 center)
		{
			for (int i = 0; i < n; i++) {
               float theta = Random.Range(0f,360f);
               float r = Random.Range(1.0f,2.0f);
				Vector3 pos = center + new Vector3(Mathf.Cos(theta*Mathf.PI/180),0,Mathf.Sin(theta*Mathf.PI/180))*r;
				int index2 = Random.Range(0,fruitPrefabs.Length);
                var  obj =  Instantiate(fruitPrefabs[index2], pos, Random.rotation) as GameObject;
                obj.transform.parent = fruitParent.transform;
            }

		}

        void GenerateSoccerBalls (int n)
		{
			for (int i = 0; i < n; i++) {
                Vector3 pos = Camera.main.transform.position + new Vector3(Random.Range(-3.0f, 3.0f), 0, Random.Range(1f, 5f));
                GameObject obj =   Instantiate(soccerBallPrefab, pos, Random.rotation)as GameObject;
                obj.transform.parent = ballParent.transform;
			    GenerateBomb(5,pos);
			    GenerateFruit(10,pos);
            }
		}

		public void ChangeState (State input)
		{
			State currentState = state;
            if (input == State.Ready) {

                countDownTimer = 5;
                if (selectedBomb != null) {
                    Destroy(selectedBomb.gameObject);
                }

            } else if (input == State.Play) {
                if (currentState == State.Ready) { 
                    GenerateItems();
                }
			} else if (input == State.GameOver) {
                DeleteAllObject();

                UIManager.Instance.SetImage();
          
			}

			state = input;
            Debug.Log(state);
		}
		Vector3 TransformToVector(Transform trans, Vector3 dir) {
           return  trans.position + trans.forward * dir.z + trans.right * dir.x + trans.up * dir.y;
        }
    }
}


public enum State{
	Ready,
	Play,
	GameOver
}