using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRHack;
using HoloToolkit.Unity;
namespace XRHack {
    public class GameManager : SingletonMonoBehaviour<GameManager> {
        GameObject bombPrefab;
        void Awake() {
            bombPrefab = Resources.Load("Bomb") as GameObject;


        }
        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void GenerateBombAround(int n) {

            for (int i = 0; i < n; i++) {
                Vector3 pos = transform.position + new Vector3(Random.Range(-3.0f, 3.0f), 30, Random.Range(-3.0f, 3.0f));
                Instantiate(bombPrefab, pos, transform.rotation);
            }
        }


    }

}