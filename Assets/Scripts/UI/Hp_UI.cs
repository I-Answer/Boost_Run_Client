using UnityEngine;
using UnityEngine.UI;

public class Hp_UI : MonoBehaviour {

    public Image hpBar, shiledBar;
    
    public void SetHp(float hp) {
        if (hp > 1f) {
            hpBar.fillAmount = 1f;
            shiledBar.fillAmount = hp - 1f;
        }

        else {
            hpBar.fillAmount = hp;
            shiledBar.fillAmount = 0f;
        }
    }
}
