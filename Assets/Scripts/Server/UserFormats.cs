using System;
using UnityEngine.Networking;

public enum SpaceShipList {
    Red, Pink, Yellow, Green, Sky, Purple, All
}

public class RegalUser {

    public string Name { get; private set; }
    public int MaxSpeed { get; private set; }
    public int EndureTime { get; private set; }
    public int SpaceShipList { get; private set; }
    public int NowSpaceShip { get; private set; }

    public RegalUser(string name, int maxSpeed, int endureTime, int spaceShipList, int nowSpaceShip) {
        Name = name;
        MaxSpeed = maxSpeed;
        EndureTime = endureTime;
        SpaceShipList = spaceShipList;
        NowSpaceShip = nowSpaceShip;
    }

    public void BuySpaceShip(int buySpaceShip, Action<Result[]> applyUi) {
        if ((SpaceShipList & buySpaceShip) != 0) return;

        SpaceShipList |= buySpaceShip;

        ServerConnector.POST(applyUi, ServerApi.Bitflag,
            new MultipartFormDataSection("nick", UserManager.Player.Name),
            new MultipartFormDataSection("bitflag", buySpaceShip.ToString()));
    }

    public bool CompareMaxSpeed(int nowSpeed) {
        if (nowSpeed > MaxSpeed) {
            MaxSpeed = nowSpeed;
            return true;
        }

        return false;
    }

    public bool CompareEndureTime(int nowEndureTime) {
        if (nowEndureTime > EndureTime) {
            EndureTime = nowEndureTime;
            return true;
        }

        return false;
    }

    public bool SelectNewSpaceShip(int newSpaceShip) {
        if ((SpaceShipList & (1 << newSpaceShip)) == 0)
            return false;

        NowSpaceShip = newSpaceShip;

        return true;
    }
}

[Serializable]
public class Result {
    public bool isSuccess;
}

[Serializable]
public class UserInfo : Result {
    public string name;
    public int spaceShipList;
    public int nowSpaceShip;
    public int sp;
    public int maxSpeed;
    public int maxTime;
}

[Serializable]
public class SP : Result {
    public int money;
}

[Serializable]
public class Rank {
    public string name;
    public int score;
}

[Serializable]
public class PersonalRank : Result {
    public int rank;
    public int score;
}