using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_UI : MonoBehaviour {

    public GameObject rank, repair, shop;

    private Dictionary<string, SpaceShipState> spaceShipMap;

    private void Awake() {
        spaceShipMap = new Dictionary<string, SpaceShipState>();

        spaceShipMap.Add("Red", SpaceShipState.Red);
        spaceShipMap.Add("Sky", SpaceShipState.Sky);
        spaceShipMap.Add("Pink", SpaceShipState.Pink);
        spaceShipMap.Add("Green", SpaceShipState.Green);
        spaceShipMap.Add("Yellow", SpaceShipState.Yellow);
        spaceShipMap.Add("Purple", SpaceShipState.Purple);
    }

    public void Play() {
        SceneManager.SceneLoad("StageScene");
    }

    public void OpenRank() {
        rank.SetActive(true);
    }

    public void CloseRank() {
        rank.SetActive(false);
    }

    public void OpenRepair() {
        repair.SetActive(true);
    }

    public void CloseRepair() {
        repair.SetActive(false);
    }

    public void OpenShop() {
        shop.SetActive(true);
    }

    public void CloseShop() {
        shop.SetActive(false);
    }

    public void Buy(string spaceShipName) {
        UserManager.Player.BuySpaceShip(spaceShipMap[spaceShipName]);
    }
}
