using UnityEngine;
using UnityEngine.UI;

public class Rank_UI : MonoBehaviour {

    private const string speedGuide = "Speed", timeGuide = "Time";

    public GameObject body, loading;
    public Text guideText;

    public Transform content;

    private void OnEnable() {
        PresentSpeedRank();
    }

    public void PresentSpeedRank() {
        EnableBody(false);
        guideText.text = speedGuide;

        ServerConnector.Instance.GET<UserSpeed>(ServerApi.SpeedRank, ShowRank, ServerConnector.ThrowIfFailed);
    }

    public void PresentTimeRank() {
        EnableBody(false);
        guideText.text = timeGuide;

        ServerConnector.Instance.GET<UserTime>(ServerApi.timeRank, ShowRank, ServerConnector.ThrowIfFailed);
    }

    private void ShowRank(UserSpeed[] speedRanks) {
        for (int i = 0; i < speedRanks.Length; i++)
            content.GetChild(i).GetComponent<Record_UI>().SetText(speedRanks[i], i + 1);

        EnableBody(true);
    }

    private void ShowRank(UserTime[] timeRanks) {
        for (int i = 0; i < timeRanks.Length; i++)
            content.GetChild(i).GetComponent<Record_UI>().SetText(timeRanks[i], i + 1);

        EnableBody(true);
    }

    private void EnableBody(bool bOn) {
        body.SetActive(bOn);
        loading.SetActive(!bOn);
    }
}
