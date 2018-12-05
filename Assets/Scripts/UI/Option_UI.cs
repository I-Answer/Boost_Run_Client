using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_UI : MonoBehaviour {

    public GameObject optionWnd;

	public void Active() {
        Time.timeScale = 0f;
        optionWnd.SetActive(true);
    }

    public void Inactive() {
        Time.timeScale = 1f;
        optionWnd.SetActive(false);
    }

    public void SoundChange() {
        GameManager.SoundManager sound = GameManager.Sound;

        if (sound.Volume.Equals(0f))
            sound.Volume = 1f;

        else sound.Volume = 0f;
    }
}
