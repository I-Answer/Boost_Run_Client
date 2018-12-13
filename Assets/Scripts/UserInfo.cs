/*[System.Flags]
public enum SpaceShipState : byte {
    Red = 1, Yellow = 2, Green = 4, Sky = 8, Pink = 16, Purple = 32
}

public class UserInfo {

    private string name;
    private int maxSpeed;
    private int endureTime;
    private SpaceShipState spaceShipList;

    public UserInfo(string name, int maxSpeed, int endureTime, SpaceShipState spaceShipList) {
        this.name = name;
        this.maxSpeed = maxSpeed;
        this.endureTime = endureTime;
        this.spaceShipList = spaceShipList;
    }

    public void BuySpaceShip(SpaceShipState buySpaceShip) {
        spaceShipList |= buySpaceShip;
    }

    public bool CompareMaxSpeed(int nowSpeed) {
        if (nowSpeed > maxSpeed) {
            maxSpeed = nowSpeed;
            return true;
        }

        return false;
    }

    public bool ComapreEndureTime(int nowEndureTime) {
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

    public SpaceShipState CarList {
        get { return spaceShipList; }
    }
}
*/