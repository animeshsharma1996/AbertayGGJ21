using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        EnemySpawner.Instance.Initialise();
    }
}
