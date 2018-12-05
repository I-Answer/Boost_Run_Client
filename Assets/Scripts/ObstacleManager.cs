using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : RandomPooler {

    private Vector3 beforePos, curPos;

    private IEnumerator Start() {
        while (true) {
            yield return CoroutineManager.WaitForSeconds(GetWaitTime());

            Request();
        }
    }

    protected override Vector3 GetRandomXPos() {
        do {
            curPos = base.GetRandomXPos();
        } while (curPos.Equals(beforePos));

        beforePos = curPos;

        return curPos;
    }
}
