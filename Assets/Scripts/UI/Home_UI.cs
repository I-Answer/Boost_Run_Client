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

    public Notice_UI completeBuy;

    public Image curImage;
    public Content[] spaceShipImage;

    public AudioClip clickSound;

    private int newBuyShip;

    public Home_UI() {
        activeColor = new Color(1f, 1f, 1f, 1f);
        inactiveColor = new Color(1f, 1f, 1f, 0.55f);
    }

    private IEnumerator Start() {
        yield return new WaitUntil(() => UserManager.Instance.Player != null);

        curImage.sprite = spaceShipImage[UserManager.Instance.SelectSpaceShip].sprite;

        for (int i = 0; i < spaceShipImage.Length; i++) {
            if ((UserManager.Instance.Player.CarList & (1 << i)) != 0) {
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
        SoundManager.PlaySound(clickSound);
        SceneManager.SceneLoad("StageScene");
    }

    public void OpenRank() {
        SoundManager.PlaySound(clickSound);
        rank.SetActive(true);
    }

    public void CloseRank() {
        rank.SetActive(false);
    }

    public void OpenRepair() {
        SoundManager.PlaySound(clickSound);
        repair.SetActive(true);
    }

    public void CloseRepair() {
        repair.SetActive(false);
    }

    public void OpenShop() {
        SoundManager.PlaySound(clickSound);
        shop.SetActive(true);
    }

    public void CloseShop() {
        shop.SetActive(false);
    }

    public void Select(int selectShip) {
        if (UserManager.Instance.SelectNewSpaceShip(selectShip))
            curImage.sprite = spaceShipImage[selectShip].sprite;
    }

    public void Buy(int buyShip) {
        newBuyShip = buyShip;

        UserManager.Instance.Player.BuySpaceShip(1 << buyShip, CompleteBuy);
    }

    private void CompleteBuy(UserSpaceship[] updateShip) {
        completeBuy.Enable();

        spaceShipImage[newBuyShip].repair.color = activeColor;
        spaceShipImage[newBuyShip].shop.color = inactiveColor;
    }
}
