using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private int keyID;
    private bool isCollectable = true;

    private static float maxDistance = 100f;
    private static float minDistance = 1f;

    private Renderer meshRenderer;
    private static Protector lostObj;

    private void Start()
    {
        meshRenderer = GetComponent<Renderer>();
        //meshRenderer.material.color = new Color(1f, 1f, 1f, 1f);
        lostObj = FindObjectOfType<Protector>();
    }

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

    private void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, lostObj.transform.position);
        float distScale = dist > maxDistance ? 0f : dist < minDistance ? 1f : 1 - (dist - minDistance / maxDistance - minDistance);
        Debug.Log("Distscale = " + distScale);
        meshRenderer.material.color = Vector4.Lerp(new Color(1f, 1f, 1f, 0f), new Color(1f, 1f, 1f, 1f), distScale);

    }
}
