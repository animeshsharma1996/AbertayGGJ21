using System;
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
    private SpriteRenderer sr;

    [SerializeField]
    private AudioSource lostHurtAudio;
    [SerializeField]
    private AudioSource lostDieAudio;

    public bool IsAlive { get => isAlive; set => isAlive = value; }
    public bool IsCoolingDown { get => isCoolingDown; set => isCoolingDown = value; }

    // coroutines
    private IEnumerator flash;

    // Start is called before the first frame update
    void Start()
    {
        flash = DamageFlash();
        currentLives = maxLives;
        isAlive = true;
        sr = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null && enemy.IsLethal)
        {
            //CheckIfDead();
        }
    }

    private void OnEnable()
    {
        currentLives = 3;
        Debug.Log("Current lives is " + currentLives);
    }

    public void CheckIfDead()
    {
        Debug.Log("iS COOLING DOWN = " + IsCoolingDown);
        if (IsCoolingDown) { return; }
        
        currentLives--;
        isCoolingDown = true;
        UIManager.Instance.LifeLost(currentLives);
        if (currentLives == 0)
        {
            //kill this
            lostDieAudio.Play();
            isAlive = false;
            gameObject.SetActive(false);
            currentLives = maxLives;
            GameManager.Instance.RestartLevel();
            IsCoolingDown = false;
        }
        else
        {
            // start damage cooldown
            if (sr != null)
            {
                lostHurtAudio.Play();
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
        sr.color = Color.white;
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
