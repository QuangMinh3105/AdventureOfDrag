using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    [SerializeField]
    private Button Start;

    [SerializeField]
    private Text ScoreText, endScoreText, bestScoreText;

    [SerializeField]
    private GameObject gameOverPanel;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 0;
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }    

    public void PlayGame()
    {
        Time.timeScale = 1;
        Start.gameObject.SetActive(false);
    }

    public void SetScore(int score)
    {
        ScoreText.text = "" + score;
    }    

    public void ShowPanel(int score)
    {
        gameOverPanel.SetActive(true);
        endScoreText.text = "" + score;
        if (score > GameManager.instance.GetHighScore())
        {
            GameManager.instance.SetHighScore(score);
        }
        bestScoreText.text = "" + GameManager.instance.GetHighScore();
    }    
    public void MenuButton()
    {
        Application.LoadLevel("MainMenu");
    }    

    public void RestartButton()
    {
        Application.LoadLevel("GamePlay");
    }    
}
