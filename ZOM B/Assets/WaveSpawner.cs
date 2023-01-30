using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { Spawning, Waiting, Counting }

[System.Serializable]
public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;

    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnpoints;

    public float timeBetweenWaves = 2f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.Counting;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
        if (spawnpoints.Length == 0)
        {
            Debug.LogError("No Spawn");
        }
    }

    void Update()
    {

        if (state == SpawnState.Waiting)
        {
            if (!EnemyIsAlive())
            {
                //Begin a new wave
                WaveCompleted();
            } 
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.Spawning)
            {
                //start spawning wave
                StartCoroutine( SpawnWave (waves[nextWave]));
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
        {
            Debug.Log("Counting down time");
            waveCountdown -= Time.deltaTime;
        }

    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        
        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Completed All waves Looping");
        }

        nextWave++;
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Base_Enemy") == null)
            {
                return false;
            }
        }

    return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave:" + _wave.name);
        state = SpawnState.Spawning;
        // Spawn

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds( 1f/_wave.rate);
        }

        state = SpawnState.Waiting;
        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        Transform _sp = spawnpoints[Random.Range (0, spawnpoints.Length) ];

        Instantiate(_enemy, transform.position, transform.rotation);
        Debug.Log("Spawning Enemy:" + _enemy.name);
    }
}
