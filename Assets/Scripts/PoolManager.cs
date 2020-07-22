using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region Singelton
    public static PoolManager Instance;
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

    public List<Vector2> ReservedPositions;

    [SerializeField]
    private float boxSize = 0.7f;

    [SerializeField]
    private Vector2 origin = new Vector2(-2.74f, 2);

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        public List<GameObject> prefabs;
    }
    public List<Pool> pools;
    void Start()
    {
        FillPools();
    }

    IEnumerator SetPools(List<GameObject> prefabs)
    {
        while (true)
        {
            foreach(GameObject prefab in prefabs)
            {
                if(prefab.activeSelf == false)
                {
                    prefab.SetActive(true);
                }
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    public Vector2 GetRandomPosition()
    {
        int x = Random.Range(0, 7);
        int y = Random.Range(0, 8);
        Vector2 position = new Vector2(x * boxSize + origin.x, -y * boxSize + origin.y);
        if (ReservedPositions.Count != 0)
        {
            while (ReservedPositions.Contains(position))
            {
                x = Random.Range(0, 7);
                y = Random.Range(0, 8);
                position = new Vector2(x * boxSize + origin.x, -y * boxSize + origin.y);
            }
            ReservedPositions.Add(position);
            return position;
        }
        else
        {
            ReservedPositions.Add(position);
            return position;
        }
    }

    public void RemoveReservedPosition(Vector2 position)
    {
        if(ReservedPositions.Contains(position))
            ReservedPositions.Remove(position);
    }

    // public void ResetPools()
    // {
    //     foreach (Pool pool in pools)
    //     {
    //         foreach(GameObject gos in pool.prefabs)
    //         {
    //             var temp = gos.GetComponent<Point>();
    //             if(temp != null) temp.isDestruction = true;                
    //             Destroy(gos);
    //         }
    //         pool.prefabs.Clear();
    //     }
    //     ReservedPositions.Clear();
    //     FillPools();
    // }

    private void FillPools()
    {

        foreach (Pool pool in pools)
        {
            for (int i = 0; i < pool.size; i++)
            {
                pool.prefabs.Add(Instantiate(pool.prefab, GetRandomPosition(), Quaternion.identity, gameObject.transform)); ;
            }
            StartCoroutine(SetPools(pool.prefabs));
        }
    }
   
}
