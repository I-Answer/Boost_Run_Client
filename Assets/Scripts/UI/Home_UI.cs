using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home_UI : MonoBehaviour {

    public GameObject rank, align, shop, option;
    public GameObject soundOn, soundOff;
    public GameObject speedRank, timeRank;
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
        UserInfo.BuySpaceShip(spaceShipMap[spaceShipName]);
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

    public void OpenOption()
    {
        option.SetActive(true);
    }

    public void CloseOption()
    {
        option.SetActive(false);
    }

    public void OpenRank()
    {
        rank.SetActive(true);
    }

    public void CloseRank()
    {
        rank.SetActive(false);
    }

    public void SoundChange()
    {
        GameManager.SoundManager sound = GameManager.Sound;

        if(sound.Volume.Equals(0f))
        {
            sound.Volume = 1f;
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }

        else
        {
            sound.Volume = 0f;
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }
    }
}
