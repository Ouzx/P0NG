using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    // test
    private int maxLife = 2;
    private int remainedLife =2 ;

    private char life = 'o';
    private char dead = 'X';
    public char[] lives;

    private GameManager gm;
    public TextMeshProUGUI text;
    void Start()
    {
        gm = GameManager.Instance;
        ResetLives();
    }

    void Update()
    {
        text.text = PrintLife();
        if (CheckLife()) ResetBall();
    }

    private string PrintLife()
    {
        int counter = 0;
        for(int i = 0; i < maxLife; i++)
        {
            if (counter < maxLife - remainedLife)
            {
                counter++;
                lives[i] = dead;
            }
            else lives[i] = life;
        }
        return lives.ArrayToString();

    }

    private bool CheckLife()
    {
        if (remainedLife <= 0)
        {
            gm.RestartGame();
            return false;
        }
        else if (remainedLife > maxLife) remainedLife = maxLife;
        return true;
    }

    public void DecreaseLife()
    {
        remainedLife--;
    }
    
    public void IncreaseRemainedLife()
    {
        remainedLife++;
    }

    public void ResetLives()
    {
        lives = new char[maxLife];
        remainedLife = maxLife;
        for (int i = 0; i < maxLife; i++) lives[i] = life;
    }

    public void ResetBall(bool isFall = false)
    {
        if (isFall) return;
        else gm.ResetGame();
    }
}
