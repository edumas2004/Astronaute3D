using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloController : MonoBehaviour
{
    public Light light;
    public float range = 10;
    public float deltaRange = .5f;

    // Start is called before the first frame update
    void Start()
    {
        light = transform.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        light.range = range + deltaRange * Random.value;
    }
}
