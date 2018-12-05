using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private new GameObject gameObject;
    private new Transform transform;

    private Player player;

    private uint playerSpeed;
    private float playerPos;

    private bool bCollision;

    private void Awake() {
        GameObject playerObj = GameObject.FindWithTag("Player");

        playerObj.GetComponent<PlayerSpeed>().SpeedEvent = (newSpeed) => playerSpeed = newSpeed;

        player = playerObj.GetComponent<Player>();
        playerPos = player.Position.z;

        gameObject = base.gameObject;
        transform = base.transform;

        gameObject.SetActive(false);
    }

    public void Active(System.Action<Obstacle> Arrange, Vector3 appearPos) {
        gameObject.SetActive(true);
        transform.localPosition = appearPos;

        bCollision = false;

        StartCoroutine(Move(Arrange));
    }

    private IEnumerator Move(System.Action<Obstacle> Arrange) {
        while (transform.localPosition.z > 0f) {
            transform.Translate(0, 0, -playerSpeed * 0.4f * Time.deltaTime);

            if (IsCollision())
                player.Collision();

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
