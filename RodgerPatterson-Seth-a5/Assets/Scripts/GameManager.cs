using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PLayer player;
    public int lives = 3;


    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }



    private void GameOver()
    {

    }
    public void PlayerDied(PLayer player)
    {
        player.gameObject.SetActive(false);

        lives--;

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            player.transform.position = Vector3.zero;
            player.gameObject.SetActive(true);
        }


    }
}
