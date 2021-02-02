using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    [SerializeField] private GameObject enemy = null;
    [SerializeField] private PatrolPoints[] enemyPositions = null;
    public GameObject[] levelPoints = null;

    private List<GameObject> enemies = new List<GameObject>();

    public void Initialise()
    {
        if (enemies.Count == 0)
        {
            for (int i = 0; i < enemyPositions.Length; ++i)
            {
                if (enemyPositions[i].isActiveAndEnabled)
                {
                    GameObject enemyObject = Instantiate(enemy, enemyPositions[i].patrolPoints[0].position, enemyPositions[i].patrolPoints[0].rotation);
                    enemyObject.GetComponent<Patroller>().points = enemyPositions[i].patrolPoints;
                    enemyObject.GetComponent<Patroller>().Initialise();
                    enemies.Add(enemyObject);
                }
            }
        }
    }

    public void ResetEnemies()
    {
        if(enemies != null)
        {
            enemies.Clear();
        }
    }

    public void SetAllEnemies(bool value)
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemies.Count != 0)
            {
                enemy.SetActive(value);
            }
        }
    }
}
