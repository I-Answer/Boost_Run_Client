using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_UI : MonoBehaviour {

    public GameObject optionWnd;

    public GameObject soundOn, soundOff;

	public void OpenOption() {
        if (SceneManager.NowScene == SceneState.STAGE)
            Time.timeScale = 0f;

        optionWnd.SetActive(true);
    }

    public void CloseOption() {
        if (SceneManager.NowScene == SceneState.STAGE)
            Time.timeScale = 1f;

        optionWnd.SetActive(false);
    }

    public void SoundChange() {
        if (SoundManager.Volume.Equals(0f)) {
            SetSoundButton(true);
            SoundManager.Volume = 1f;
        }

        else {
            SetSoundButton(false);
            SoundManager.Volume = 0f;
        }
    }

    private void SetSoundButton(bool bOn) {
        soundOn.SetActive(bOn);
        soundOff.SetActive(!bOn);
    }
}
