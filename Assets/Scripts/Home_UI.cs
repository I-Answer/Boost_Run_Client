using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_UI : MonoBehaviour {

    public GameObject rank, align, shop, option;

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

    public void Buy(string spaceShipName) {
        GameManager.User.BuySpaceShip(spaceShipMap[spaceShipName]);
    }

    public void OpenAlign() {
        align.SetActive(true);
    }

    public void CloseAlign() {
        align.SetActive(false);
    }

    public void OpenShop() {
        shop.SetActive(true);
    }

    public void CloseShop() {
        shop.SetActive(false);
    }
}
