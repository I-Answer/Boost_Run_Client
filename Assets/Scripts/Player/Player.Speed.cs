using System.Collections;
using UnityEngine;

public partial class Player : MonoBehaviour {

    const int warningBase = 1800;

    private int speed;

    public int startSpeed, increaseSpeed, decreaseSpeed;
    public float increaseTime;

    public AudioClip warningSound;

    private int increaseScale = 1;

    // increaseTime마다 increaseSpeed만큼 속도 증가
    private IEnumerator UpdateSpeed() {
        Speed = startSpeed;
        StartCoroutine(WarningCheck());

        while (true) {
            yield return CoroutineStorage.WaitForSeconds(increaseTime);
            Speed += increaseSpeed * increaseScale;
        }
    }

    private IEnumerator WarningCheck() {
        WaitUntil waitBelowWarningBase = new WaitUntil(() => speed < warningBase);

        while (true) {
            yield return waitBelowWarningBase;

            SoundManager.PlaySound(warningSound);
            yield return CoroutineStorage.WaitForSeconds(2f);
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
