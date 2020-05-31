using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour {

    public GameObject[] spaceShipList;

    public const int posCount = 3;
    public const float distance = 10f;

    private readonly Vector3 spawnPos = new Vector3(0f, 8f, -5f);
    private readonly Quaternion spawnRot = Quaternion.Euler(15f, 0f, 0f);
    private readonly Vector3 spawnScale = new Vector3(2f, 2f, 2f);

    private int maxSpeed;
    private int endureTime;

    public float startTime;

    private void Awake() {
        ConnectPlayer(MakePlayer().GetComponent<Player>());

        startTime = Time.time;
    }

    public void UpdateMaxSpeed(int nowSpeed) {
        maxSpeed = Mathf.Max(maxSpeed, nowSpeed);
    }

    public void GameOver() {
        Time.timeScale = 0f;
        endureTime = (int)(Time.time - startTime);

        GameOver_UI.Instance.Active(maxSpeed, endureTime, GetChangeEventFlag());

        if (!NetworkManager.IsConnected) return;
            
        ServerConnector.POST<Result>(null, ServerApi.AddRecord,
            new MultipartFormDataSection("speed", maxSpeed.ToString()),
            new MultipartFormDataSection("time", endureTime.ToString()),
            new MultipartFormDataSection("nick", UserManager.Player.Name));
    }

    public void GoHomeDirect() {
        Time.timeScale = 1f;
        SceneManager.SceneLoad("HomeScene");
    }
    
    private GameObject MakePlayer() {
        GameObject playerObj = Instantiate(spaceShipList[UserManager.Player.NowSpaceShip]);

        playerObj.transform.position = spawnPos;
        playerObj.transform.rotation = spawnRot;
        playerObj.transform.localScale = spawnScale;

        return playerObj;
    }

    private void ConnectPlayer(Player player) {
        foreach (MonoBehaviour obj in FindObjectsOfType(typeof(MonoBehaviour)))
            if (obj is IPlayerConnect) 
                (obj as IPlayerConnect).PlayerConnect(player);
    }

    private byte GetChangeEventFlag() {
        byte result = 0;

        if (UserManager.Player.CompareMaxSpeed(maxSpeed))
            result |= 0x01;

        if (UserManager.Player.CompareEndureTime(endureTime))
            result |= 0x02;

        return result;
    }
}
