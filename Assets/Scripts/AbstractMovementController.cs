using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonoBehaviourUpdateCallback
{
    UPDATE,
    FIXED_UPDATE
}

public abstract class AbstractMovementController : MonoBehaviour
{
    public float speed = 10;
    public float rotateSpeed = 10;
    public float amplitudeRotation = 0.95f;

    internal abstract MonoBehaviourUpdateCallback GetUpdateCallback();
    internal virtual void Move(Vector3 direction) { }
}
