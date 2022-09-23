using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private const string HighScore = "High Score";
    // Start is called before the first frame update
    void Awake()
    {
        MakeSingleInstance();
    }

    void MakeSingleInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }    else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }    

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HighScore, score);
    }    

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScore);
    }
}
