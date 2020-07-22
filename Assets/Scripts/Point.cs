using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField]
    private int point = 5;

    [SerializeField]
    private float scaleAmount = 0.75f;

    [SerializeField]
    private int BurnAmount = 20;

    [SerializeField]
    private float PoisonAmountInSeconds = 0.5f;

    [SerializeField]
    private float PowerUpAmount = 1f;

    [SerializeField]
    private float SleepingTime = 3f; 

    public static int multipler = 1;
    [SerializeField]
    private float multiplactionTime = 20f;

    GameManager gm;
    void Start()
    {
        gm = GameManager.Instance;
    }
    private void OnDisable()
    {
        Replace();
        switch (tag)
        {
            case "Point":
                AddPoint();
                break;

            case "BBomb":
                gm.lifeController.DecreaseLife();
                break;
            case "BEnlarge":
                Pedal.Instance.transform.localScale = new Vector3(Pedal.Instance.transform.localScale.x + scaleAmount, Pedal.Instance.transform.localScale.y);
                break;
            case "BExtraBall":
                // Add ball
                break;
            case "BFlame":
                StartCoroutine(Burn());
                break;
            case "BPoison":
                StartCoroutine(Empoison());
                break;
            case "BPowerDown":
                gm.ball.maxSpeed -= PowerUpAmount;
                gm.ball.minSpeed -= PowerUpAmount;
                break;
            case "BPowerUp":
                gm.ball.maxSpeed += PowerUpAmount;
                gm.ball.minSpeed += PowerUpAmount;
                break;
            case "BRotten":
                // do something
                break;
            case "BShrink":
                Pedal.Instance.transform.localScale = new Vector3(Pedal.Instance.transform.localScale.x - scaleAmount, Pedal.Instance.transform.localScale.y);
                break;
            case "BSleep":
                StartCoroutine(Sleep());
                break;
            case "BTransportation":
                //transport
                break;
            case "BX2":
                StartCoroutine(Multiply(2));
                break;
        }
    }

    private void Replace()
    {
        PoolManager.Instance.RemoveReservedPosition(transform.position);
        transform.position = PoolManager.Instance.GetRandomPosition();
    }

    private void AddPoint()
    {
        ScoreBoard.Instance.AddScore(point * multipler);
    }

    IEnumerator Burn()
    {
        for (int i = 0; i < BurnAmount; i++)
        {
            gm.lifeController.DecreaseLife();
            yield return new WaitForSeconds(0.25f);
        }
    }
    IEnumerator Empoison()
    {
        while (true)
        {
            gm.lifeController.DecreaseLife();
            yield return new WaitForSeconds(PoisonAmountInSeconds);
        }
    }

    IEnumerator Sleep(){
        Pedal.isSleep = true;
        yield return new WaitForSeconds(SleepingTime);
        Pedal.isSleep = false;
    }

    IEnumerator Multiply(int multiplaction){
        multipler += multiplaction;
        yield return new WaitForSeconds(multiplactionTime);
        multipler -= multiplaction;
    }

}
