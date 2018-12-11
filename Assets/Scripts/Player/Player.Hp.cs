using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public partial class Player : MonoBehaviour {

    private const float decreaseBaseSpeed = 1800f;

    private float hp;
    public float decreaseHp, decreaseTime;

    private bool bAlive;

    private IEnumerator UpdateHp() {
        WaitUntil waitBelowDecreaseBaseSpeed = new WaitUntil(() => speed < decreaseBaseSpeed);

        while (bAlive) {
            yield return waitBelowDecreaseBaseSpeed;
            yield return CoroutineStorage.WaitForSeconds(decreaseTime);

            ChangeHp(hp - decreaseHp);
        }

        GameManager.InGame.GameOver();
    }

    public void IncreaseSpeed(float increaseHp) {
        ChangeHp(hp + increaseHp);
    }

    public void ChangeHp(float newHp) {
        if (newHp <= 0f) {
            bAlive = false;
            newHp = 0f;
        }

        hp = newHp;
        hpUi.SetHp(hp);
    }

    public float Hp {
        get { return hp; }
    }
}
