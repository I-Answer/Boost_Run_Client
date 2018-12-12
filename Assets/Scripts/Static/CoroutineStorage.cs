using System.Collections.Generic;
using UnityEngine;

public static class CoroutineStorage {

	class FloatComparer : IEqualityComparer<float> {
        bool IEqualityComparer<float>.Equals(float lhs, float rhs) {
            return Mathf.Approximately(lhs, rhs);
        }

        int IEqualityComparer<float>.GetHashCode(float obj) {
            return obj.GetHashCode();
        }
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
