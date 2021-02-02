using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim = null;

    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode left; 
    
    [SerializeField] private string horizontal;
    [SerializeField] private string vertical;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnUpdate()
    {
        if (CrossPlatformInputManager.GetAxis(vertical) > 0)
        {
            anim.SetInteger("EnemyModifier", 2);
        }

        if (CrossPlatformInputManager.GetAxis(vertical) < 0)
        {
            anim.SetInteger("EnemyModifier", 0);
        }

        if (CrossPlatformInputManager.GetAxis(horizontal) > 0)
        {
            anim.SetInteger("EnemyModifier", 1);
        }

        if (CrossPlatformInputManager.GetAxis(horizontal) < 0)
        {
            anim.SetInteger("EnemyModifier", 3);
        }
    }
}
