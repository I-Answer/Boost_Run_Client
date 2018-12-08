using UnityEngine;
using UnityEngine.SceneManagement;

[System.Flags]
public enum SpaceShipState : byte {
    Red = 1, Yellow = 2, Green = 4, Sky = 8, Pink = 16, Purple = 32
}

public class GameManager : MonoBehaviour {   

    private enum SceneState {
        Home, Loading, Stage
    }

    public class UserManager {
        private string name;
        private uint maxSpeed;
        private uint endureTime;
        private SpaceShipState spaceShipList;

        public UserManager(string name, uint maxSpeed, uint endureTime, SpaceShipState spaceShipList) {
            this.name = name;
            this.maxSpeed = maxSpeed;
            this.endureTime = endureTime;
            this.spaceShipList = spaceShipList;
        }

        public void BuySpaceShip(SpaceShipState buySpaceShip) {
            spaceShipList |= buySpaceShip;
        }

        public bool CompareMaxSpeed(uint nowSpeed) {
            if (nowSpeed > maxSpeed) {
                maxSpeed = nowSpeed;
                return true;
            }

            return false;
        }

        public bool ComapreEndureTime(uint nowEndureTime) {
            if (nowEndureTime > endureTime) {
                endureTime = nowEndureTime;
                return true;
            }

            return false;
        }

        public string Name {
            get { return name; }
        }

        public SpaceShipState CarList {
            get { return spaceShipList; }
        }
    }

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

    #region Manager

    private static GameManager instance;

    private UserManager userManager;
    public static UserManager User {
        get { return instance.userManager; }
    }

    private SoundManager soundManager;
    public static SoundManager Sound {
        get { return instance.soundManager; }
    }

    #endregion

    private float startTime;
    private uint maxSpeed;

    private void Awake() {
        if (instance != null) return;

        DontDestroyOnLoad(gameObject);
        instance = this;

        // userManager의 생성자 매개변수는 데이터베이스에서 읽어올 것
        userManager = new UserManager("tempName", 0, 0, SpaceShipState.Red);
        soundManager = new SoundManager(GetComponent<AudioSource>());

        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.buildIndex != (int)SceneState.Stage) return;

        GameObject.FindWithTag("Player").GetComponent<PlayerSpeed>().SpeedEvent = CompareSpeed;

        maxSpeed = 0;
        startTime = Time.time;
    }

    public static void GameSet() {
        instance.GameOver();
    }

    private void GameOver() {
        Time.timeScale = 0;

        uint endureTime = (uint)(Time.time - startTime);

        GameOver_UI.Instance.Active(maxSpeed, endureTime, CompareMaxScore(endureTime));
    }

    private byte CompareMaxScore(uint endureTime) {
        byte result = 0;

        if (userManager.CompareMaxSpeed(maxSpeed))
            result |= 0x1;

        if (userManager.ComapreEndureTime(endureTime))
            result |= 0x2;

        return result;
    }

    private void CompareSpeed(uint newSpeed) {
        if (newSpeed > maxSpeed)
            maxSpeed = newSpeed;
    }
}
