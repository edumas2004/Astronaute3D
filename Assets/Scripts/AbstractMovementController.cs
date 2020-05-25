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

    private List<IMovementObserver> observers = new List<IMovementObserver>();

    internal abstract MonoBehaviourUpdateCallback GetUpdateCallback();

    internal void Move(Vector3 direction) {
        DoMove(direction);
        NotifyObservers(direction);
    }

    protected abstract void DoMove(Vector3 direction);

    public void AddObserver(IMovementObserver observer)
    {
        observers.Add(observer);
    }

    void NotifyObservers(Vector3 direction)
    {
        foreach(IMovementObserver observer in observers)
        {
            observer.NotifyMovement(direction);
        }
    }
}

public interface IMovementObserver
{
    void NotifyMovement(Vector3 direction);
}
