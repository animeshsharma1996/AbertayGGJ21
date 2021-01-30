﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    private bool isAlive = true;
    private bool isCoolingDown = false;
    private const int maxLives = 3;
    private int currentLives = 3;
    [SerializeField]
    private float cooldownTimer = 4.0f;
    private Material sr;

    public bool IsAlive { get => isAlive; }
    public bool IsCoolingDown { get => isCoolingDown; set => isCoolingDown = value; }

    // coroutines
    private IEnumerator flash;

    // Start is called before the first frame update
    void Start()
    {
        flash = DamageFlash();
        currentLives = maxLives;
        isAlive = true;
        sr = GetComponent<MeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null && enemy.IsLethal)
        {
            CheckIfDead();
        }
    }

    private void CheckIfDead()
    {
        if (IsCoolingDown) { return; }
        
        currentLives--;
        isCoolingDown = true;
        UIManager.Instance.LifeLost(currentLives);
        if (currentLives == 0)
        {
            //kill this
            isAlive = false;
            gameObject.SetActive(false);
            currentLives = maxLives;
            GameManager.Instance.RestartLevel();
        }
        else
        {
            // start damage cooldown
            if (sr != null)
            {
                StartCoroutine(DamageCooldown());
            }
        }
    }

    private IEnumerator DamageCooldown()
    {
        float currentTimer = 0f;
        StartCoroutine(flash);
        while (currentTimer < cooldownTimer)
        {
            currentTimer += Time.deltaTime;
            yield return 0;
        }
        StopCoroutine(flash);
        IsCoolingDown = false;
    }

    private IEnumerator DamageFlash()
    {
        while (true)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.25f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.25f);
        }
    }
}
