using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    [SerializeField] private GameObject enemy = null;
    [SerializeField] private int enemyPool = 0;
    [SerializeField] private Transform[] enemyPositions = null;

    public void Initialise()
    {
        for(int i = 0; i < enemyPositions.Length; ++i)
        {
            GameObject enemyObject = Instantiate(enemy, enemyPositions[i].position, Quaternion.identity);

            for (int j = 0; j < enemyPositions[i].childCount; ++j)
            {
                for (int k = 0; k < enemyPositions[i].GetChild(j).childCount; ++k)
                {
                    enemyObject.GetComponent<Patroller>().points[k] = enemyPositions[i].GetChild(j).GetChild(k);
                } 
            }
            //enemyObject.GetComponent<Patroller>().Initialise();
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
