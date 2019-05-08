using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

    private static SoundManager instance;
    private AudioSource effectAudio, backgroundAudio;

    public AudioClip homeBackgroundAudio, stageBackgroundAudio;

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

    private void ChangeBackgroundSound(Scene scene, LoadSceneMode sceneMode) {
        switch ((SceneState)scene.buildIndex) {
            case SceneState.HOME:
                backgroundAudio.clip = homeBackgroundAudio;
                break;

            case SceneState.STAGE:
                backgroundAudio.clip = stageBackgroundAudio;
                break;

            case SceneState.LOADING:
                backgroundAudio.Stop();
                return;
        }

        backgroundAudio.Play();
    }

    public static void Init(string name) {
        instance.InitImpl(name);
    }

    private void InitImpl(string name) {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += ChangeBackgroundSound;

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
            PlayerPrefs.SetString(string.Format("{0} Effect Sound", UserManager.Player.Name), value.ToString());
        }
    }

    public static bool BackgroundSound {
        get { return instance.backgroundAudio.mute; }
        set {
            instance.backgroundAudio.mute = value;
            PlayerPrefs.SetString(string.Format("{0} Background Sound", UserManager.Player.Name), value.ToString());
        }
    }
}
