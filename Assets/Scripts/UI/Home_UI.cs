using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_UI : MonoBehaviour {

    public GameObject rank, repair, shop;
    public AudioClip clickSound;
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
        SoundManager.PlaySound(clickSound);
        rank.SetActive(true);
    }

    public void CloseRank() {
        SoundManager.PlaySound(clickSound);
        rank.SetActive(false);
    }

    public void OpenRepair() {
        SoundManager.PlaySound(clickSound);
        repair.SetActive(true);
    }

    public void CloseRepair() {
        SoundManager.PlaySound(clickSound);
        repair.SetActive(false);
    }

    public void OpenShop() {
        SoundManager.PlaySound(clickSound);
        shop.SetActive(true);
    }

    public void CloseShop() {
        SoundManager.PlaySound(clickSound);
        shop.SetActive(false);
    }

    public void Buy(string spaceShipName) {
        SoundManager.PlaySound(clickSound);
        UserManager.Player.BuySpaceShip(spaceShipMap[spaceShipName]);
    }
}
