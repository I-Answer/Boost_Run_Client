using UnityEngine;

public class SoundManager : MonoBehaviour {

    private static SoundManager instance;
    private new AudioSource audio;

    public void Awake() {
        if (instance != null) return;

        DontDestroyOnLoad(gameObject);
        instance = this;

        audio = GetComponent<AudioSource>();
    }

    public static void PlaySound(AudioClip playAudio) {
        instance.audio.PlayOneShot(playAudio);
    }

    public static float Volume {
        get { return instance.audio.volume; }
        set { instance.audio.volume = value; }
    }
}
