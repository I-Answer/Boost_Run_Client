using System.Collections.Generic;
using UnityEngine;

internal static class CoroutineStorage {

	class FloatComparer : IEqualityComparer<float> {
        bool IEqualityComparer<float>.Equals(float x, float y) {
            return Mathf.Approximately(x, y);
        }

        int IEqualityComparer<float>.GetHashCode(float obj) {
            return obj.GetHashCode();
        }
    }

    private static readonly WaitForEndOfFrame waitForEndOfFrame
        = new WaitForEndOfFrame();

    public static WaitForEndOfFrame WaitForEndOfFrame() {
        return waitForEndOfFrame;
    }


    private static readonly WaitForFixedUpdate waitForFixedUpdate
        = new WaitForFixedUpdate();

    public static WaitForFixedUpdate WaitForFixedUpdate() {
        return waitForFixedUpdate;
    }

    private static readonly Dictionary<float, WaitForSeconds> waitForSeconds
        = new Dictionary<float, WaitForSeconds>(new FloatComparer());

    private static WaitForSeconds waitSec;

    public static WaitForSeconds WaitForSeconds(float sec) {
        if (!waitForSeconds.TryGetValue(sec, out waitSec))
            waitForSeconds.Add(sec, waitSec = new WaitForSeconds(sec));

        return waitSec;
    }
}
