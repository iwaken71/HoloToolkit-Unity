using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace XRHack {
    public class NamePlateManager : MonoBehaviour {

        [SerializeField] GameObject panel;
        [SerializeField] Text label;
        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
           
            if (GameManager.Instance.selectedBomb != null) {
                panel.gameObject.SetActive(true);
                label.text = (GameManager.Instance.selectedBomb.name).Replace("(Clone)","");
                transform.position = GameManager.Instance.selectedBomb.transform.position + new Vector3(0, 0.09f, 0);
            } else {
                panel.gameObject.SetActive(false);
               
            }



        }
    }
}
