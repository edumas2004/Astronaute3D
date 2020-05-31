using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticPlayerMovementController : PlayerMovementController
{
    internal override MonoBehaviourUpdateCallback GetUpdateCallback()
    {
        return MonoBehaviourUpdateCallback.UPDATE;
    }

    internal override void Move(Vector3 worldDirection)
    {
        Debug.Log("movedByKinetic : " + worldDirection);
        base.Move(worldDirection);

        Vector3 velocity = gameObject.GetComponent<Rigidbody>().velocity;

        Debug.Log("-- movedByKinetic speed : " + velocity.magnitude);
        Debug.Log("-- movedByKinetic dot : " + Vector3.Dot(velocity, worldDirection));

        if (worldDirection.magnitude > 0)
        {
            // Rotate if new direction
            if (velocity.magnitude == 0 || Vector3.Angle(velocity, worldDirection) != 0)
            {
                // Rotate up to direction
                Rotate(worldDirection);
            }

            Debug.Log("-- movedByKinetic apply world translation : " + worldDirection);
            Vector3 localDirection = transform.InverseTransformDirection(worldDirection);
            transform.Translate(localDirection * speed * Time.deltaTime);

        }
    }
}
