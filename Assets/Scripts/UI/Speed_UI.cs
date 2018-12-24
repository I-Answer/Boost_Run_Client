using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed_UI : MonoBehaviour, IPlayerUi<int> {

    private Text speedText;

    private Dictionary<int, string> speedMap;
    private Coroutine runningCoroutine = null;

    private string speedString;
    private int nowSpeed;

    private void Awake() {
        speedText = GetComponent<Text>();

        speedMap = new Dictionary<int, string>();

        for (int i = 0; i < 3000; i++)
            speedMap.Add(i, string.Format("{0} km/h", i));
    }

    // 현재 변경 중일 경우 변경을 중단하고 새로운 값으로 변경
    public void UpdateUi(int newSpeed) {
        SetTextColor(newSpeed);

        if (runningCoroutine != null)
            StopCoroutine(runningCoroutine);

        runningCoroutine = StartCoroutine(ChangeText(newSpeed));
    }

    private IEnumerator ChangeText(int newSpeed) {
        while (Mathf.Abs(nowSpeed - newSpeed) >= 3) {
            nowSpeed = Mathf.CeilToInt(Mathf.Lerp(nowSpeed, newSpeed, Time.deltaTime * 15f));

            SetText(nowSpeed);
            yield return null;
        }

        SetText(newSpeed);
    }

    private void SetTextColor(int speed) {
        if (speed < Player.DecreaseBaseSpeed && speedText.color != Color.red)
            speedText.color = Color.red;

        else if (speedText.color != Color.white)
            speedText.color = Color.white;
    }

    // string 임시 객체 생성을 방지하기 위해 Dictionary에 string을 저장 후 사용
    private void SetText(int newSpeed) {
        if (!speedMap.TryGetValue(newSpeed, out speedString))
            speedMap.Add(newSpeed, speedString = string.Format("{0} km/h", newSpeed));

        speedText.text = speedString;
    }
}
