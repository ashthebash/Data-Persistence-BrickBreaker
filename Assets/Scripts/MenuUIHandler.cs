using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public HighScoreHandler highScore;

    public TMP_InputField nameInput;

    private void Start()
    {
        highScore.Init();
        nameInput.onValueChanged.AddListener(delegate { SetPlayerName(); });

        if (DataHandler.Instance.playerName != "")
        {
            nameInput.text = DataHandler.Instance.playerName;
        }
    }

    public void StartGame()
    {
        if (DataHandler.Instance.playerName == "")
        {
            DataHandler.Instance.playerName = "Player";
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
                Application.Quit();
#endif
    }

    private void SetPlayerName()
    {
        DataHandler.Instance.playerName = nameInput.text;
    }
}
