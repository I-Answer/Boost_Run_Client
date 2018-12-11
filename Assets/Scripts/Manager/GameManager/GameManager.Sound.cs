using UnityEngine;

public partial class GameManager : MonoBehaviour {

    public class SoundManager {

        private AudioSource audio;

        public SoundManager(AudioSource audio) {
            this.audio = audio;
        }

        public void PlaySound(AudioClip playAudio) {
            audio.PlayOneShot(playAudio);
        }

        public float Volume {
            get { return audio.volume; }
            set { audio.volume = value; }
        }
    }
}
