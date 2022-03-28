using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI userField;

    public TextMeshProUGUI alertField;
    public TMP_InputField inputField;

    private void Start()
    {
       if (string.IsNullOrEmpty(DataManager.Instance.HighScoreUserName))
        {
            userField.text += System.Environment.NewLine + "None";
        }
        else
        {
            userField.text += System.Environment.NewLine + DataManager.Instance.HighScoreUserName + " - " + DataManager.Instance.HighScore;
        }
    }


    public void StartNew()
    {
        if (string.IsNullOrEmpty(inputField.text))
        {
            alertField.gameObject.SetActive(true);
        }
        else
        {
            DataManager.Instance.CurrentUserName = inputField.text;
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
