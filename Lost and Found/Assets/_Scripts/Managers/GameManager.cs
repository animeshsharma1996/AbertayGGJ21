using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject lostObj;
    [SerializeField]
    private GameObject foundObj;

    [SerializeField]
    private List<LevelManager> levelManager = new List<LevelManager>();
    private int currentLevelIndex = 0;

    private LevelManager CurrentLevel
    {
        get
        {
            return levelManager[currentLevelIndex];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.position = CurrentLevel.CameraTransform.position;
        StartLevel();
    }

    public void FinishLevel()
    {
        Debug.Log("you win");
        if (currentLevelIndex < levelManager.Count - 1)
        {
            // transition to next level
            currentLevelIndex++;
            MoveToNextLevel();
        }
        else
        {
            // completed all levels!
        }
    }

    private void MoveToNextLevel()
    {
        // transition camera to next camera transform
        // wait then start next level
        StartLevel();
    }

    private void StartLevel()
    {
        lostObj.transform.position = CurrentLevel.LostSpawnTransform.position;
        foundObj.transform.position = CurrentLevel.FoundSpawnTransform.position;
    }

    public void RestartLevel()
    {
        // restart players to spawn position
        // reset lives to 3

        // reset all keys
        // reset all enemies
    }
}
