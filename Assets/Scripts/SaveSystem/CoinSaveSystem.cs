using System;
using System.IO;
using UnityEngine;

public class CoinSaveSystem : MonoBehaviour
{
    public static CoinSaveSystem Instance;

    //private const string HIGH_SCORE_KEY = "HighScore";

    public static event Action<float> onHighScore;

    private float highScore;
    private PlayerData playerData;
    private string savePath;


    private void Awake()
    {
        Instance = this;

        savePath = Path.Combine(Application.persistentDataPath, "PlayerData.json");
    }


    private void Start()
    {
        LoadGame();
    }

    public void SaveGame()
    {
        if (ScoreManager.CurrentScore > highScore)
        {
            highScore = ScoreManager.CurrentScore;
            playerData.highScore = highScore;

            string json = JsonUtility.ToJson(playerData, true);

            File.WriteAllText(savePath, json);

            //PlayerPrefs.SetFloat(HIGH_SCORE_KEY, highScore);
            //PlayerPrefs.Save();
        }
    }

    private void LoadGame()
    {
        //highScore = PlayerPrefs.GetFloat(HIGH_SCORE_KEY, 0);
        //onHighScore.Invoke(highScore);

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);

            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            playerData = new PlayerData();
        }

        highScore = playerData.highScore;
        onHighScore?.Invoke(highScore);
    }

    public void DeleteData()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }

        playerData = new PlayerData();

        highScore = 0;

        onHighScore?.Invoke(highScore);
    }



}
