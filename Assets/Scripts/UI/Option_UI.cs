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
<<<<<<< HEAD
        GameManager.SoundManager sound = GameManager.Sound;
        if (sound.Volume.Equals(0f))
            sound.Volume = 1f;

        else sound.Volume = 0f;
=======
        if (SoundManager.Volume.Equals(0f))
            SoundManager.Volume = 1f;

        else SoundManager.Volume = 0f;
>>>>>>> 37f382c92ad6a786a83707d84775c06824a5072b
    }
}
