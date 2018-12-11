using System.Collections;
using UnityEngine;

public partial class Player : MonoBehaviour {

    private int speed;

    public int startSpeed, increaseSpeed, decreaseSpeed;
    public float increaseTime;

    private int increaseScale = 1;

    // increaseTime마다 increaseSpeed만큼 속도 증가
    private IEnumerator UpdateSpeed() {
        Speed = startSpeed;

        while (true) {
            yield return CoroutineStorage.WaitForSeconds(increaseTime);
            Speed += increaseSpeed * increaseScale;
        }
    }

    private int GetCollisionSpeed() {
        return (Speed >> 2) + decreaseSpeed;
    }

    public int Speed {
        get { return speed; }
        set {
            if (value < 0) value = 0;

            speed = value;
            speedUi.UpdateUi(speed);
        }
    }

    public int IncreaseScale {
        get { return increaseScale; }
        set { increaseScale = value; }
    }
}
