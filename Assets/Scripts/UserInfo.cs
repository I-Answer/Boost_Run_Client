using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum SpaceShipState : byte {
    Red = 1, Yellow = 2, Green = 4, Sky = 8, Pink = 16, Purple = 32
}

public static class UserInfo {

    private static string m_name;
    private static int m_maxSpeed;
    private static int m_endureTime;
    private static SpaceShipState m_spaceShipList;

    private static int m_selectSpaceShip;

    public static void Init(string name, int maxSpeed, int endureTime, SpaceShipState spaceShipList) {
        m_name = name;
        m_maxSpeed = maxSpeed;
        m_endureTime = endureTime;
        m_spaceShipList = spaceShipList;

        m_selectSpaceShip = 0;
    }

    public static void BuySpaceShip(SpaceShipState buySpaceShip) {
        m_spaceShipList |= buySpaceShip;
    }

    public static bool CompareMaxSpeed(int nowSpeed) {
        if (nowSpeed > m_maxSpeed) {
            m_maxSpeed = nowSpeed;
            return true;
        }

        return false;
    }

    public static bool ComapreEndureTime(int nowEndureTime) {
        if (nowEndureTime > m_endureTime) {
            m_endureTime = nowEndureTime;
            return true;
        }

        return false;
    }

    public static string Name {
        get { return m_name; }
    }

    public static SpaceShipState CarList {
        get { return m_spaceShipList; }
    }

    public static int SelectSpaceShip {
        get { return m_selectSpaceShip; }
    }
}
