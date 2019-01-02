using System.Collections;
using UnityEngine;

public class Notice_UI : MonoBehaviour {

    private const float waitTime = 1f;
    private Coroutine runningCoroutine;

    public void Enable() {
        if (runningCoroutine != null)
            StopCoroutine(runningCoroutine);

        else gameObject.SetActive(true);

        runningCoroutine = StartCoroutine(WaitAndDisappear());
    }

    private IEnumerator WaitAndDisappear() {
        yield return CoroutineStorage.WaitForSeconds(waitTime);
        gameObject.SetActive(false);
        runningCoroutine = null;
    }
}
