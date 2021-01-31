using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    [SerializeField] private GameObject enemy = null;
    //[SerializeField] private int enemyPool = 0;
    [SerializeField] private PatrolPoints[] enemyPositions = null;

    public void Initialise()
    {
        for(int i = 0; i < enemyPositions.Length; ++i)
        {
            if (enemyPositions[i].isActiveAndEnabled)
            {
                GameObject enemyObject = Instantiate(enemy, enemyPositions[i].patrolPoints[0].position, enemyPositions[i].patrolPoints[0].rotation);

                enemyObject.GetComponent<Patroller>().points = enemyPositions[i].patrolPoints;
                enemyObject.GetComponent<Patroller>().Initialise();
            }
        }
    }
}
