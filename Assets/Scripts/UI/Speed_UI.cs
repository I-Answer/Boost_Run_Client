using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed_UI : MonoBehaviour {

    private Text speedText;

    private Coroutine runningCoroutine = null;

    private Dictionary<uint, string> speedMap;

    private string speedString;
    private uint nowSpeed;

    private void Awake() {
        GameObject.FindWithTag("Player").GetComponent<PlayerSpeed>().SpeedEvent = Change;

        speedText = GetComponent<Text>();

        speedMap = new Dictionary<uint, string>();

        for (uint i = 0; i < 3000; i++)
            speedMap.Add(i, string.Format("{0} km/h", i));
    }

    // 현재 변경 중일 경우 변경을 중단하고 새로운 값으로 변경
    private void Change(uint newSpeed) {
        SetTextColor(newSpeed);

        if (runningCoroutine != null)
            StopCoroutine(runningCoroutine);

        runningCoroutine = StartCoroutine(ChangeText(newSpeed));
    }

    private IEnumerator ChangeText(uint newSpeed) {
        while (Mathf.Abs(nowSpeed - newSpeed) >= 3) {
            nowSpeed = (uint)Mathf.CeilToInt(Mathf.Lerp(nowSpeed, newSpeed, Time.deltaTime * 15f));

            SetText(nowSpeed);
            yield return null;
        }

        SetText(newSpeed);
    }

    private void SetTextColor(uint speed) {
        if (speed < 1800 && speedText.color != Color.red)
            speedText.color = Color.red;

        else if (speed >= 1800 && speedText.color != Color.white)
            speedText.color = Color.white;
    }

    // string 임시 객체 생성을 방지하기 위해 Dictionary에 string을 저장 후 사용
    private void SetText(uint newSpeed) {
        if (!speedMap.TryGetValue(newSpeed, out speedString))
            speedMap.Add(newSpeed, speedString = string.Format("{0} km/h", newSpeed));

        speedText.text = speedString;
    }
}
