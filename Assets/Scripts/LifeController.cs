using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    private int maxLife = 3;
    private int remainedLife = 3;

    private char life = '♥';
    private char dead = 'x';
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
            // Buraya: 
            // Oyun bitti devam etmek istiyor musunuz?
            // Bool'u gelecek.
            gm.ResetGame();
            return false;
        }
        else if (remainedLife > maxLife) remainedLife = maxLife;
        gm.StartGame();
        return true;
    }

    public void DecreaseLife()
    {
        remainedLife--;
        CheckLife();
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
        // else gm.ResetGame();
    }
}
