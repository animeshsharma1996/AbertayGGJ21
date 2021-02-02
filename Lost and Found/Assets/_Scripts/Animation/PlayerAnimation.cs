using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim = null;

    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode left;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnUpdate()
    {
        if(Input.GetKey(up))
        {
            anim.SetInteger("EnemyModifier",2);
        }
        
        if(Input.GetKey(down))
        {
            anim.SetInteger("EnemyModifier", 0);
        }

        if (Input.GetKey(right))
        {
            anim.SetInteger("EnemyModifier", 1);
        }

        if (Input.GetKey(left))
        {
            anim.SetInteger("EnemyModifier", 3);
        }
    }
}
