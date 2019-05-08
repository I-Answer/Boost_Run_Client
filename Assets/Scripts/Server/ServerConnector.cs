using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public struct ServerApi {
    public const string SpeedRank = "http://18.216.130.185:5000/record/rank/speed";
    public const string timeRank = "http://18.216.130.185:5000/record/rank/time";
    public const string GetUser = "http://18.216.130.185:5000/auth/user/";
    public const string PostUser = "http://18.216.130.185:5000/auth/user";
    public const string Bitflag = "http://18.216.130.185:5000/bitflag";
    public const string UserRecord = "http://18.216.130.185:5000/record/";
    public const string AddRecord = "http://18.216.130.185:5000/record";
}

public class ServerConnector : MonoBehaviour {

    private static ServerConnector instance;

    private static ServerConnector Instance {
        get {
            if (instance == null) {
                ServerConnector self = FindObjectOfType<ServerConnector>();

                DontDestroyOnLoad(self.gameObject);
                instance = self;
            }

            return instance;
        }
    }

    public List<IMultipartFormSection> FormData { get; set; }

    private void Awake() {
        FormData = new List<IMultipartFormSection>();
    }

    public static void GET<T>(Action<T[]> onFinish, string url) {
        Instance.StartCoroutine(Instance.GetImpl(onFinish, url));
    }

    public static void POST<T>(Action<T[]> onFinish, string url, params IMultipartFormSection[] datas) {
        Instance.FormData.Clear();

        foreach (var data in datas)
            Instance.FormData.Add(data);

        Instance.StartCoroutine(Instance.POSTImpl(onFinish, url));
    }

    private IEnumerator GetImpl<T>(Action<T[]> onFinish, string url) {
        using (var www = UnityWebRequest.Get(url)) {
            yield return www.SendWebRequest();

            InvokeCallback(onFinish, www);
        }
    }

    private IEnumerator POSTImpl<T>(Action<T[]> onFinish, string url) {
        using (var www = UnityWebRequest.Post(url, FormData)) {
            yield return www.SendWebRequest();

            InvokeCallback(onFinish, www);
        }
    }

    private void InvokeCallback<T>(Action<T[]> onFinish, UnityWebRequest www) {
        if (!www.isNetworkError && !www.isHttpError) {
            Debug.Log(www.downloadHandler.text);
            var parsedResult = JsonParser.FromJson<T>(www.downloadHandler.text);

            if (onFinish != null)
                onFinish(parsedResult);
        }

#if UNITY_EDITOR
        else {
            Debug.Log(www.error);
        }
#endif
    }
}