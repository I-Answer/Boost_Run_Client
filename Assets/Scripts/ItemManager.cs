using System.Collections;

public class ItemManager : RandomPooler {

	private IEnumerator Start() {
        while (true) {
            yield return CoroutineManager.WaitForSeconds(GetWaitTime());

            Request();
        }
    }
}
