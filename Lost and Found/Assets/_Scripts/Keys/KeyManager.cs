﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance;

    [SerializeField]
    private const int maxKeys = 5;
    private bool[] completedKeys;

    private AudioSource keyCollectAudioSource;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (this != instance)
        {
            Destroy(this);
        }

        completedKeys = new bool[maxKeys];
        keyCollectAudioSource = GetComponent<AudioSource>();
    }

    public void ResetKeys()
    {
        for (int i = 0; i < completedKeys.Length; i++)
        {
            completedKeys[i] = false;
        }
    }

    public void CollectKey(int index)
    {
        Debug.Log("Completed keys length = " + completedKeys.Length + " and index is " + index);
        completedKeys[index-1] = true;
        UIManager.Instance.KeyCollected(index);
        CheckWin();
        keyCollectAudioSource.Play();
    }

    private void CheckWin()
    {
        // not win check
        foreach (bool key in completedKeys)
        {
            if (key == false) { return; }
        }

        // win - all keys true
        //transition to next level
        GameManager.Instance.FinishLevel();
        // reset manager keys
        ResetKeys();
    }
}
