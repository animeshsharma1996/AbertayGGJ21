using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    private bool isAlive = true;

    public bool IsAlive { get => isAlive; }
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Lethal>() != null)
        {
            //kill this
            gameObject.SetActive(false);
            //reset/restart level
        }
    }
}
