using System;
using System.Collections.Generic;

public enum SpaceShipList {
    Red, Pink, Yellow, Green, Sky, Purple
}

public class RegalUser {

    private string name;
    private int maxSpeed;
    private int endureTime;
    private int spaceShipList;

    public RegalUser(string name, int maxSpeed, int endureTime, int spaceShipList) {
        this.name = name;
        this.maxSpeed = maxSpeed;
        this.endureTime = endureTime;
        this.spaceShipList = spaceShipList;
    }

    public void BuySpaceShip(int buySpaceShip, Action<UserSpaceship[]> applyUi) {
        if ((spaceShipList & buySpaceShip) != 0) return;

        var bitflagMap = new Dictionary<string, string>();
        bitflagMap.Add("nick", UserManager.Player.Name);
        bitflagMap.Add("bitflag", buySpaceShip.ToString());

        spaceShipList |= buySpaceShip;
        ServerConnector.Instance.POST(ServerApi.Bitflag, applyUi, ServerConnector.ThrowIfFailed, bitflagMap);
    }

    public bool CompareMaxSpeed(int nowSpeed) {
        if (nowSpeed > maxSpeed) {
            maxSpeed = nowSpeed;
            return true;
        }

        return false;
    }

    public bool CompareEndureTime(int nowEndureTime) {
        if (nowEndureTime > endureTime) {
            endureTime = nowEndureTime;
            return true;
        }

        return false;
    }

    public string Name {
        get { return name; }
    }

    public int MaxSpeed {
        get { return maxSpeed; }
    }

    public int EndureTime {
        get { return endureTime; }
    }

    public int CarList {
        get { return spaceShipList; }
    }
}

[Serializable]
public class UserAllInfo {
    public string id;
    public string password;
    public string nick;
    public int bitflag;
    public int maxSpeed;
    public int maxTime;
}

[Serializable]
public class UserSpeed {
    public string id;
    public string nick;
    public int maxSpeed;
}

[Serializable]
public class UserTime {
    public string id;
    public string nick;
    public int maxTime;
}

[Serializable]
public class UserInfo {
    public string id;
    public string password;
    public string nick;
}

[Serializable]
public class UserSpaceship {
    public string nick;
    public int bitflag;
}

[Serializable]
public class Record {
    public int maxSpeed;
    public int maxTime;
}

[Serializable]
public class Result {
    public bool success;
}