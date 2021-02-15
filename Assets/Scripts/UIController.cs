using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//UI controller + Scene Controller
public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private GameObject finishGamePanel;
    private bool isStart = true;

    private void Awake()
    {
        Food.onScoreIncrease += IncreaseScore;
        Wall.onScoreDecrease += IncreaseScore;
        Finish.onFinish += FinishGame;
        scoreText.text = "Score: " + generalScore;

        if (gameOverPanel.activeSelf)
        {
            gameOverPanel.SetActive(false);
        }

        if (finishGamePanel.activeSelf)
        {
            finishGamePanel.SetActive(false);
        }
    }


    private int generalScore;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (generalScore == 0 && !isStart || generalScore < 0)
        {
            GameOver();
        }

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }    

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void FinishGame()
    {
        finishGamePanel.SetActive(true);  
        Time.timeScale = 0;
    }

    private void IncreaseScore(int score)
    {
        if (isStart)
        {
            isStart = false;
        }
        generalScore += score;
        scoreText.text = "Score: " + generalScore;
    }

    private void OnDestroy()
    {
        Food.onScoreIncrease -= IncreaseScore;
        Wall.onScoreDecrease -= IncreaseScore;
        Finish.onFinish -= FinishGame;
    }
}
