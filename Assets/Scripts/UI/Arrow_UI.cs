using UnityEngine;
using UnityEngine.EventSystems;

public class Arrow_UI : MonoBehaviour, IPointerDownHandler, IPlayerConnect {

    public Vector3 myMoveVector;
    private Player player;

    public void PlayerConnect(Player player) {
        this.player = player;
    }

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
        if (Mathf.Abs(player.Position.x + myMoveVector.x) <= 10)
            player.Move(player.Position + myMoveVector);
    }
}