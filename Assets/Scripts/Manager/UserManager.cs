using UnityEngine;

public class UserManager : MonoBehaviour {

    private static UserManager instance;

    private RegalUser playerInfo;
    public int selectIndex;

    private void Awake() {
        if (instance != null) return;

        DontDestroyOnLoad(gameObject);
        instance = this;

        ServerConnector.Instance.GET<UserAllInfo>(ServerApi.GetUser + "2", SetPlayer, ServerConnector.ThrowIfFailed);
    }

    private void SetPlayer(UserAllInfo[] user) {
        playerInfo = new RegalUser(user[0].nick, user[0].maxSpeed, user[0].maxTime, user[0].bitflag);
        selectIndex = PlayerPrefs.GetInt("SelectIndex", 0);

        Debug.Log(playerInfo.Name);
    }

    public static RegalUser Player {
        get { return instance.playerInfo; }
    }

    public static int SelectSpaceShip {
        get { return instance.selectIndex; }
    }

    public static bool SelectNewSpaceShip(int newSpaceShip) {
        if ((Player.CarList & (1 << newSpaceShip)) == 0)
            return false;

        instance.selectIndex = newSpaceShip;
        PlayerPrefs.SetInt("SelectIndex", newSpaceShip);

        return true;
    }
}
