using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class HighScoreHandler : MonoBehaviour
{
    private string highScorePath = "/highscore.json";

    public TextMeshProUGUI nameUI;
    public TextMeshProUGUI scoreUI;

    private string playerName;
    public string PlayerName
    {
        get
        {
            return playerName;
        }

        private set
        {
            playerName = value;
            nameUI.text = playerName + ":";
        }
    }


    private int playerScore;

    public int PlayerScore
    {
        get
        {
            return playerScore;
        }

        private set
        {
            playerScore = value;
            scoreUI.text = playerScore.ToString();
        }
    }

    public int HighScore
    {
        get
        {
            return playerScore;
        }
    }


    [System.Serializable]
    class HighScoreData
    {
        public string name;
        public int score;
    }

    public void Init()
    {
        if (LoadHighScore())
        {
            gameObject.SetActive(true);
        }   
        else
        {
            gameObject.SetActive(false);
        }
    }

    public bool LoadHighScore()
    {
        string path = Application.persistentDataPath + highScorePath;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            PlayerName = data.name.ToString();
            PlayerScore = data.score;

            return true;
        }
        else
        {
            return false;
        }
    }

    public void SaveHighScore(string name, int score)
    {
        HighScoreData data = new HighScoreData();
        data.name = name;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + highScorePath, json);
    }
}
