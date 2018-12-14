using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] spaceShipList;

    public const float distance = 10f;

    private readonly Vector3 spawnPos;
    private readonly Quaternion spawnRot;
    private readonly Vector3 spawnScale;

    private int maxSpeed;
    private int endureTime;
    private int bitflag;

    private float startTime;

    public GameManager() {
        spawnPos = new Vector3(0f, 8f, -5f);
        spawnRot = Quaternion.Euler(15f, 0f, 0f);
        spawnScale = new Vector3(2f, 2f, 2f);
    }

    private void Awake() {
        ConnectPlayer(MakePlayer().GetComponent<Player>());

        maxSpeed = endureTime = 0;
        startTime = Time.time;
    }

    public void UpdateMaxSpeed(int nowSpeed) {
        maxSpeed = Mathf.Max(maxSpeed, nowSpeed);
    }

    public void GameOver() {
        Time.timeScale = 0f;
        endureTime = (int)(Time.time - startTime);

        var post = new Dictionary<string, string>();
        post.Add("speed", maxSpeed.ToString());
        post.Add("time", endureTime.ToString());
        post.Add("nick", UserManager.Instance.Player.Name);

        ServerConnector.Instance.POST<Result>(ServerApi.AddRecord, ActiveGameoverWindow, ServerConnector.ThrowIfFailed, post);
    }

    private GameObject MakePlayer() {
        GameObject playerObj = Instantiate(spaceShipList[UserManager.Instance.SelectSpaceShip]);

        playerObj.transform.position = spawnPos;
        playerObj.transform.rotation = spawnRot;
        playerObj.transform.localScale = spawnScale;

        return playerObj;
    }

    private void ConnectPlayer(Player player) {
        foreach (MonoBehaviour obj in FindObjectsOfType(typeof(MonoBehaviour))) {

            if (obj is IPlayerConnect) (obj as IPlayerConnect).PlayerConnect(player);
        }
    }

    private void ActiveGameoverWindow(Result[] result) {
        GameOver_UI.Active(maxSpeed, endureTime, GetChangeEventFlag());
    }

    private byte GetChangeEventFlag() {
        byte result = 0;

        if (UserManager.Instance.Player.CompareMaxSpeed(maxSpeed))
            result |= 0x01;

        if (UserManager.Instance.Player.CompareEndureTime(endureTime))
            result |= 0x02;

        return result;
    }
}
