using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipGuide_UI : MonoBehaviour {

    private readonly string[] spaceShipName = new string[] {
        "Red", "Pink", "Yellow", "Green", "Sky", "Purple"
    };

    private readonly string[] guideMap = new string[]{
        "스킬을 사용하면 체력을 회복합니다",
        "속도에 따라서 속도를 대가로 체력을 회복하거나,\n체력을 대가로 속도를 높입니다",
        "급격히 속도가 높아지고 잠시 후 줄어듭니다",
        "일정 시간 동안 무적 상태가 됩니다",
        "중첩 가능한 1회용 보호막을 생성합니다",
        "충돌하기 전까지 속도가 급격하게 오릅니다"
    };

    public GameObject guide;
    public Text head, body;

    public Image shopCloseButton;

    public void ShowGuide(int spaceShip) {
        head.text = spaceShipName[spaceShip];
        body.text = guideMap[spaceShip];

        shopCloseButton.raycastTarget = false;
        guide.SetActive(true);
    }

    public void HideGuide() {
        shopCloseButton.raycastTarget = true;
        guide.SetActive(false);
    }
}
