using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackController : MonoBehaviour
{
    public GameObject propulsor_BUR; 
    public GameObject propulsor_BUL;
    public GameObject propulsor_BDR;
    public GameObject propulsor_BDL;
    public GameObject propulsor_FUR;
    public GameObject propulsor_FUL;
    public GameObject propulsor_FDR;
    public GameObject propulsor_FDL;

    public void Activate(Vector3 direction)
    {

        Debug.Log("JetpackController Activate " + Vector3.Dot(Vector3.up, direction));

        if (Vector3.Dot(Vector3.up, direction) > 0)
        {
            activatePropulsor(propulsor_BDR);
            activatePropulsor(propulsor_BDL);
            activatePropulsor(propulsor_FUR);
            activatePropulsor(propulsor_FUL);
        }

        if (Vector3.Dot(Vector3.down, direction) > 0)
        {
            activatePropulsor(propulsor_BUR);
            activatePropulsor(propulsor_BUL);
            activatePropulsor(propulsor_FDR);
            activatePropulsor(propulsor_FDL);
        }

        if (Vector3.Dot(Vector3.right, direction) > 0)
        {
            activatePropulsor(propulsor_BUR);
            activatePropulsor(propulsor_BDR);
            activatePropulsor(propulsor_FUL);
            activatePropulsor(propulsor_FDL);
        }

        if (Vector3.Dot(Vector3.left, direction) > 0)
        {
            activatePropulsor(propulsor_BUL);
            activatePropulsor(propulsor_BDL);
            activatePropulsor(propulsor_FUR);
            activatePropulsor(propulsor_FDR);
        }
    }

    private void activatePropulsor(GameObject propulsor)
    {
        propulsor.SetActive(true);
        StartCoroutine(HideParticuleAfterSecond(propulsor));
    }

    private IEnumerator HideParticuleAfterSecond(GameObject propulsor)
    {
        yield return new WaitForSeconds(1);
        propulsor.SetActive(false);
    }
}
