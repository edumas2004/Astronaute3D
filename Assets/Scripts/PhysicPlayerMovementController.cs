using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class PhysicPlayerMovementController : PlayerMovementController
{
    public float impulseForce = 500;
    private float maxForceSpeed = 100;

    protected override void Awake()
    {
        base.Awake();
        maxForceSpeed = speed;
    }

    internal override MonoBehaviourUpdateCallback GetUpdateCallback()
    {
        return  MonoBehaviourUpdateCallback.FIXED_UPDATE;
    }

    internal override void Move(Vector3 worldDirection)
    {
        Debug.Log("PhysicPlayerMovementController : " + worldDirection);

        base.Move(worldDirection);

        Vector3 velocity = gameObject.GetComponent<Rigidbody>().velocity;

        Debug.Log("-- PhysicPlayerMovementController speed : " + velocity.magnitude);
        Debug.Log("-- PhysicPlayerMovementController dot : " + Vector3.Dot(velocity, worldDirection));

        if (worldDirection.magnitude > 0)
        {
            // Rotate if new direction
            if (velocity.magnitude == 0 || Vector3.Angle(velocity, worldDirection) != 0)
            {
                // Rotate up to direction
                Rotate(worldDirection);
            }

            ApplyForce(worldDirection);

            // We limit the velocity to maxForceSpeed 
            if (velocity.magnitude > maxForceSpeed)
            {
                gameObject.GetComponent<Rigidbody>().velocity = velocity * maxForceSpeed / velocity.magnitude;
            }
        }
        else
        {
            Break(velocity);
        }
    }

    protected virtual void ApplyForce(Vector3 worldDirection)
    {
        Debug.Log("-- PhysicPlayerMovementController apply force : " + worldDirection);
        gameObject.GetComponent<Rigidbody>().AddForce(worldDirection * impulseForce * Time.deltaTime);
    }

    protected virtual void Break(Vector3 velocity)
    {
        // Debug.Log("-- movedByForce apply opposite force to velocity : " + velocity);
        gameObject.GetComponent<Rigidbody>().AddForce(-gameObject.GetComponent<Rigidbody>().velocity / 20 * impulseForce * Time.deltaTime);
    }
}
