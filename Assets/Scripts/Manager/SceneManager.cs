using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SceneState {
    HOME, LOADING, STAGE
}

public class SceneManager : MonoBehaviour {

    private const float maxFill = 1f;

    private const string homeSceneName = "HomeScene";
    private const string loadingSceneName = "LoadingScene";
    private const string stageSceneName = "StageScene";

    private static Dictionary<string, SceneState> sceneMap;

    private static string nextSceneName;
    private static SceneState nowScene;

    public Image panel, loadingBar;
    public Sprite homeImage, stageImage;
    public float adProbability;

    private void Awake() {
        switch (nextSceneName) {
            case homeSceneName:
                panel.sprite = homeImage;
                break;

            case stageSceneName:
                panel.sprite = stageImage;
                break;
        }

        if (sceneMap != null) return;

        sceneMap = new Dictionary<string, SceneState>();

        sceneMap.Add(homeSceneName, SceneState.HOME);
        sceneMap.Add(loadingSceneName, SceneState.LOADING);
        sceneMap.Add(stageSceneName, SceneState.STAGE);
    }

    private IEnumerator Start() {
        if (nextSceneName.Equals(homeSceneName))
            ServiceManager.ShowAd(ServiceManager.AdState.Video, adProbability);

        AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextSceneName);

        yield return null;

        System.GC.Collect();

        while (true) {
            op.allowSceneActivation = false;

            yield return StartCoroutine(FillBar());

            op.allowSceneActivation = true;

            if (op.progress >= 0.9f) nowScene = sceneMap[nextSceneName];
            
            yield return null;
        }
    }

    private IEnumerator FillBar() {
        loadingBar.fillAmount = 0f;

        while (maxFill - loadingBar.fillAmount > 0.01f) {
            loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, maxFill, Time.deltaTime * 2f);
            yield return null;
        }

        loadingBar.fillAmount = maxFill;
    }

    public static void SceneLoad(string sceneName) {
        nextSceneName = sceneName;
        nowScene = SceneState.LOADING;

        UnityEngine.SceneManagement.SceneManager.LoadScene(loadingSceneName);
    }

    public static SceneState NowScene {
        get { return nowScene; }
    }
}
