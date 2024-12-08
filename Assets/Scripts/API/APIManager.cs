using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class APIManager : MonoBehaviour
{
    public APIScripts api;
    public TMP_InputField UsernameField;
    public Button LoginButton;
    public TextMeshProUGUI LoginText;

    public static APIManager Instance;
    public string username;
    public bool loggedIn;
    public bool newUser;

    void Awake()
    {
        api.GetComponent<APIScripts>();
        if (LoginButton) LoginButton.onClick.AddListener(delegate { StartCoroutine("Login"); });
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator Login()
    {
        if (!loggedIn)
        {
            yield return api.CreatePlayer(UsernameField.text, AssembleDict(new string[4] { "Metal", "Wood", "Honey", "Bears" }, new object[4] { 1000, 1000, 1000, 10 }));
            username = UsernameField.text;
            if (api.requestResult == UnityWebRequest.Result.Success) LoginText.text = $"Signed up as a new user - {username}!";
            if (api.requestText == "{\"Error\":\"Player with this name already exists\"}") LoginText.text = $"Logged into user - {username}!";
            if (api.requestText == "{\"name\":[\"This field may not be blank.\"]}") LoginText.text = $"Username cannot be blank!";
            loggedIn = api.requestText != "{\"name\":[\"This field may not be blank.\"]}";
            newUser = api.requestResult == UnityWebRequest.Result.Success;
        }
    }

    Dictionary<string, object> AssembleDict(string[] keys, object[] values)
    {
        if (keys.Length != values.Length) return null;
        Dictionary<string, object> dict = new Dictionary<string, object>();
        for (int i = 0; i < values.Length; i++) dict.Add(keys[i], values[i]);
        return dict;
    }
}
