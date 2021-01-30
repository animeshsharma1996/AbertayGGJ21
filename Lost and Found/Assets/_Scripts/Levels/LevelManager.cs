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

    public Transform CameraTransform { get => cameraTransform; }
    public Transform LostSpawnTransform { get => lostSpawnTransform; }
    public Transform FoundSpawnTransform { get => foundSpawnTransform; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
