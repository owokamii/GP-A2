using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public TimerBar timerBar;

    public int waveNum = 0;

    public int currentWave;
    private int waveValue;

    public Vector2 spawnVal;

    public int waveDuration;
    public float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    public bool spawnerOn;
    public bool levelStarted = false;

    public PlayerHealth pHealth;

    void Start()
    {
        GenerateWave();
    }

    void FixedUpdate()
    {
        if(levelStarted)
        {
            timerBar.SetTimer(waveTimer);

            if (pHealth.currentHealth > 0 && spawnerOn)
            {
                if (spawnTimer <= 0)
                {
                    if (enemiesToSpawn.Count > 0)
                    {
                        int randSpawn = Random.Range(0, spawnpoints.Length);
                        Instantiate(enemiesToSpawn[0], spawnpoints[randSpawn].position, Quaternion.identity);
                        enemiesToSpawn.RemoveAt(0);
                        spawnTimer = spawnInterval;
                    }
                    else
                    {
                        waveTimer = 0;
                        currentWave += 1;
                        waveDuration += 10;
                        GenerateWave();
                    }
                }
                else
                {
                    spawnTimer -= Time.fixedDeltaTime;
                    waveTimer -= Time.fixedDeltaTime;
                }
            }
            else if (pHealth.currentHealth <= 0 && spawnerOn)
            {
                spawnerOn = false;
            }
        }
    }

    public void GenerateWave()
    {
        if(spawnerOn)
            FindObjectOfType<AudioManager>().Play("Wave");
        spawnerOn = true;

        waveNum += 1;

        waveValue = currentWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count; //gives a fixed time between each enemies
        waveTimer = waveDuration; //wave duration is read only
        timerBar.SetMaxTimer(waveTimer);
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    [System.Serializable]
    public class Enemy
    {
        public GameObject enemyPrefab;
        public int cost;
    }
}