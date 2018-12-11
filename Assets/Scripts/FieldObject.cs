using System.Collections;
using UnityEngine;

public abstract class FieldObject : MonoBehaviour {

    private new GameObject gameObject;
    private new Transform transform;

    private Player player;
    private Vector3 moveVec;

    private int playerSpeed;
    private float playerPos;

    private bool bCollision;

    protected Player GetPlayer {
        get { return player; }
    }

    protected abstract void OnCollision();

    protected virtual void Awake() {
        gameObject = base.gameObject;
        transform = base.transform;

        moveVec = Vector3.zero;
    }

    private void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        player.SpeedEvent = (newSpeed) => playerSpeed = newSpeed;
        playerPos = player.Position.z;

        gameObject.SetActive(false);
    }

    public virtual void Active(System.Action<FieldObject> Arrange, Vector3 appearPos) {
        gameObject.SetActive(true);
        transform.localPosition = appearPos;

        bCollision = false;

        StartCoroutine(Move(Arrange));
    }

    private IEnumerator Move(System.Action<FieldObject> Arrange) {
        while (transform.localPosition.z > 0f) {
            moveVec.z = playerSpeed * 0.4f * Time.deltaTime;
            transform.position -= moveVec;

            if (IsCollision())
                OnCollision();

            yield return null;
        }

        Arrange(this);
        gameObject.SetActive(false);
    }

    private bool IsCollision() {
        if (bCollision || transform.position.z > playerPos) return false;

        bCollision = true;

        return Mathf.Approximately(player.Position.x, transform.position.x);
    }
}
