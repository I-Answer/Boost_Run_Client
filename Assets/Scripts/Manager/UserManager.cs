using UnityEngine;

public class UserManager : MonoBehaviour {

    private static UserManager instance;

    public static UserManager Instance {
        get {
            if (instance == null) {
                UserManager self = FindObjectOfType<UserManager>();

                DontDestroyOnLoad(self.gameObject);
                instance = self;
            }

            return instance;
        }
    }

    private RegalUser playerInfo;
    public int selectIndex;

    public void SetPlayer(UserAllInfo[] user) {
        playerInfo = new RegalUser(user[0].nick, user[0].maxSpeed, user[0].maxTime, user[0].bitflag);
        selectIndex = PlayerPrefs.GetInt(Player.Name, 0);
    }

    public RegalUser Player {
        get { return playerInfo; }
    }

    public int SelectSpaceShip {
        get { return selectIndex; }
    }

    public bool SelectNewSpaceShip(int newSpaceShip) {
        if ((Player.CarList & (1 << newSpaceShip)) == 0)
            return false;

        selectIndex = newSpaceShip;
        PlayerPrefs.SetInt(Player.Name, newSpaceShip);

        return true;
    }
}
