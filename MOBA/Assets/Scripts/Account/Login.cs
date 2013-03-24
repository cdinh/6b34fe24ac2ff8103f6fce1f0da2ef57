using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {

    private const string LOGIN_URL = "";
    private const string REGISTER_URL = "";
    private const string APP_CODE = "68c00e32fccadee9787f78156c2a0432";

    private bool m_IsLoggingIn;

    private string m_Username;
    private string m_Password;

    private GUIStyle m_GuiStyle;

	// Use this for initialization
	void Start () {
        m_IsLoggingIn = false;

        m_Username = "";
        m_Password = "";

        m_GuiStyle = new GUIStyle();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (m_IsLoggingIn)
        {

        }

        GUI.Label(GuiUtility.PercRect(0.4f, 0.25f, 0.2f, 0.05f), "Username");
        m_Username = GUI.TextField(GuiUtility.PercRect(0.4f, 0.3f, 0.2f, 0.05f), m_Username, 32);

        GUI.Label(GuiUtility.PercRect(0.4f, 0.36f, 0.2f, 0.05f), "Password");
        m_Password = GUI.PasswordField(GuiUtility.PercRect(0.4f, 0.40f, 0.2f, 0.05f), m_Password, '*', 32);

        if (GUI.Button(GuiUtility.PercRect(0.45f, 0.5f, 0.1f, 0.05f), "Login"))
        {
            audio.Play();
            SubmitLogin();
        }
    }

    private void ShowLoginForm()
    {
    }

    private void ShowRegisterForm()
    {
    }

    private IEnumerator SubmitLogin()
    {
        WWWForm form = new WWWForm();
        form.AddField("appcode", APP_CODE);
        form.AddField("username", m_Username);
        form.AddField("password", m_Password);

        m_IsLoggingIn = true;
        WWW w = new WWW(LOGIN_URL, form);
        yield return w;
        m_IsLoggingIn = false;

        if (w.error == null)
        {
            Debug.Log(w.text);
            Application.LoadLevel("MainMenu");
        }
        else
        {
            Debug.Log(w.text);
        }

        w.Dispose();
    }

    private IEnumerator SubmitRegister(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("appcode", APP_CODE);
        form.AddField("username", username);
        form.AddField("password", password);

        WWW w = new WWW("");
        yield return w;
    }
}
