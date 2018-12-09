using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour {

    private const float invincibleTime = 1f;

    private Image hpBar, shieldBar;

    private float hp;
    public float decreaseHp, decreaseTime;

    private uint mySpeed;
    private bool bAlive;

    private void Awake() {
        GetComponent<PlayerSpeed>().SpeedEvent = (speed) => mySpeed = speed;
        hpBar = GameObject.FindWithTag("Hp Bar").GetComponent<Image>();
        shieldBar = GameObject.FindWithTag("Shield Bar").GetComponent<Image>();

        hp = 1f;
        bAlive = true;
    }

    private IEnumerator Start() {
        WaitUntil waitBelow1800 = new WaitUntil(() => mySpeed < 1800f);

        yield return CoroutineStorage.WaitForSeconds(invincibleTime);

        while (bAlive) {
            yield return waitBelow1800;

            yield return CoroutineStorage.WaitForSeconds(decreaseTime);

            ChangeHp(hp - decreaseHp);
        }

        GameManager.GameSet();
    }

    public void IncreaseSpeed(float increaseHp) {
        ChangeHp(hp + increaseHp);
    }

    public void ChangeHp(float newHp) {
        if (newHp <= 0f) {
            bAlive = false;
            newHp = 0;
        }

        hp = newHp;

        if (newHp > 1f) {
            hpBar.fillAmount = 1;
            shieldBar.fillAmount = hp - 1f;
        }

        else hpBar.fillAmount = hp;
    }

    public float Hp {
        get { return hp; }
    }
}
