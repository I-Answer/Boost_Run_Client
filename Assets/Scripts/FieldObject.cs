using System.Collections;
using UnityEngine;

public abstract class FieldObject : MonoBehaviour {

    private new GameObject gameObject;
    private new Transform transform;

    private Vector3 moveVec;

    private int playerSpeed;
    private bool bCollision;

    protected abstract void OnCollision();

    protected virtual void Awake() {
        gameObject = base.gameObject;
        transform = base.transform;

        moveVec = Vector3.zero;

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
            moveVec.z = GameManager.Player.Speed * 0.4f * Time.deltaTime;
            transform.position -= moveVec;

            if (IsCollision())
                OnCollision();

            yield return null;
        }

        Arrange(this);
        gameObject.SetActive(false);
    }

    private bool IsCollision() {
        if (bCollision || transform.position.z > GameManager.Player.Position.z) return false;

        bCollision = true;

        return Mathf.Approximately(GameManager.Player.Position.x, transform.position.x);
    }
}
