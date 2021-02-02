using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject lostObj;
    [SerializeField]
    private GameObject foundObj;

    [SerializeField]
    private List<LevelManager> levelManager = new List<LevelManager>();
    private int currentLevelIndex = 0;

    [SerializeField] private GameObject mainMenuCanvas;

    private LevelManager CurrentLevel
    {
        get
        {
            return levelManager[currentLevelIndex];
        }
    }

    public GameObject LostObj { get { return lostObj; } }
    public GameObject FoundObj { get { return foundObj; } }

    // Start is called before the first frame update
    private void Start()
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
            Debug.Log("Moving to next level");
            currentLevelIndex++;
            MoveToNextLevel();
        }
        else
        {
            // completed all levels!
            //SceneManager.LoadScene(0);
            mainMenuCanvas.SetActive(true);
        }
    }

    private void MoveToNextLevel()
    {
        // transition camera to next camera transform
        // wait then start next level
        CameraTransitionToNewLevel();
        SwitchPatrolPoints();

    }

    internal void CameraTransitionToNewLevel()
    {
        StartCoroutine(MoveCamera());
    }
    private IEnumerator MoveCamera()
    {
        Camera camera = Camera.main;
        float movementSpeed = 25f;
        while (Vector3.Distance(camera.transform.position, CurrentLevel.CameraTransform.position) > movementSpeed * Time.deltaTime)
        {
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, CurrentLevel.CameraTransform.position, movementSpeed * Time.deltaTime);
            yield return null;
        }
        camera.transform.position = CurrentLevel.CameraTransform.position;
        StartLevel();
    }

    private void StartLevel()
    {
        foundObj.SetActive(false);
        lostObj.transform.position = CurrentLevel.LostSpawnTransform.position;
        foundObj.transform.position = CurrentLevel.FoundSpawnTransform.position;
        lostObj.SetActive(true);
        lostObj.GetComponent<Killable>().IsAlive = true;
        foundObj.SetActive(true);
        UIManager.Instance.ResetAllKeysUI();
        KeyManager.instance.ResetKeys();
        UIManager.Instance.ResetAllLivesUI();
        EnemySpawner.Instance.SetAllEnemies(true);
        SwitchPatrolPoints();
    }

    private void SwitchPatrolPoints()
    {
        switch (currentLevelIndex)
        {
            case 0:
                EnemySpawner.Instance.levelPoints[0].SetActive(true);
                EnemySpawner.Instance.levelPoints[1].SetActive(false);
                EnemySpawner.Instance.Initialise();
            break;
            case 1:
                EnemySpawner.Instance.levelPoints[1].SetActive(true);
                EnemySpawner.Instance.levelPoints[0].SetActive(false);
                EnemySpawner.Instance.Initialise();
            break;
        }
    }


    public void RestartLevel()
    {
        // restart players to spawn position
        StartLevel();
        // reset lives to 3
        UIManager.Instance.ResetAllKeysUI();
        KeyManager.instance.ResetKeys();
        CurrentLevel.ResetKeyObjects();
        UIManager.Instance.ResetAllLivesUI();
        // reset all enemies
    }
}
