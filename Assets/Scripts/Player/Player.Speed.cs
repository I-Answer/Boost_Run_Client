using System.Collections;
using UnityEngine;

public partial class Player : MonoBehaviour {

    private int speed;

    private const int increaseSpeed = 150, decreaseSpeed = 50;
    private const float increaseTime = 1f;

    public AudioClip warningSound;

    private int increaseScale = 1;

    // increaseTime마다 increaseSpeed만큼 속도 증가
    private IEnumerator UpdateSpeed() {
        Speed = DecreaseBaseSpeed;
        StartCoroutine(WarningCheck());

        while (true) {
            yield return CoroutineStorage.WaitForSeconds(increaseTime);
            Speed += increaseSpeed * increaseScale;
        }
    }

    private IEnumerator WarningCheck() {
        WaitUntil waitBelowWarningBase = new WaitUntil(() => speed < DecreaseBaseSpeed);

        while (true) {
            yield return waitBelowWarningBase;

            SoundManager.PlaySound(warningSound);
            yield return CoroutineStorage.WaitForSeconds(1f);
        }
    }

    private int GetCollisionSpeed() {
        return (Speed / 5) + decreaseSpeed;
    }

    public int Speed {
        get { return speed; }
        set {
            if (value < 0) value = 0;

            speed = value;

            manager.UpdateMaxSpeed(speed);
            speedUi.UpdateUi(speed);
        }
    }

    public int IncreaseScale {
        get { return increaseScale; }
        set { increaseScale = value; }
    }
}
