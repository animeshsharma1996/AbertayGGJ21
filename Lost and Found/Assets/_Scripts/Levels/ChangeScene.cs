using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad;
    [SerializeField] private GameObject mainMenuCanvas;

    public void ChangeToNextScene()
    {
        SceneManager.LoadSceneAsync(sceneIndexToLoad);
    }

    public void PlayGame()
    {
        mainMenuCanvas.SetActive(false);
    }

}