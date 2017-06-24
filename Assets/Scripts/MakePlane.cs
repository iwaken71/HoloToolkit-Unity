﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;
using HoloToolkit.Unity.InputModule;

public class MakePlane : MonoBehaviour, IInputClickHandler {

	// Use this for initialization
	void Start () {
		//	エアタップ頂戴	
		InputManager.Instance.PushFallbackInputHandler(gameObject);

		//	壁とか作り終わったら教えて
		SurfaceMeshesToPlanes.Instance.MakePlanesComplete += SurfaceMeshesToPlanes_MakePlanesComplete;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnInputClicked(InputClickedEventData eventData)
	{
		//	エアタップされたらメッシュ作るの止めて、壁とか作る
		SpatialMappingManager.Instance.StopObserver();
		SurfaceMeshesToPlanes.Instance.MakePlanes();
	}

	//	壁とか出来たら呼ばれる	
	private void SurfaceMeshesToPlanes_MakePlanesComplete(object source, System.EventArgs args)
	{
		//	平面に内包されてる頂点を削除して軽くするみたい
		RemoveSurfaceVertices.Instance.RemoveSurfaceVerticesWithinBounds(SurfaceMeshesToPlanes.Instance.ActivePlanes);


		//SurfaceMeshesToPlanes.Instance.
	}
}