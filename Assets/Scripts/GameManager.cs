using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singelton
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        SceneName = SceneManager.GetActiveScene().name;
    }
    #endregion 

    private string SceneName;

    public Ball ball;
    private ScoreBoard scoreBoard;
    private LifeController lifeController;
    private PoolManager poolManager;
    
    void Start()
    {
        poolManager = PoolManager.Instance;
        scoreBoard = GetComponent<ScoreBoard>();
        lifeController = GetComponent<LifeController>();
        StartGame();
    }

    private void StartGame()
    {
        lifeController.ResetLives();
        scoreBoard.ResetScore();
        ball.Invoke("StartBall", 1f);
    }
    public void ResetGame()
    {
        ball.Invoke("StartBall", 1f);
    }
    public void RestartGame()
    {
        ball.StopAllCoroutines();
        lifeController.StopAllCoroutines();
        scoreBoard.StopAllCoroutines();
        poolManager.StopAllCoroutines();
        StopAllCoroutines();

        lifeController.ResetLives();
        scoreBoard.ResetScore();
        poolManager.ResetPools();
        ball.Invoke("StartBall", 1f);
    }
    

    
}
