using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipController : MonoBehaviour
{
    public float speedRotation = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.rotation = Quaternion.LookRotation(new Vector3(0, speedRotation * Time.fixedDeltaTime, 0), Vector3);

    }
}
