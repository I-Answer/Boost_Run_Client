using UnityEngine;

public class ScrollManager : MonoBehaviour {

    private Transform scrollTransform;
    private Vector3 pivotPos;
    private Vector3 vec;

	private void Awake () {
        scrollTransform = transform;
        pivotPos = scrollTransform.position;
        vec = Vector3.zero;
	}

    private void Update() {
        vec.Set(scrollTransform.position.x, pivotPos.y, scrollTransform.position.z);
        scrollTransform.position = vec;
    }
}
