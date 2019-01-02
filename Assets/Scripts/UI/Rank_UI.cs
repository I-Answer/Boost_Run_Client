using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank_UI : MonoBehaviour {

    public class RecordBuffer<T> : List<T> {
        public bool IsVaild { get; private set; }

        public void Init(T[] collection) {
            AddRange(collection);
            IsVaild = true;
        }

        public new void Clear() {
            base.Clear();
            IsVaild = false;
        }
    }

    private const string speedGuide = "Speed", timeGuide = "Time";

    public GameObject body, loading;
    public Text guideText;

    public RectTransform content;

    private RecordBuffer<UserSpeed> speedBuffer;
    private RecordBuffer<UserTime> timeBuffer;

    private List<Record_UI> records;

    private void Awake() {
        speedBuffer = new RecordBuffer<UserSpeed>();
        timeBuffer = new RecordBuffer<UserTime>();

        records = new List<Record_UI>(content.GetComponentsInChildren<Record_UI>());
    }

    private void OnEnable() {
        if (!NetworkManager.IsConnected) {
            gameObject.SetActive(false);
            return;
        }

        speedBuffer.Clear();
        timeBuffer.Clear();

        PresentSpeedRank();
    }

    public void PresentSpeedRank() {
        EnableBody(false);
        guideText.text = speedGuide;

        if (!speedBuffer.IsVaild)
            ServerConnector.Instance.GET<UserSpeed>(ServerApi.SpeedRank, GetRank);

        else ShowSpeedRank();
    }

    public void PresentTimeRank() {
        EnableBody(false);
        guideText.text = timeGuide;

        if (!timeBuffer.IsVaild)
            ServerConnector.Instance.GET<UserTime>(ServerApi.timeRank, GetRank);

        else ShowTimeRank();
    }

    private void GetRank(UserSpeed[] speedRanks) {
        speedBuffer.Init(speedRanks);
        ShowSpeedRank();
    }

    private void GetRank(UserTime[] timeRanks) {
        timeBuffer.Init(timeRanks);
        ShowTimeRank();
    }

    private void ShowSpeedRank() {
        int i = 0;

        InitContent();

        foreach (var record in records) {
            if (i >= speedBuffer.Count) break;
            
            record.SetText(speedBuffer[i], ++i);
            record.gameObject.SetActive(true);
        }

        EnableBody(true);
    }

    private void ShowTimeRank() {
        int i = 0;

        InitContent();

        foreach (var record in records) {
            if (i >= timeBuffer.Count) break;

            record.SetText(timeBuffer[i], ++i);
            record.gameObject.SetActive(true);
        }

        EnableBody(true);
    }

    private void EnableBody(bool isOn) {
        body.SetActive(isOn);
        loading.SetActive(!isOn);
    }

    private void InitContent() {
        for (int i = 0; i < content.childCount; i++)
            content.GetChild(i).gameObject.SetActive(false);

        content.anchoredPosition = Vector2.zero;
    }
}
