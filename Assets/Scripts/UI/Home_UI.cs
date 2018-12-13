using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Home_UI : MonoBehaviour {

    [System.Serializable]
    public struct Content {
        public Image repair;
        public Image shop;
        public Sprite sprite;
    }

    private readonly Color activeColor, inactiveColor;

    public GameObject rank, repair, shop;

    public GameObject completeBuyWnd;

    public Image curImage;
    public Content[] spaceShipImage;

    private int newBuyShip;

    public Home_UI() {
        activeColor = new Color(1f, 1f, 1f, 1f);
        inactiveColor = new Color(1f, 1f, 1f, 0.55f);
    }

    private IEnumerator Start() {
        yield return new WaitUntil(() => UserManager.Player != null);

        curImage.sprite = spaceShipImage[UserManager.SelectSpaceShip].sprite;

        for (int i = 0; i < spaceShipImage.Length; i++) {
            if ((UserManager.Player.CarList & (1 << i)) != 0) {
                spaceShipImage[i].repair.color = activeColor;
                spaceShipImage[i].shop.color = inactiveColor;
            }

            else {
                spaceShipImage[i].repair.color = inactiveColor;
                spaceShipImage[i].shop.color = activeColor;
            }
        }
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

    public void Select(int selectShip) {
        if (UserManager.SelectNewSpaceShip(selectShip))
            curImage.sprite = spaceShipImage[selectShip].sprite;
    }

    public void Buy(int buyShip) {
        newBuyShip = buyShip;

        UserManager.Player.BuySpaceShip(1 << buyShip, CompleteBuy);
    }

    private void CompleteBuy(UserSpaceship[] updateShip) {
        completeBuyWnd.SetActive(true);

        spaceShipImage[newBuyShip].repair.color = activeColor;
        spaceShipImage[newBuyShip].shop.color = inactiveColor;
    }
}
