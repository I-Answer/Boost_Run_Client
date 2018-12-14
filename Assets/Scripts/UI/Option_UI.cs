using UnityEngine;

public class Option_UI : MonoBehaviour {

    [System.Serializable]
    public struct AudioButton {
        public GameObject on, off;
    }

    public GameObject optionWnd;

    public AudioButton effect, background;

    public AudioClip clickSound;

	public void OpenOption() {
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
        if (SoundManager.BackgroundSound) {
            SetBackgroundSoundButton(true);
            SoundManager.BackgroundSound = false;
        }

        else {
            SetBackgroundSoundButton(false);
            SoundManager.BackgroundSound = true;
        }
    }

    private void SetEffectSoundButton(bool bOn) {
        effect.on.SetActive(bOn);
        effect.off.SetActive(!bOn);
    }

    private void SetBackgroundSoundButton(bool bOn) {
        background.on.SetActive(bOn);
        background.off.SetActive(!bOn);
    }
}
