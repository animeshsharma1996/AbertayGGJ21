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

    public void OnUpdate()
    {
        Vector3 cameraVector = Camera.main.transform.forward;
        Vector3 enemyVector = transform.forward;

        float angle = Vector3.Angle(cameraVector, enemyVector);

        if (angle == 90f)
        {
            anim.SetInteger("EnemyModifier", 1);
        }
        else if (angle == 270f)
        {
            anim.SetInteger("EnemyModifier", 3);
        }
        else if ((angle > 270f && angle < 360f) || (angle >= 0f && angle < 90f))
        {
            anim.SetInteger("EnemyModifier", 2);
        }
        else
        {
            anim.SetInteger("EnemyModifier", 0);
        }
    }
}
