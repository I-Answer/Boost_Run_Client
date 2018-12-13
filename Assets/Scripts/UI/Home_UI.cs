using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Home_UI : MonoBehaviour {

    public GameObject rank, repair, shop;

    public Image curImage;
    public Sprite[] spaceShipImage;

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

    public void Select(int buyShip) {
        if (UserManager.SelectNewSpaceShip(buyShip))
            curImage.sprite = spaceShipImage[buyShip];
    }

    public void Buy(int buyShip) {
        UserManager.Player.BuySpaceShip(1 << buyShip);
    }
}
