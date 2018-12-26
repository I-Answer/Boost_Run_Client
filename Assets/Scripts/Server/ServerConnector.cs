using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServerApi {
    public const string SpeedRank = "http://13.59.174.126:5000/record/rank/speed";
    public const string timeRank = "http://13.59.174.126:5000/record/rank/time";
    public const string GetUser = "http://13.59.174.126:5000/auth/user/";
    public const string PostUser = "http://13.59.174.126:5000/auth/user";
    public const string Bitflag = "http://13.59.174.126:5000/bitflag";
    public const string UserRecord = "http://13.59.174.126:5000/record/";
    public const string AddRecord = "http://13.59.174.126:5000/record";
}

public class ServerConnector : MonoBehaviour {

    private static ServerConnector instance = null;

    public static ServerConnector Instance {
        get {
            if (instance == null) {
                ServerConnector self = FindObjectOfType<ServerConnector>();

                DontDestroyOnLoad(self.gameObject);
                instance = self;
            }

            return instance;
        }
    }

    public void GET<T>(string url, Action<T[]> onSuccess, Action<string> onFailure) {
        StartCoroutine(GetImpl(url, onSuccess, onFailure));
    }

    private IEnumerator GetImpl<T>(string url, Action<T[]> onSuccess, Action<string> onFailure) {
        var www = new WWW(url);
        yield return www;

        InvokeCallback(www, onSuccess, onFailure);
    }

    public void POST<T>(string url, Action<T[]> onSuccess, Action<string> onFailure, Dictionary<string, string> post) {
        StartCoroutine(POSTImpl(url, onSuccess, onFailure, post));
    }

    private IEnumerator POSTImpl<T>(string url, Action<T[]> onSuccess, Action<string> onFailure, Dictionary<string, string> post) {
        WWWForm form = new WWWForm();

        foreach (var post_arg in post)
            form.AddField(post_arg.Key, post_arg.Value);
       
        var www = new WWW(url, form);

        yield return www;

        InvokeCallback(www, onSuccess, onFailure);
    }

    private void InvokeCallback<T>(WWW www, Action<T[]> onSuccess, Action<string> onFailure) {
        if (www.error == null) {
            var parsedResult = JsonParser.FromJson<T>(www.text);

            if (onSuccess != null)
                onSuccess(parsedResult);
        }

        else {
            if (onFailure != null)
                onFailure(www.error);
        }
    }

    public static void ThrowIfFailed(string errorMessage) {
#if UNITY_EDITOR
        Debug.Log(errorMessage);
#endif
    }
}