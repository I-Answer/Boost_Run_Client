using System.Collections;
using UnityEngine;

public class BuyComplete_UI : MonoBehaviour {

    private const float waitTime = 4f;

    private void OnEnable() {
        StartCoroutine(WaitAndDisappear());
    }

    private IEnumerator WaitAndDisappear() {
        yield return CoroutineStorage.WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
}
