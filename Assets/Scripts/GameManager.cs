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
            //StartCoroutine(GenerateBombAround(20, 7));
            state = State.Ready;
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetMouseButtonDown(0)) {
                StartCoroutine(GenerateBombAround(20,0));
            }

        }

        public IEnumerator GenerateBombAround(int n,float timer) {
            yield return new WaitForSeconds(timer);
            for (int i = 0; i < n; i++) {
                Vector3 pos = transform.position + new Vector3(Random.Range(-3.0f, 3.0f), -0.5f, Random.Range(1f, 5f));
                int index = Random.Range(0,bombPrefabs.Length);
                Instantiate(bombPrefabs[index], pos, Random.rotation);

				Vector3 pos2 = transform.position + new Vector3(Random.Range(-3.0f, 3.0f), -0.5f, Random.Range(1f, 5f));
                int index2 = Random.Range(0,fruitPrefabs.Length);
                Instantiate(fruitPrefabs[index2], pos, Random.rotation);
            }

			GenerateSoccerBall(5);

        }

        void GenerateSoccerBall (int n)
		{
			for (int i = 0; i < n; i++) {
                Vector3 pos = transform.position + new Vector3(Random.Range(-3.0f, 3.0f), -0.5f, Random.Range(1f, 5f));
                Instantiate(soccerBallPrefab, pos, Random.rotation);

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