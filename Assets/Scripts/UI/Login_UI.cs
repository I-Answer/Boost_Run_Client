using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Login_UI : MonoBehaviour {

    private const string signIn = "Sign In", signUp = "Sign Up";

    public GameObject signInWnd, signUpWnd;

    public Text titleText;

    public InputField signInId, signInPw;
    public InputField signUpId, signUpPw, signUpNick;

    public Notice_UI signInFail, signUpFail;

    public AudioClip changeWindowSound, successSound;

    private void Awake() {
        if (UserManager.Player != null)
            gameObject.SetActive(false);

        else if (!NetworkManager.IsConnected) {
            UserManager.SetPlayer(UserManager.OfflineUser);
            gameObject.SetActive(false);
        }
    }

    private void ActiveWindow(bool isSignIn) {
        SoundManager.PlaySound(changeWindowSound);

        signInWnd.SetActive(isSignIn);
        signUpWnd.SetActive(!isSignIn);
    }

    public void SignIn() {
        ServerConnector.GET<UserInfo>(CheckSignIn, ServerApi.GetUser + signInId.text);
    }

    private void CheckSignIn(UserInfo[] user) {
        if (user[0].isSuccess) {
            SoundManager.PlaySound(successSound);

            UserManager.SetPlayer(user[0]);
            gameObject.SetActive(false);
        }

        else {
            signInFail.Enable();
            ActiveSignIn();
        }
    }

    public void SignUp() {
        ServerConnector.POST<Result>(CheckSignUp, ServerApi.PostUser,
            new MultipartFormDataSection("id", signUpId.text),
            new MultipartFormDataSection("password", signUpPw.text),
            new MultipartFormDataSection("nick", signUpNick.text));
    }

    private void CheckSignUp(Result[] result) {
        if (result[0].isSuccess) {
            SoundManager.PlaySound(successSound);
            ActiveSignIn();
        }

        else {
            signUpFail.Enable();
            ActiveSignUp();
        }
    }

    public void ActiveSignIn() {
        titleText.text = signIn;

        ActiveWindow(true);

        signInId.text = string.Empty;
        signInPw.text = string.Empty;
    }

    public void ActiveSignUp() {
        titleText.text = signUp;

        ActiveWindow(false);

        signUpId.text = string.Empty;
        signUpPw.text = string.Empty;
        signUpNick.text = string.Empty;
    }
}
