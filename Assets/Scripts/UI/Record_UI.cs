using UnityEngine;
using UnityEngine.UI;

public class Record_UI : MonoBehaviour {

    public Text ranking, nick, record;

	public void SetText(UserSpeed speedRecord, int rank) {
        SetDefault(rank, speedRecord.nick);

        record.text = speedRecord.maxSpeed.ToString();
    }

    public void SetText(UserTime timeRecord, int rank) {
        SetDefault(rank, timeRecord.nick);

        record.text = string.Format("{0} : {1}", timeRecord.maxTime / 60, timeRecord.maxTime % 60);
    }

    private void SetDefault(int rank, string name) {
        ranking.text = rank.ToString();
        nick.text = name;
    }
}
