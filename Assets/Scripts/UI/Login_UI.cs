using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login_UI : MonoBehaviour {

    public GameObject signupWnd;

    public void SignIn()
    {
        Debug.Log("Sign in");
        SceneManager.SceneLoad("HomeScene");
    }

    public void SignUp()
    {
        signupWnd.SetActive(true);
    }
}
