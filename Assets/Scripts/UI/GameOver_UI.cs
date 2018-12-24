using UnityEngine;
using UnityEngine.UI;

public class GameOver_UI : MonoBehaviour {

    private string[] eventString = new string[] { "", "Highest speed!!", "Highest time!!", "Highest speed, time!!" };

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

    public void Active(int maxSpeed, int endureTime, byte maxEvent) {
        maxSpeedText.text = string.Format("{0}", maxSpeed);
        endureTimeText.text = string.Format("{0} : {1}", endureTime / 60, endureTime % 60);
        eventText.text = eventString[maxEvent];

        if (maxEvent != 0)
            SoundManager.PlaySound(eventSound);

        gameObject.SetActive(true);
    }

    public void LoadHome() {
        Time.timeScale = 1f;
        SceneManager.SceneLoad("HomeScene");
    }
}