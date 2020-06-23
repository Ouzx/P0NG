using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    #region Singleton
    public static ScoreBoard Instance;
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion

    private int score = 0;
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = score.ToString();        
    }

    public void AddScore(int point)
    {
        score += point;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
