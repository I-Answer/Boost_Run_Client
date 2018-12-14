using UnityEngine;
using UnityEngine.UI;

public class GameOver_UI : MonoBehaviour {

    private string[] eventString = new string[] { "", "Highest speed!!", "Highest time!!", "Highest speed, time!!" };

    public GameObject record, loading;
    public Text maxSpeedText, endureTimeText, eventText;

    public AudioClip eventSound;

    private static GameOver_UI instance;

    public static GameOver_UI Instance {
        get { return instance; }
    }

    private void Awake() {
        instance = this;
        gameObject.SetActive(false);
    }

    public void Active() {
        RecordActive(false);
    }

    public void Active(int maxSpeed, int endureTime, byte maxEvent) {
        maxSpeedText.text = string.Format("{0}", maxSpeed);
        endureTimeText.text = string.Format("{0} : {1}", endureTime / 60, endureTime % 60);
        eventText.text = eventString[maxEvent];

        if (maxEvent != 0)
            SoundManager.PlaySound(eventSound);

        RecordActive(true);
    }

    public void LoadHome() {
        // TODO: 서버에 점수 보내는 행동

        Time.timeScale = 1f;
        SceneManager.SceneLoad("HomeScene");
    }

    private void RecordActive(bool bOn) {
        record.SetActive(bOn);
        loading.SetActive(!bOn);

        if (!gameObject.activeInHierarchy)
            gameObject.SetActive(true);
    }
}