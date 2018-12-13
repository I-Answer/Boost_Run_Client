using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerConnector : MonoBehaviour {

    private static ServerConnector instance = null;

    public static ServerConnector Instance {
        get { return instance; }
    }

    private void Awake() {
        if (instance != null) return;

        DontDestroyOnLoad(gameObject);
        instance = this;

        GET<IdUserSpeed>("http://13.59.174.126:5000/record/rank/speed", SetPlayer, (errorMsg) => Debug.Log(errorMsg));
    }

    private void SetPlayer(IdUserSpeed[] userInfo) {
        foreach (var info in userInfo) {
            Debug.Log(info.nick);
        }
    }

    public void GET<T>(string url, Action<T[]> onSuccess, Action<string> onFailure) {
        StartCoroutine(GetImpl(url, onSuccess, onFailure));
    }

    private IEnumerator GetImpl<T>(string url, Action<T[]> onSuccess, Action<string> onFailure) {
        var www = new WWW(url);
        yield return www;

        if (www.error == null) {
            var parsedResult = JsonParser.FromJson<T>(www.text);
            onSuccess(parsedResult);
        }

        else onFailure("WWW Call Error");
    }

    public void POST<T>(string url, Action<T[]> onSuccess, Action<string> onFailure, Dictionary<string, string> post) {
        StartCoroutine(POSTImpl(url, onSuccess, onFailure, post));
    }

    public IEnumerator POSTImpl<T>(string url, Action<T[]> onSuccess, Action<string> onFailure, Dictionary<string, string> post) {
        WWWForm form = new WWWForm();

        foreach (var post_arg in post)
            form.AddField(post_arg.Key, post_arg.Value);
       
        var www = new WWW(url, form);

        yield return www;

        if (www.error == null) {
            var parsedResult = JsonParser.FromJson<T>(www.text);
            onSuccess(parsedResult);
        }

        else onFailure("WWW Call Error");
    }
}