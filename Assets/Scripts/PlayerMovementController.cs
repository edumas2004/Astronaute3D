using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovementController : AbstractMovementController
{
    public JetpackController jetpackController;

    internal override void Move(Vector3 direction)
    {
        base.Move(direction);
        jetpackController.Activate(direction);
    }

    protected void Rotate(Vector3 direction)
    {
        // Rotate up to direction (limited by amplitudeRotation according to axes x and y)
        Vector3 targetRotation = (Vector3.forward / 2) - new Vector3(amplitudeRotation * direction.x, amplitudeRotation * 0.5f * direction.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetRotation), rotateSpeed * Time.deltaTime);
    }
}
