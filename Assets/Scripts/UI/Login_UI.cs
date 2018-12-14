using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login_UI : MonoBehaviour {

    public GameObject LoginWnd;
    public GameObject signInWnd, signUpWnd;

    public InputField signInId, signInPw;
    public InputField signUpId, signUpPw, signUpNick;

    public void ActiveSignIn() {
        ActiveWindow(true);

        signUpId.text = string.Empty;
        signUpPw.text = string.Empty;
        signUpNick.text = string.Empty;
    }

    public void ActiveSignUp() {
        ActiveWindow(false);

        signInId.text = string.Empty;
        signInPw.text = string.Empty;
    }

    private void ActiveWindow(bool bSignIn) {
        signInWnd.SetActive(bSignIn);
        signUpWnd.SetActive(!bSignIn);
    }

    public void SignIn() {
        ServerConnector.Instance.GET<UserAllInfo>(ServerApi.GetUser + signInId.text, CheckSignIn, ServerConnector.ThrowIfFailed);
    }

    private void CheckSignIn(UserAllInfo[] user) {
        if (signInPw.text.Equals(user[0].password)) {
            UserManager.Instance.SetPlayer(user);
            LoginWnd.SetActive(false);
        }
    }

    public void SignUp() {
        var postArg = new Dictionary<string, string>();
        postArg.Add("id", signUpId.text);
        postArg.Add("password", signUpPw.text);
        postArg.Add("nick", signUpNick.text);

        ServerConnector.Instance.POST<UserInfo>(ServerApi.PostUser, CheckSignUp, ServerConnector.ThrowIfFailed, postArg);
    }

    private void CheckSignUp(UserInfo[] user) {
        ActiveSignIn();
    }
}
