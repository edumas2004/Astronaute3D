using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class PropulsorController : MonoBehaviour
{
    Vector3 initiaScale;
    ParticleSystem particuleSystem;

    private void Awake()
    {
        initiaScale = transform.localScale;
        particuleSystem = GetComponent<ParticleSystem>();

        if (gameObject.name.StartsWith("Propulsor_R") || gameObject.name.StartsWith("Propulsor_L"))
        {
            ParticleSystem.MainModule main = particuleSystem.main;
            main.loop = false;
        }
    }
    public void setImpulse(float inpulse)
    {
        Debug.Log("PropulsorController " + name + " setImpulse : " + inpulse);

        inpulse = Math.Max(0, inpulse);
        transform.localScale = new Vector3(initiaScale.x, initiaScale.y, initiaScale.z * inpulse);

        if (inpulse>0)
        {
            Debug.Log("PropulsorController " + name + " display : " + particuleSystem);
            if (!particuleSystem.isPlaying){
                particuleSystem.Play();
            }
        } 
        else
        {
            particuleSystem.Stop();
        }
        
    }
}
