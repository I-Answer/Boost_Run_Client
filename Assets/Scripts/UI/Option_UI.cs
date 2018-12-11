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
        if (SoundManager.Volume.Equals(0f))
            SoundManager.Volume = 1f;

        else SoundManager.Volume = 0f;
    }
}
