using UnityEngine;

public class UserManager : MonoBehaviour {

    public static readonly RegalUser OfflineUser =
        new RegalUser("Offline", 0, 0, (1 << (int)SpaceShipList.All) - 1, (int)SpaceShipList.Red);

    private static UserManager instance;

    private static UserManager Instance {
        get {
            if (instance == null) {
                UserManager self = FindObjectOfType<UserManager>();

                DontDestroyOnLoad(self.gameObject);
                instance = self;
            }

            return instance;
        }
    }

    private RegalUser player;

    public static RegalUser Player {
        get { return Instance.player; }
        private set { Instance.player = value; }
    }

    public static void SetPlayer(UserInfo user) {
        Player = new RegalUser(user.name, user.maxSpeed, user.maxTime, user.spaceShipList, user.nowSpaceShip);

        SoundManager.Init(Player.Name);
    }

    public static void SetPlayer(RegalUser user) {
        Player = user;

        SoundManager.Init(Player.Name);
    }
}
