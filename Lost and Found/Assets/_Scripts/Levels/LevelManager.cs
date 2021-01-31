using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private Transform lostSpawnTransform;
    [SerializeField]
    private Transform foundSpawnTransform;
    [SerializeField]
    private List<Key> keyObjects;

    public Transform CameraTransform { get => cameraTransform; }
    public Transform LostSpawnTransform { get => lostSpawnTransform; }
    public Transform FoundSpawnTransform { get => foundSpawnTransform; }

    public void ResetKeyObjects()
    {
        foreach (Key key in keyObjects)
        {
            key.gameObject.SetActive(true);
        }
    }
}
