using UnityEngine;

public static class NetworkManager {

    public static bool IsConnected { get; private set; }

    static NetworkManager() {
        IsConnected = Application.internetReachability != NetworkReachability.NotReachable;
        Debug.Log(IsConnected);
    }
}