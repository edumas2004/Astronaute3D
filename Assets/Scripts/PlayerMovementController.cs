using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PlayerMovementController : AbstractMovementController
{
    private JetpackController jetpackController;

    protected virtual void Awake()
    {
        jetpackController = gameObject.transform.Find("Jetpack").gameObject.GetComponent<JetpackController>();
        Debug.Log("PlayerMovementController Awake : jetpackController = " + jetpackController);
    }

    internal override void Move(Vector3 worldDirection)
    {
        base.Move(worldDirection);
        jetpackController.onMove(worldDirection);
    }

    protected virtual void Rotate(Vector3 worldDirection)
    {
        // Rotate up to direction (limited by amplitudeRotation according to axes x and y)
        Vector3 targetRotation = (Vector3.forward / 2) - new Vector3(amplitudeRotation * worldDirection.x, amplitudeRotation * 0.5f * worldDirection.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetRotation), rotateSpeed * Time.deltaTime);
        jetpackController.onRotate(targetRotation);
    }
}
