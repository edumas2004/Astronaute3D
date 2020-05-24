using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float impulseForce = 1000;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AsteroidController.start");
        Vector3 randomDirection = Random.insideUnitSphere;
        randomDirection.z = 0;
        gameObject.GetComponent<Rigidbody>().AddForce(randomDirection * impulseForce * Time.deltaTime);
    }
}
