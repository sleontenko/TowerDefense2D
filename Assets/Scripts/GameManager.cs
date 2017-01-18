using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    
    public GameObject spawnPoint;
    public GameObject[] enemies;
    public int maxEnemiesOnscreen;
    public int totalEnemies;
    public int enemiesPerSpawn;
    public float spawnDelay = 0.5f;

    private int enemiesOnScreen = 0;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(spawn());
    }
    void Update()
    {
        
    }

    IEnumerator spawn()
    {
        if (enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                if(enemiesOnScreen < maxEnemiesOnscreen)
                {
                    GameObject newEnemy = Instantiate(enemies[0]) as GameObject;
                    newEnemy.transform.position = spawnPoint.transform.position;
                    enemiesOnScreen += 1;
                    //yield return new WaitForSeconds(0.5f);
                }                            
            }
            yield return new WaitForSeconds(spawnDelay);
            StartCoroutine(spawn());
        }
    }

    public void RemoveEnemyFromScreen()
    {
        if (enemiesOnScreen > 0)
            enemiesOnScreen -= 1;
    }
}