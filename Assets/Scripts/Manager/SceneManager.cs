using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

    private const float maxFill = 1f;

    private const string loadingString = "LoadingScene";

    private static string targetSceneName;
    private static string nowSceneName;

    public Image loadingBar;

    private IEnumerator Start() {
        AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(targetSceneName);
        yield return null;

        while (true) {
            op.allowSceneActivation = false;

            yield return StartCoroutine(RotateBar());

            op.allowSceneActivation = true;

            if (op.progress >= 0.9f) nowSceneName = targetSceneName;
            
            yield return null;
        }
    }

    private IEnumerator RotateBar() {
        loadingBar.fillAmount = 0f;

        while (maxFill - loadingBar.fillAmount > 0.01f) {
            loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, maxFill, Time.deltaTime * 2f);
            yield return null;
        }

        loadingBar.fillAmount = maxFill;
    }

    public static void SceneLoad(string sceneName) {
        targetSceneName = sceneName;
        nowSceneName = loadingString;

        UnityEngine.SceneManagement.SceneManager.LoadScene(loadingString);
    }

    public static string SceneName {
        get { return nowSceneName; }
    }
}
