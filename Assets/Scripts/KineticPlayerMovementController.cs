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

        Vector3 velocity = gameObject.GetComponent<Rigidbody>().velocity;

        Debug.Log("-- movedByKinetic speed : " + velocity.magnitude);
        Debug.Log("-- movedByKinetic dot : " + Vector3.Dot(velocity, worldDirection));

        if (worldDirection.magnitude > 0)
        {
            Debug.Log("-- movedByKinetic apply world translation : " + worldDirection);
            Vector3 localDirection = transform.InverseTransformDirection(worldDirection);
            transform.Translate(localDirection * speed * Time.deltaTime);

            // Rotate if new direction
            if (velocity.magnitude == 0 || Vector3.Angle(velocity, worldDirection) != 0)
            {
                //// Rotate up to direction (limited by amplitudeRotation according to axes x and y)
                //Vector3 targetRotation = (Vector3.forward / 2) - new Vector3(amplitudeRotation * worldDirection.x, amplitudeRotation * 0.5f * worldDirection.y, 0);
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetRotation), rotateSpeed * Time.deltaTime); 
                Rotate(worldDirection);
            }
        }
    }
}
