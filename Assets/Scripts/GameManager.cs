using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
    #endregion 

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

    public void StartGame()
    {
        ball.Invoke("StartBall", 1f);
    }

    // public void ResetGame()
    // {
    //     ball.StopAllCoroutines();
    //     lifeController.StopAllCoroutines();
    //     scoreBoard.StopAllCoroutines();
    //     poolManager.StopAllCoroutines();
    //     StopAllCoroutines();

    //     lifeController.ResetLives();
    //     scoreBoard.ResetScore();
    //     poolManager.ResetPools();

    //     StartGame();
    // }
    
}
