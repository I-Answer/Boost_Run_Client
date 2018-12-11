using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour {

    public GameObject[] spaceShipList;

	public class InGameManager {

        private readonly Vector3 spawnPos;
        private readonly Quaternion spawnRot;
        private readonly Vector3 spawnScale;

        private GameObject playerObj;

        private float startTime;
        private int maxSpeed;

        public InGameManager() {
            spawnPos = new Vector3(0f, 8f, 0f);
            spawnRot = Quaternion.Euler(15f, 0f, 0f);
            spawnScale = new Vector3(2f, 2f, 2f);
        }

        public void Init() {
            MakePlayer();
            playerObj.GetComponent<Player>().SpeedEvent = CompareSpeed;

            maxSpeed = 0;
            startTime = Time.time;
        }

        private void MakePlayer() {
            playerObj = Instantiate(instance.spaceShipList[User.SelectSpaceShip]);

            playerObj.transform.position = spawnPos;
            playerObj.transform.rotation = spawnRot;
            playerObj.transform.localScale = spawnScale;
        }

        public void GameOver() {
            Time.timeScale = 0f;

            int endureTime = Mathf.RoundToInt(Time.time - startTime);

            GameObject.Find("Canvas").transform.Find("Game Set Window").GetComponent<GameOver_UI>().Active(maxSpeed, endureTime, CompareMaxScore(endureTime));
        }

        private void CompareSpeed(int newSpeed) {
            if (newSpeed > maxSpeed)
                maxSpeed = newSpeed;
        }

        private byte CompareMaxScore(int endureTime) {
            byte result = 0;

            if (User.CompareMaxSpeed(maxSpeed))
                result |= 0x1;

            if (User.ComapreEndureTime(endureTime))
                result |= 0x2;

            return result;
        }
    }
}
