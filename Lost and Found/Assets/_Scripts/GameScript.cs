using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;

    private PlayerAnimation[] playerAnimations = null;
    private EnemyAnimation[] enemyAnimations = null;
    private Detector[] detectors = null;
    private Patroller[] patrollers = null;

    // Start is called before the first frame update
    private void Start()
    {
        EnemySpawner.Instance.Initialise();
        AudioManager.Instance.Initialise();
        playerAnimations = FindObjectsOfType<PlayerAnimation>();
        enemyAnimations = FindObjectsOfType<EnemyAnimation>();
        detectors = FindObjectsOfType<Detector>();
        patrollers = FindObjectsOfType<Patroller>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            RestartLevel();
        }

        foreach (PlayerAnimation playerAnimation in playerAnimations)
        {
            if (playerAnimation.isActiveAndEnabled)
            {
                playerAnimation.OnUpdate();
            }
        }
        
        foreach(EnemyAnimation enemyAnimation in enemyAnimations)
        {
            if (enemyAnimation.isActiveAndEnabled)
            {
                enemyAnimation.OnUpdate();
            }
        } 
        
        foreach(Detector detector in detectors)
        {
            if(detector.isActiveAndEnabled)
            {
                detector.OnUpdate();
            }
        }
        
        foreach(Patroller patroller in patrollers)
        {
            if (patroller.isActiveAndEnabled)
            {
                patroller.OnUpdate();
            }
        }
    }

    private void RestartLevel()
    {
        GameManager.Instance.LostObj.SetActive(false);
        //GameManager.Instance.FoundObj.SetActive(false);
        GameManager.Instance.RestartLevel();

        foreach (Patroller patroller in patrollers)
        {
            patroller.gameObject.SetActive(true);
        }
    }

    public void PlayGame()
    {
        RestartLevel();
        mainMenuCanvas.SetActive(false);
    }
}
