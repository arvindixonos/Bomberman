using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public Map map;

    public Player player1;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void OnDestroy()
    {
        Instance = null;
    }

    void InitGame()
    {
        map.InitMap();

        //  player1.InitPlayer()    
    }

    void Start()
    {
        InitGame();

        StartCoroutine(TILEPOS());
    }


    IEnumerator TILEPOS()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                   // player1.transform.position = map.GetTilePosition(i, j) + new Vector3(0f, 0.18f, 0f);

                    yield return new WaitForSeconds(0.3f);
                }
            }
        }
    }
}
