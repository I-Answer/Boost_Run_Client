using UnityEngine;
using UnityEngine.EventSystems;

public class Arrow_UI : MonoBehaviour, IPointerDownHandler, IPlayerConnect {

    public enum Direction {
        LEFT = -1, RIGHT = 1
    }

    public Direction direction;

    private Vector3 myMoveVector;
    private Player player;

    public void PlayerConnect(Player player) {
        this.player = player;
    }

    private void Awake() {
        myMoveVector = Vector3.zero;
        myMoveVector.x = (int)direction * GameManager.distance;
    }

#if UNITY_EDITOR
    private void Update() {
        if (Input.GetAxisRaw("Horizontal") != 0)
            Move();
    }
#endif

    public void OnPointerDown(PointerEventData ped) {
        Move();
    }

    private void Move() {
        // 눌렀을 때 맵을 벗어나지 않는다면 움직임
        if (Mathf.Abs(player.Position.x + myMoveVector.x) <= GameManager.distance)
            player.Move(player.Position + myMoveVector);
    }
}