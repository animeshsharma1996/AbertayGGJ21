using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private List<Image> livesUI = new List<Image>(3);
    [SerializeField]
    private List<Image> keysUI = new List<Image>(5);

    [SerializeField]
    private Sprite lightOn;
    [SerializeField]
    private Sprite lightOff;

    // Start is called before the first frame update
    void Start()
    {
        ResetAllLivesUI();
        ResetAllKeysUI();
    }

    internal void KeyCollected(int index)
    {
        keysUI[index - 1].color = Color.white;
    }

    internal void LifeLost(int currentLives)
    {
        livesUI[currentLives].sprite = lightOff;
    }

    internal void ResetAllKeysUI()
    {
        foreach (Image key in keysUI)
        {
            key.enabled = true;
            key.color = Color.gray;
        }
    }

    internal void ResetAllLivesUI()
    {
        foreach (Image life in livesUI)
        {
            life.sprite = lightOn;
        }
    }
}
