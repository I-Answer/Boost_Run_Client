using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank_UI : MonoBehaviour {

    // 새로운 랭크 추가 시 ModeCount 앞에 추가
    private enum RankMode {
        Speed, Time, ModeCount
    }

    public class RecordList<T> : List<T> {
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
    public Notice_UI notConnected;

    private List<Record_UI> records;

    private List<RecordList<Rank>> ranksBuffer;
    private RankMode nowRank;

    private void Awake() {
        ranksBuffer = new List<RecordList<Rank>>((int)RankMode.ModeCount);

        for (int i = 0; i < ranksBuffer.Capacity; i++)
            ranksBuffer.Add(new RecordList<Rank>());

        records = new List<Record_UI>(content.GetComponentsInChildren<Record_UI>());
    }

    private void OnEnable() {
        if (!NetworkManager.IsConnected) {
            notConnected.Enable();
            gameObject.SetActive(false);
            return;
        }

        for (int i = 0; i < ranksBuffer.Capacity; i++)
            ranksBuffer[i].Clear();

        PresentRank((int)RankMode.Speed);
    }

    public void PresentRank(int mode) {
        nowRank = (RankMode)mode;

        EnableBody(false);
        guideText.text = speedGuide;

        if (!ranksBuffer[mode].IsVaild)
            ServerConnector.GET<Rank>(GetRank, ServerApi.SpeedRank);

        else ShowRank();
    }

    private void GetRank(Rank[] ranks) {
        ranksBuffer[(int)nowRank].Init(ranks);
        ShowRank();
    }

    private void ShowRank() {
        int i = 0;

        InitContent();

        foreach (var record in records) {
            if (i >= ranksBuffer[(int)nowRank].Count) break;
            
            record.SetSpeedText(ranksBuffer[(int)nowRank][i], ++i);
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
