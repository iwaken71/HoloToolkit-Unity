using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XRHack{
	public class UIManager : SingletonMonoBehaviour<UIManager> {

		[SerializeField]
		Image image;

		[SerializeField]
		Text label;

		public 
		GameObject panel;
		
		Sprite[] sprites;

		public float smoothTime = 5f;

		void Awake(){
			sprites = Resources.LoadAll<Sprite>("Images");
			//panel.transform.Find("Panel");
		}

		void Start(){
            //SetImage();
            SetEnable(false);
		}

		public void SetImage ()
		{
			int index = Random.Range (0, sprites.Length);
			image.sprite = sprites [index];
			label.text = "injured";
			SetEnable(false);
			//if (GameManager.Instance.state == State.GameOver) {
			StartCoroutine(DisPlay());
			//}
		}

		void SetEnable (bool input)
		{
			//Debug.Log(input);
            panel.SetActive(input);
          //  image.enabled = input;
			//label.enabled = input;
			

		}

		IEnumerator DisPlay(){

            yield return new WaitForSeconds(1f);
            SetEnable(true);
			yield return new WaitForSeconds(5);
            GameManager.Instance.DisPlayModel();
			SetEnable(false);
            yield return new WaitForSeconds(15);

           // if (GameManager.Instance.state == State.GameOver) {
             //   GameManager.Instance.ChangeState(State.Ready);
          //  }
          
        }

		void LateUpdate ()
		{	
			Vector3 pos = TransformToVector(Camera.main.transform,new Vector3(0,0,1.5f));
			transform.position =  Vector3.Lerp(transform.position,pos,Time.deltaTime*smoothTime);
            transform.forward = Vector3.Slerp(transform.forward, Camera.main.transform.forward, Time.deltaTime * smoothTime);
		}

		Vector3 TransformToVector(Transform trans, Vector3 dir) {
	          return  trans.position + trans.forward * dir.z + trans.right * dir.x + trans.up * dir.y;
	    }
	}
}





