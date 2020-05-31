using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class JetpackController : MonoBehaviour
{
    private PropulsorController propulsor_BUR;
    private PropulsorController propulsor_BUL;
    private PropulsorController propulsor_BDR;
    private PropulsorController propulsor_BDL;
    private PropulsorController propulsor_FUR;
    private PropulsorController propulsor_FUL;
    private PropulsorController propulsor_FDR;
    private PropulsorController propulsor_FDL;
    private PropulsorController propulsor_RUF;
    private PropulsorController propulsor_RDF;
    private PropulsorController propulsor_LUF;
    private PropulsorController propulsor_LDF;

    public Dictionary<String, PropulsorController> propulsors  = new Dictionary<String, PropulsorController>();

    public Rigidbody rigidBody;

    private Vector3 previousVelocity = Vector3.zero;

    private void Start()
    {
        propulsor_BUR = findPropulsor("Propulsor_BUR");
        propulsor_BUL = findPropulsor("Propulsor_BUL");
        propulsor_BDR = findPropulsor("Propulsor_BDR");
        propulsor_BDL = findPropulsor("Propulsor_BDL");
        propulsor_FUR = findPropulsor("Propulsor_FUR");
        propulsor_FUL = findPropulsor("Propulsor_FUL");
        propulsor_FDR = findPropulsor("Propulsor_FDR");
        propulsor_FDL = findPropulsor("Propulsor_FDL");
        propulsor_RUF = findPropulsor("Propulsor_RUF");
        propulsor_RDF = findPropulsor("Propulsor_RDF");
        propulsor_LUF = findPropulsor("Propulsor_LUF");
        propulsor_LDF = findPropulsor("Propulsor_LDF");
    }   

    PropulsorController findPropulsor(String propulsorName)
    {
        PropulsorController propulsor = gameObject.transform.Find(propulsorName).gameObject.GetComponent<PropulsorController>();
        Debug.Log("-- JetpackController findPropulsor : " + propulsorName + " => " + propulsor);
        return propulsor;
    }

    internal void onMove(Vector3 worldDirection)
    {
        Debug.Log("-- JetpackController onMove : " + worldDirection);

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        float impulse = direction.magnitude != 0 ? 0.5f : 0f;

        propulsor_BUR.setImpulse(impulse);
        propulsor_BDR.setImpulse(impulse);
        propulsor_BUL.setImpulse(impulse);
        propulsor_BDL.setImpulse(impulse);
    }

    internal void onRotate(Vector3 targetRotation)
    {

        Debug.Log("JetpackController Activate " + targetRotation);

        if (Vector3.Dot(Vector3.up, targetRotation) > 0)
        {
            propulsor_BDR.setImpulse(0.5f);
            propulsor_BDL.setImpulse(0.5f);
            propulsor_FUR.setImpulse(0.5f);
            propulsor_FUL.setImpulse(0.5f);
        }

        if (Vector3.Dot(Vector3.down, targetRotation) > 0)
        {
            propulsor_BUR.setImpulse(0.5f);
            propulsor_BUL.setImpulse(0.5f);
            propulsor_FDR.setImpulse(0.5f);
            propulsor_FDL.setImpulse(0.5f);
        }

        if (Vector3.Dot(Vector3.right, targetRotation) > 0)
        {
            propulsor_LUF.setImpulse(0.5f);
            propulsor_LDF.setImpulse(0.5f);
        }

        if (Vector3.Dot(Vector3.left, targetRotation) > 0)
        {
            propulsor_RUF.setImpulse(0.5f);
            propulsor_RDF.setImpulse(0.5f);
        }
    }

    private void activatePropulsor(GameObject propulsor)
    {
        //propulsor.GetComponent<ParticleSystem>().;
        propulsor.GetComponent<PropulsorController>().setImpulse(1f);
    }

    private void stopPropulsor(GameObject propulsor)
    {
        //propulsor.GetComponent<ParticleSystem>().;
        propulsor.GetComponent<PropulsorController>().setImpulse(0f);
    }
    private void increasePropulsor(GameObject propulsor)
    {
        //propulsor.GetComponent<ParticleSystem>().;
        propulsor.GetComponent<PropulsorController>().setImpulse(1.5f);
    }
}
