using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemy; //The Enemy that Im spawning
    public int xPos;
    public int zPos;
    public int enemyCount; //How many of them Im putting into the game
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 2)
        {
            xPos = Random.Range(1, 50);
            zPos = Random.Range(1, 41);
            Instantiate(enemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }

        //https://www.youtube.com/watch?v=ydjpNNA5804 Source for the Code;
    }
}
