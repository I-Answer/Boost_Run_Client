using UnityEngine;
using UnityEngine.UI;

public class Login_UI : MonoBehaviour {

    private const string signIn = "Sign In", signUp = "Sign Up";

    public GameObject signInWnd, signUpWnd;

    public Text titleText;

    public InputField signInId, signInPw;
    public InputField signUpId, signUpPw, signUpNick;

    public AudioClip changeWindowSound, successSound;

    private void Awake() {
        if (UserManager.Instance.Player != null)
            gameObject.SetActive(false);

        else if (!NetworkManager.IsConnected) {
            UserManager.Instance.SetPlayer(UserManager.OfflineUser);
            gameObject.SetActive(false);
        }
    }

    public void ActiveSignIn() {
        titleText.text = signIn;

        ActiveWindow(true);

        signUpId.text = string.Empty;
        signUpPw.text = string.Empty;
        signUpNick.text = string.Empty;
    }

    public void ActiveSignUp() {
        titleText.text = signUp;

        ActiveWindow(false);

        signInId.text = string.Empty;
        signInPw.text = string.Empty;
    }

    private void ActiveWindow(bool isSignIn) {
        SoundManager.PlaySound(changeWindowSound);

        signInWnd.SetActive(isSignIn);
        signUpWnd.SetActive(!isSignIn);
    }

    public void SignIn() {
        ServerConnector.Instance.GET<UserAllInfo>(ServerApi.GetUser + signInId.text, CheckSignIn);
    }

    private void CheckSignIn(UserAllInfo[] user) {
        if (signInPw.text.Equals(user[0].password)) {
            SoundManager.PlaySound(successSound);

            UserManager.Instance.SetPlayer(user);
            gameObject.SetActive(false);
        }
    }

    public void SignUp() {
        ServerConnector.PostDictionary.Clear();
        ServerConnector.PostDictionary.Add("id", signUpId.text);
        ServerConnector.PostDictionary.Add("password", signUpPw.text);
        ServerConnector.PostDictionary.Add("nick", signUpNick.text);

        ServerConnector.Instance.POST<UserInfo>(ServerApi.PostUser, CheckSignUp);
    }

    private void CheckSignUp(UserInfo[] user) {
        SoundManager.PlaySound(successSound);

        ActiveSignIn();
    }
}
