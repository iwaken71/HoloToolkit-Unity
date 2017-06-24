using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager> {

	[SerializeField]
	Image image;

	[SerializeField]
	Text label;
	
	Sprite[] sprites;

	public float smoothTime = 5f;





	void Awake(){
		sprites = Resources.LoadAll<Sprite>("Images");
	}

	void Start(){
		SetImage();
	}

	public void SetImage(){
		int index = Random.Range(0,sprites.Length);
		image.sprite = sprites[index];
		label.text = "injured";
	}

	void LateUpdate ()
	{	
		Vector3 pos = TransformToVector(Camera.main.transform,new Vector3(0,0,1.5f));
		transform.position =pos;// Vector3.Lerp(transform.position,pos,Time.deltaTime*smoothTime);

	}

	Vector3 TransformToVector(Transform trans, Vector3 dir) {
          return  trans.position + trans.forward * dir.z + trans.right * dir.x + trans.up * dir.y;
    }
}
