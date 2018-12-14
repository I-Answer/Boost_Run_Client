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

    public static void PlaySound(AudioClip playAudio) {
        instance.effectAudio.PlayOneShot(playAudio);
    }

    public static bool EffectSound {
        get { return instance.effectAudio.mute; }
        set { instance.effectAudio.mute = value; }
    }

    public static bool BackgroundSound {
        get { return instance.backgroundAudio.mute; }
        set { instance.backgroundAudio.mute = value; }
    }
}
