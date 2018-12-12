using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerConnector : MonoBehaviour {

    private static ServerConnector instance = null;

    public static ServerConnector Instance {
        get { return instance; }
    }

    private void Awake() {
        if (instance != null) return;

        DontDestroyOnLoad(gameObject);
        instance = this;

        // 매개변수는 서버에서 가져올것
        //UserInfo.Init("TempName", 0, 0, SpaceShipState.Red);
    }
}
