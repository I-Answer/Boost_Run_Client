using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour {

    private static UserManager instance;

    private UserInfo playerInfo;
    public int selectIndex;

    private void Awake() {
        if (instance != null) return;

        DontDestroyOnLoad(gameObject);
        instance = this;

        playerInfo = new UserInfo("TempName", 0, 0, SpaceShipState.Red | SpaceShipState.Pink | SpaceShipState.Yellow | SpaceShipState.Green | SpaceShipState.Sky | SpaceShipState.Purple);
    }

    public static UserInfo Player {
        get { return instance.playerInfo; }
    }

    public static int SelectSpaceShip {
        get { return instance.selectIndex; }
    }
}
