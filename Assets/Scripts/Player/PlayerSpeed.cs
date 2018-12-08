using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSpeed : MonoBehaviour {

    private uint speed;

    public uint startSpeed, increaseSpeed, decreaseSpeed;
    public float increaseTime;

    // increaseTime마다 increaseSpeed만큼 속도 증가
    private IEnumerator Start() {
        ChangeSpeed(startSpeed);

        while (true) {
            yield return CoroutineStorage.WaitForSeconds(increaseTime);

            ChangeSpeed(speed + increaseSpeed);
        }
    }

    // 장애물 맞으면 속도 감소
    public void DecreaseSpeed() {
        ChangeSpeed(speed - GetCollisionSpeed());
    }

    private uint GetCollisionSpeed() {
        uint result = (speed >> 3) + decreaseSpeed;

        return result;
    }

    private SpeedEvent ChangeSpeedEvent;

    private void ChangeSpeed(uint speed) {
        if (speed < 0) speed = 0;

        if (this.speed != speed)
            this.speed = speed;

        ChangeSpeedEvent.Invoke(this.speed);
    }

    public UnityAction<uint> SpeedEvent {
        set {
            if (ChangeSpeedEvent == null)
                ChangeSpeedEvent = new SpeedEvent();

            ChangeSpeedEvent.AddListener(value);
        }
    }
}
