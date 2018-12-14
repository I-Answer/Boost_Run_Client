using System;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private static SoundManager instance;
    private AudioSource effectAudio, backgroundAudio;

    public void Awake() {
        if (instance != null) return;

        DontDestroyOnLoad(gameObject);
        instance = this;

        AudioSource[] audios = GetComponents<AudioSource>();

        foreach (var audio in audios) {
            if (audio.loop) backgroundAudio = audio;
            else effectAudio = audio;
        }
    }

    public static void Init(string name) {
        instance.InitImpl(name);
    }

    private void InitImpl(string name) {
        effectAudio.mute = Convert.ToBoolean(PlayerPrefs.GetString(string.Format("{0} Effect Sound", name), "false"));
        backgroundAudio.mute = Convert.ToBoolean(PlayerPrefs.GetString(string.Format("{0} Background Sound", name), "false"));

        var optionUi = FindObjectOfType<Option_UI>();

        optionUi.UpdateUi();

        backgroundAudio.Play();
    }

    public static void PlaySound(AudioClip playAudio) {
        instance.effectAudio.PlayOneShot(playAudio);
    }

    public static bool EffectSound {
        get { return instance.effectAudio.mute; }
        set {
            instance.effectAudio.mute = value;
            PlayerPrefs.SetString(string.Format("{0} Effect Sound", UserManager.Instance.Player.Name), value.ToString());
        }
    }

    public static bool BackgroundSound {
        get { return instance.backgroundAudio.mute; }
        set {
            instance.backgroundAudio.mute = value;
            PlayerPrefs.SetString(string.Format("{0} Background Sound", UserManager.Instance.Player.Name), value.ToString());
        }
    }
}
