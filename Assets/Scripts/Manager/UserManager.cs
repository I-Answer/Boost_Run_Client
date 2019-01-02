using UnityEngine;

public class UserManager : MonoBehaviour {

    public static readonly RegalUser OfflineUser =
        new RegalUser("Offline", 0, 0, (1 << (int)SpaceShipList.All) - 1);

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
        selectIndex = (int)SpaceShipList.Red;

        SoundManager.Init(playerInfo.Name);
    }

    public void SetPlayer(RegalUser user) {
        playerInfo = user;
        selectIndex = (int)SpaceShipList.Red;

        SoundManager.Init(playerInfo.Name);
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
