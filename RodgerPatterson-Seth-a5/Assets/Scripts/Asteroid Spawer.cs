using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AsteroidSpawer : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float spawnRate = 2.0f;
    public int spawnCount = 1;
    public float spawnDis = 15.0f;
    public float trajRotDegree = 15.0f;
   
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnCount; i++)
        {

            // Spawns Asteroid
            Vector3 spawnDir = Random.insideUnitCircle.normalized * this.spawnDis;
            Vector3 spawnPoint = this.transform.position + spawnDir;

            //sets Rotation
            float Varients = Random.Range(-this.trajRotDegree, this.trajRotDegree);
            Quaternion spawnRot = Quaternion.AngleAxis(Varients, Vector3.forward);


            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, spawnRot);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);

            asteroid.SetTrajector(spawnRot * -spawnDir);
            


        }




    }



}