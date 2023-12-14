using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private PLayer player;

    public int lives = 3;
    public float respawnTime = 3f;
    public float RespawnInvun = 3f;


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

    private void Respawn()
    {
        
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);
        


    }

    private void TurnCollisonsON()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
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
            Invoke(nameof(Respawn), this.respawnTime);
        }

    }
}
