using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] spaceShipList;

    private readonly Vector3 spawnPos;
    private readonly Quaternion spawnRot;
    private readonly Vector3 spawnScale;

    private static Player player;

    public GameManager() {
        spawnPos = new Vector3(0f, 8f, 0f);
        spawnRot = Quaternion.Euler(15f, 0f, 0f);
        spawnScale = new Vector3(2f, 2f, 2f);
    }

    private void Awake() {
        player = MakePlayer().GetComponent<Player>();
    }

    private GameObject MakePlayer() {
        GameObject playerObj = Instantiate(spaceShipList[UserInfo.SelectSpaceShip]);

        playerObj.transform.position = spawnPos;
        playerObj.transform.rotation = spawnRot;
        playerObj.transform.localScale = spawnScale;

        return playerObj;
    }

    public static void GameOver() {

    }

    public static Player Player {
        get { return player; }
    }
}
