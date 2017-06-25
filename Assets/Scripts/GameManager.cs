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
        public float countDownTimer = 0;
        void Awake() {
			bombPrefabs = Resources.LoadAll<GameObject>("Bombs");
			fruitPrefabs = Resources.LoadAll<GameObject>("Fruits");
			soccerBallPrefab = Resources.Load<GameObject>("SoccerBall");
        }
        // Use this for initialization
        void Start() {
          
            StartCoroutine(GenerateItems(20, 5));
            state = State.Ready;
        
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetMouseButtonDown(0)) {
				StartCoroutine(GenerateItems(20,0));
            }

        }

        public IEnumerator GenerateItems(int n,float timer) {
		
            yield return new WaitForSeconds(timer);
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

        void GenerateBomb (int n,Vector3 center)
		{
			for (int i = 0; i < n; i++) {
               float theta = Random.Range(0f,360f);
               float r = Random.Range(1.0f,2.0f);
				Vector3 pos = center + new Vector3(Mathf.Cos(theta*Mathf.PI/180),0,Mathf.Sin(theta*Mathf.PI/180))*r;
				int index = Random.Range(0,bombPrefabs.Length);
                Instantiate(bombPrefabs[index], pos, Random.rotation);
            }

		}
		void GenerateFruit (int n,Vector3 center)
		{
			for (int i = 0; i < n; i++) {
               float theta = Random.Range(0f,360f);
               float r = Random.Range(1.0f,2.0f);
				Vector3 pos = center + new Vector3(Mathf.Cos(theta*Mathf.PI/180),0,Mathf.Sin(theta*Mathf.PI/180))*r;
				int index2 = Random.Range(0,fruitPrefabs.Length);
                Instantiate(fruitPrefabs[index2], pos, Random.rotation);
            }

		}

        void GenerateSoccerBalls (int n)
		{
			for (int i = 0; i < n; i++) {
                Vector3 pos = Camera.main.transform.position + new Vector3(Random.Range(-3.0f, 3.0f), 0, Random.Range(1f, 5f));
                Instantiate(soccerBallPrefab, pos, Random.rotation);
				GenerateBomb(5,pos);
				GenerateFruit(10,pos);
            }
		}

		public void ChangeState (State input)
		{
			State currentState = state;
			if (input == State.Ready) {
				


			} else if (input == State.Play) {


			} else if (input == State.GameOver) {


			}


		}


    }



}


public enum State{
	Ready,
	Play,
	GameOver
}