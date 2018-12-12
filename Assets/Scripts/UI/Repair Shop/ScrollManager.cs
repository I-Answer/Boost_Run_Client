using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour {
    private Transform scrollTransform;
    private Vector3 pivotPos;
	// Use this for initialization
	void Start () {
        scrollTransform = GetComponent<Transform>();
        pivotPos = scrollTransform.position;
	}

    private void Update()
    {
        scrollTransform.position = new Vector3(scrollTransform.position.x, pivotPos.y, scrollTransform.position.z);
    }
}
