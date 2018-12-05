using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInManager : MonoBehaviour {

    [System.Serializable]
    public struct LogInInfo {
        public InputField id;
        public InputField pw;
    }

    public LogInInfo signIn, signUp;

    public void SignIn() {
        
    }
}
