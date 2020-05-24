﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicPlayerMovementController : PlayerMovementController
{
    public float impulseForce = 500;

    private float maxForceSpeed = 100;

    private void Awake()
    {
        maxForceSpeed = speed;
    }

    internal override MonoBehaviourUpdateCallback GetUpdateCallback()
    {
        return  MonoBehaviourUpdateCallback.FIXED_UPDATE;
    }

    internal override void Move(Vector3 worldDirection)
    {
        Debug.Log("movedByForce : " + worldDirection);
        Vector3 velocity = gameObject.GetComponent<Rigidbody>().velocity;

        Debug.Log("-- movedByForce speed : " + velocity.magnitude);
        Debug.Log("-- movedByForce dot : " + Vector3.Dot(velocity, worldDirection));

        if (worldDirection.magnitude > 0)
        {
            Debug.Log("-- movedByForce apply force : " + worldDirection);
            gameObject.GetComponent<Rigidbody>().AddForce(worldDirection * impulseForce * Time.deltaTime);

            // We limit the velocity to maxForceSpeed 
            if (velocity.magnitude > maxForceSpeed)
            {
                gameObject.GetComponent<Rigidbody>().velocity = velocity * maxForceSpeed / velocity.magnitude;
            }

            // Rotate if new direction
            if (velocity.magnitude == 0 || Vector3.Angle(velocity, worldDirection) != 0)
            {
                //// Rotate up to direction (limited by amplitudeRotation according to axes x and y)
                //Vector3 targetRotation = (Vector3.forward / 2) - new Vector3(amplitudeRotation * worldDirection.x, amplitudeRotation * 0.5f * worldDirection.y, 0);
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetRotation), rotateSpeed * Time.deltaTime);
                Rotate(worldDirection);
            }
        }
        else
        {
            // Debug.Log("-- movedByForce apply opposite force to velocity : " + velocity);
            gameObject.GetComponent<Rigidbody>().AddForce(-gameObject.GetComponent<Rigidbody>().velocity / 20 * impulseForce * Time.deltaTime);
        }
    }
}