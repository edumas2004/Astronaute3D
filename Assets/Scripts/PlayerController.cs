using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

[RequireComponent(typeof(AbstractMovementController))]
public class PlayerController : MonoBehaviour
{
    //public float speed = 10;
    //public float rotateSpeed = 10;

    //public bool movedByForce = false;
    //public float impulseForce = 100;
    //public float amplitudeRotation = 0.95f;
    //public float maxForceSpeed = 100;

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
        if (movementController.GetUpdateCallback() == updateCallback)
        {
            movementController.Move(getInputDirection());
        }
    }

    private Vector3 getInputDirection()
    {
        return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
    }

    //void FixedUpdate()
    //{
    //    // Read gamer input and compute related word space direction
    //    Vector3 worldDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

    //    // Motion by physical force
    //    if (movedByForce)
    //    {
    //        Debug.Log("movedByForce : " + worldDirection);
    //        Vector3 velocity = gameObject.GetComponent<Rigidbody>().velocity;

    //        Debug.Log("-- movedByForce speed : " + velocity.magnitude);
    //        Debug.Log("-- movedByForce dot : " + Vector3.Dot(velocity, worldDirection));

    //        if (worldDirection.magnitude>0)
    //        {
    //            Debug.Log("-- movedByForce apply force : " + worldDirection);
    //            gameObject.GetComponent<Rigidbody>().AddForce(worldDirection * impulseForce * Time.deltaTime);

    //            // We limit the velocity to maxForceSpeed 
    //            if (velocity.magnitude > maxForceSpeed)
    //            {
    //                gameObject.GetComponent<Rigidbody>().velocity = velocity * maxForceSpeed / velocity.magnitude;
    //            }

    //            // Rotate if new direction
    //            if (velocity.magnitude == 0 || Vector3.Angle(velocity, worldDirection) != 0)
    //            {
    //                // Rotate up to direction (limited by amplitudeRotation according to axes x and y)
    //                Vector3 targetRotation = (Vector3.forward / 2) - new Vector3(amplitudeRotation * worldDirection.x, amplitudeRotation * 0.5f * worldDirection.y, 0);
    //                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetRotation), rotateSpeed * Time.deltaTime);
    //            }
    //        }  
    //        else
    //        {
    //            // Debug.Log("-- movedByForce apply opposite force to velocity : " + velocity);
    //            gameObject.GetComponent<Rigidbody>().AddForce(- gameObject.GetComponent<Rigidbody>().velocity/20 * impulseForce * Time.deltaTime);
    //        }

    //    } 
    //    // Motion by translation
    //    else
    //    {

    //        Debug.Log("movedByKinetic : " + worldDirection);

    //        Vector3 velocity = gameObject.GetComponent<Rigidbody>().velocity;

    //        Debug.Log("-- movedByKinetic speed : " + velocity.magnitude);
    //        Debug.Log("-- movedByKinetic dot : " + Vector3.Dot(velocity, worldDirection));

    //        if (worldDirection.magnitude > 0)
    //        {
    //            Debug.Log("-- movedByKinetic apply world translation : " + worldDirection);
    //            Vector3 localDirection = transform.InverseTransformDirection(worldDirection);
    //            transform.Translate(localDirection * speed * Time.deltaTime);

    //            // Rotate if new direction
    //            if (velocity.magnitude == 0 || Vector3.Angle(velocity, worldDirection) != 0)
    //            {
    //                // Rotate up to direction (limited by amplitudeRotation according to axes x and y)
    //                Vector3 targetRotation = (Vector3.forward / 2) - new Vector3(amplitudeRotation * worldDirection.x, amplitudeRotation * 0.5f * worldDirection.y, 0);
    //                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetRotation), rotateSpeed * Time.deltaTime);
    //            }
    //        }
    //        else
    //        {
    //            // Debug.Log("-- movedByForce apply opposite force to velocity : " + velocity);
    //            gameObject.GetComponent<Rigidbody>().AddForce(-gameObject.GetComponent<Rigidbody>().velocity / 20 * impulseForce * Time.deltaTime);
    //        }
    //    }
    //}

}
