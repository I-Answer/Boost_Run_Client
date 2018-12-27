using System.Collections;
using UnityEngine;

public partial class Player : MonoBehaviour {

    private float hp;
    public float decreaseHp, decreaseTime;

    private bool isAlive;

    private IEnumerator UpdateHp() {
        WaitUntil waitBelowDecreaseBaseSpeed = new WaitUntil(() => speed < DecreaseBaseSpeed);

        while (isAlive) {
            yield return waitBelowDecreaseBaseSpeed;
            yield return CoroutineStorage.WaitForSeconds(decreaseTime);

            if (speed < DecreaseBaseSpeed)
                Hp -= decreaseHp;
        }

        manager.GameOver();
    }

    public float Hp {
        get { return hp; }
        set {
            if (value <= 0f) {
                isAlive = false;
                value = 0f;
            }

            else if (value > 1f) value = 1f;

            hp = value;
            hpUi.UpdateUi(hp);
        }
    }
}
