using UnityEngine;
using UnityEngine.UI;

public class Record_UI : MonoBehaviour {

    public Text ranking, nick, record;

	public void SetSpeedText(Rank speedRecord, int rank) {
        SetDefault(rank, speedRecord.name);

        record.text = speedRecord.score.ToString();
    }

    public void SetTimeText(Rank timeRecord, int rank) {
        SetDefault(rank, timeRecord.name);

        record.text = string.Format("{0} : {1}", timeRecord.score / 60, timeRecord.score % 60);
    }

    private void SetDefault(int rank, string name) {
        ranking.text = rank.ToString();
        nick.text = name;
    }
}
