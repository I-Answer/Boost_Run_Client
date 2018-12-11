using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public partial class Player : MonoBehaviour {

    private int speed = 0;

    public int startSpeed, increaseSpeed, decreaseSpeed;
    public float increaseTime;

    private int increaseScale = 1;

    // increaseTime마다 increaseSpeed만큼 속도 증가
    private IEnumerator UpdateSpeed() {
        ChangeSpeed(startSpeed);

        while (true) {
            yield return CoroutineStorage.WaitForSeconds(increaseTime);

            ChangeSpeed(speed + (increaseSpeed * increaseScale));
        }
    }

    private int GetCollisionSpeed() {
        return (speed >> 2) + decreaseSpeed;
    }

    #region SpeedEvent

    private SpeedEvent ChangeSpeedEvent;

    public void ChangeSpeed(int speed) {
        if (speed < 0) speed = 0;

        if (this.speed == speed) return;

        this.speed = speed;
        ChangeSpeedEvent.Invoke(this.speed);
    }

    public UnityAction<int> SpeedEvent {
        set {
            if (ChangeSpeedEvent == null)
                ChangeSpeedEvent = new SpeedEvent();

            ChangeSpeedEvent.AddListener(value);
        }
    }

    #endregion

    protected int Speed {
        get { return speed; }
    }

    public int IncreaseScale {
        get { return increaseScale; }
        set { increaseScale = value; }
    }
}
