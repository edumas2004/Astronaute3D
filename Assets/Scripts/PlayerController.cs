using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float rotateSpeed = 10;

    public bool movedByForce = false;
    public float impulseForce = 100;
    public float amplitudeRotation = 0.85f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // Read gamer input
        float input_h = Input.GetAxis("Horizontal");
        float input_v = Input.GetAxis("Vertical");

        // Compute related word space direction
        Vector3 worldDirection = new Vector3(input_h, input_v, 0);
        //Debug.DrawRay(transform.position, worldDirection, Color.red, 30f);

        // Motion by physical force
        if (movedByForce)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(worldDirection * impulseForce * Time.deltaTime);
        } 
        // Motion by translation
        else
        {
            Vector3 localDirection = transform.InverseTransformDirection(worldDirection);
            transform.Translate(localDirection * speed * Time.deltaTime);
        }

        // Rotate up to direction (limited by amplitudeRotation according to axes x and y)
        Vector3 targetRotation = Vector3.forward - new Vector3(amplitudeRotation * input_h, amplitudeRotation * 0.5f * input_v, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetRotation), rotateSpeed * Time.deltaTime);
    }
}
