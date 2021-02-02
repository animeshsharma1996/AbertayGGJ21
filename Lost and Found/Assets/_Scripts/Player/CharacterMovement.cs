using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterMovement : MonoBehaviour
{
    private float currentSpeed;
    private float speedSmoothVelocity;
    [SerializeField]
    private float speedSmoothTime;
    [SerializeField]
    private float maxMovementSpeed;

    private Killable killable;
    private CharacterController controller;
    [SerializeField]
    private List<string> acceptedKeyCodes;

    public bool CanMove
    {
        get
        {
            if (killable == null)
            {
                return true;
            }
            else
            {
                return killable.IsAlive;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        killable = GetComponent<Killable>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (CanMove)
        {
            MoveUpdate();
        }
    }

    void MoveUpdate()
    {
        Vector3 vInput = new Vector3(CrossPlatformInputManager.GetAxis(acceptedKeyCodes[0]), 0f, CrossPlatformInputManager.GetAxis(acceptedKeyCodes[1]));
        Vector3 vInputDir = vInput.normalized;

        float vTargetSpeed = maxMovementSpeed * vInputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, vTargetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        controller.Move(vInputDir * currentSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x,0.49f,transform.position.z);
    }
}
