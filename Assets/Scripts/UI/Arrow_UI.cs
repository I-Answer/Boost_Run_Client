using UnityEngine;
using UnityEngine.EventSystems;

public class Arrow_UI : MonoBehaviour, IPointerDownHandler {

    public Vector3 myMoveVector;

#if UNITY_EDITOR
    private KeyCode key;

    private void Start() {
        if (myMoveVector.x > 0)
            key = KeyCode.RightArrow;

        else key = KeyCode.LeftArrow;
    }

    private void Update() {
        if (Input.GetKeyDown(key)) Move();
    }

#endif
    public void OnPointerDown(PointerEventData ped) {
        Move();
    }

    private void Move() {
        // 눌렀을 때 맵을 벗어나지 않는다면 움직임
        if (Mathf.Abs(GameManager.Player.Position.x + myMoveVector.x) <= 10)
            GameManager.Player.Move(GameManager.Player.Position + myMoveVector);
    }
}