using UnityEngine;
using UnityEngine.EventSystems;

public class Arrow_UI : MonoBehaviour, IPointerDownHandler, IPlayerConnect {

    public enum Direction {
        LEFT = -1, RIGHT = 1
    }

    public Direction direction;

    private Vector3 myMoveVector;
    private Player player;
    private float maxDistance;

    public void PlayerConnect(Player player) {
        this.player = player;
    }

    private void Awake() {
        myMoveVector = Vector3.zero;
        myMoveVector.x = (float)direction * GameManager.distance;

        maxDistance = GameManager.distance * (GameManager.posCount / 2);

#if UNITY_EDITOR
        if (direction.Equals(Direction.LEFT))
            inputKey = KeyCode.LeftArrow;
        else inputKey = KeyCode.RightArrow;
#endif
    }

#if UNITY_EDITOR
    KeyCode inputKey;

    private void Update() {
        if (Input.GetKeyDown(inputKey))
            Move();
    }
#endif

    public void OnPointerDown(PointerEventData ped) {
        Move();
    }

    private void Move() {
        // 눌렀을 때 맵을 벗어나지 않는다면 움직임
        if (Mathf.Abs(player.Position.x + myMoveVector.x) <= maxDistance)
            player.Move(player.Position + myMoveVector);
    }
}