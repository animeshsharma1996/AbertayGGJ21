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

    private CharacterController controller;

    [SerializeField]
    private List<string> acceptedKeyCodes;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MoveUpdate();
    }

    void MoveUpdate()
    {
        Vector3 vInput = new Vector3(CrossPlatformInputManager.GetAxis(acceptedKeyCodes[0]), 0f, CrossPlatformInputManager.GetAxis(acceptedKeyCodes[1]));
        Vector3 vInputDir = vInput.normalized;

        float vTargetSpeed = maxMovementSpeed * vInputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, vTargetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        controller.Move(vInputDir * currentSpeed * Time.deltaTime);
    }
}
