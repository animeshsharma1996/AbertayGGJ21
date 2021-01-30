using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private int keyID;
    private bool isCollectable = true;

    private void OnEnable()
    {
        isCollectable = true;
    }

    private void OnDisable()
    {
        isCollectable = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCollectable)
        {
            if (other.gameObject.GetComponent<Collector>())
            {
                PickupKey();
            }
        }
    }

    private void PickupKey()
    {
        isCollectable = false;
        KeyManager.instance.CollectKey(keyID);
        gameObject.SetActive(false);
    }
}
