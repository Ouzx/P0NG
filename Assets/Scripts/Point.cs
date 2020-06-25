using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField]
    private int point = 5;

    public bool isDestruction = false;

    private void OnDisable()
    {
        if(!isDestruction){
            PoolManager.Instance.RemoveReservedPosition(transform.position);
            transform.position = PoolManager.Instance.GetRandomPosition();
            AddPoint();
        }
    }

    private void AddPoint()
    {
        ScoreBoard.Instance.AddScore(point);
    }


}
