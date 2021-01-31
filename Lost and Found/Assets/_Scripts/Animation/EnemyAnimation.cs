using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim = null;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 cameraVector = Camera.main.transform.forward;
        Vector3 enemyVector = transform.forward;

        switch(Vector3.Dot(cameraVector,enemyVector))
        {
            case -1:
                anim.SetInteger("EnemyModifier", 0);
                break;
            case 0:
                if(Vector3.Cross(cameraVector,enemyVector).magnitude > 0)
                {
                    anim.SetInteger("EnemyModifier", 3);
                }
                else
                {
                    anim.SetInteger("EnemyModifier", 1);
                }
                break; 
            case 1:
                anim.SetInteger("EnemyModifier", 2);
                break;
        }
    }
}
