using UnityEngine;
using UnityEngine.SceneManagement;

[System.Flags]
public enum SpaceShipState : byte {
    Red = 1, Yellow = 2, Green = 4, Sky = 8, Pink = 16, Purple = 32
}

public partial class GameManager : MonoBehaviour {   

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

    private InGameManager inGameManager;
    public static InGameManager InGame {
        get { return instance.inGameManager; }
    }

    #endregion

    private enum SceneState {
        Home, Loading, Stage
    }

    private void Awake() {
        if (instance != null) return;

        DontDestroyOnLoad(gameObject);
        instance = this;

        // userManager의 생성자 매개변수는 데이터베이스에서 읽어올 것
        userManager = new UserManager("tempName", 0, 0, SpaceShipState.Red);
        soundManager = new SoundManager(GetComponent<AudioSource>());
        inGameManager = new InGameManager();

        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.buildIndex != (int)SceneState.Stage) return;

        inGameManager.Init();
    }
}
