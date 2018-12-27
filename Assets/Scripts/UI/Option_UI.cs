using UnityEngine;

public class Option_UI : MonoBehaviour {

    [System.Serializable]
    public struct AudioButton {
        public GameObject on, off;
    }

    public GameObject optionWnd;
    public AudioButton effect, background;
    public AudioClip clickSound;

    private void Awake() {
        UpdateUi();
    }

    public void UpdateUi() {
        SetEffectSoundButton(!SoundManager.EffectSound);
        SetBackgroundSoundButton(!SoundManager.BackgroundSound);
    }

    public void OpenOption() {
        SoundManager.PlaySound(clickSound);

        if (SceneManager.NowScene == SceneState.STAGE)
            Time.timeScale = 0f;

        SoundManager.PlaySound(clickSound);
        optionWnd.SetActive(true);
    }

    public void CloseOption() {
        if (SceneManager.NowScene == SceneState.STAGE)
            Time.timeScale = 1f;

        optionWnd.SetActive(false);
    }

    public void EffectSoundChange() {
        SoundManager.PlaySound(clickSound);

        if (SoundManager.EffectSound) {
            SetEffectSoundButton(true);
            SoundManager.EffectSound = false;
        }

        else {
            SetEffectSoundButton(false);
            SoundManager.EffectSound = true;
        }
    }

    public void BackgroundSoundChange() {
        SoundManager.PlaySound(clickSound);

        if (SoundManager.BackgroundSound) {
            SetBackgroundSoundButton(true);
            SoundManager.BackgroundSound = false;
        }

        else {
            SetBackgroundSoundButton(false);
            SoundManager.BackgroundSound = true;
        }
    }

    private void SetEffectSoundButton(bool isOn) {
        effect.on.SetActive(isOn);
        effect.off.SetActive(!isOn);
    }

    private void SetBackgroundSoundButton(bool isOn) {
        background.on.SetActive(isOn);
        background.off.SetActive(!isOn);
    }
}
