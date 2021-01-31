using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isLethal = true;
    public bool IsLethal { get => isLethal; }

    public void KillEnemy()
    {
        isLethal = false;
        //start death coroutine
        // disable object
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        isLethal = false;
    }

    private void OnEnable()
    {
        isLethal = true;
    }
}
