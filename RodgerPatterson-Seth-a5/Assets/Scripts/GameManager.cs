using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public ParticleSystem Explostion;
    public PLayer player;
    public int lives = 3;
    public int score = 0;


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

    public void AsteroidDied(Asteroid asteroid)
    {
        Explostion.transform.position = asteroid.transform.position;
        Explostion.Play();



    }

    private void GameOver()
    {

    }
    public void PlayerDied(PLayer player)
    {
        player.gameObject.SetActive(false);

        Explostion.transform.position = this.player.transform.position;
        Explostion.Play();

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
