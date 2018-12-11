using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour {

    public class UserManager {

        private string name;
        private int maxSpeed;
        private int endureTime;
        private SpaceShipState spaceShipList;

        private int selectSpaceShip = 3;

        public UserManager(string name, int maxSpeed, int endureTime, SpaceShipState spaceShipList) {
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

        public SpaceShipState CarList {
            get { return spaceShipList; }
        }

        public int SelectSpaceShip {
            get { return selectSpaceShip; }
        }
    }
}
