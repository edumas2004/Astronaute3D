using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

[RequireComponent(typeof(AbstractMovementController))]
public class PlayerController : MonoBehaviour
{
    public AbstractMovementController movementController;

    private Vector3 previousDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        movementController = GetComponent<AbstractMovementController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(MonoBehaviourUpdateCallback.FIXED_UPDATE);
    }

    // Update is called once per frame
    void Update()
    {
        Move(MonoBehaviourUpdateCallback.UPDATE);
    }

    private void Move(MonoBehaviourUpdateCallback updateCallback)
    {
        // call movementController.Move if it acts on provided callback
        if (movementController.GetUpdateCallback() == updateCallback)
        {
            movementController.Move(getInputWorldDirection());
        }
    }

    private Vector3 getInputWorldDirection()
    {
        return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
    }   

}
