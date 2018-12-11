using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerConnector : MonoBehaviour {

    private void Awake() {
        // 매개변수는 서버에서 가져올것
        UserInfo.Init("TempName", 0, 0, SpaceShipState.Red);
    }
}
