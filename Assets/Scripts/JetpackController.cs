using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackController : MonoBehaviour, IMovementObserver
{
    public AbstractMovementController movementController;

    public GameObject propulsor_BUR; 
    public GameObject propulsor_BUL;
    public GameObject propulsor_BDR;
    public GameObject propulsor_BDL;
    public GameObject propulsor_FUR;
    public GameObject propulsor_FUL;
    public GameObject propulsor_FDR;
    public GameObject propulsor_FDL;

    public HashSet<GameObject> propulsorToActivate = new HashSet<GameObject>();

    private void Awake()
    {
        //movementController.AddObserver((IMovementObserver)this);
    }

    public void NotifyMovement(Vector3 direction)
    {
        Debug.Log("JetpackController Activate " + Vector3.Dot(Vector3.up, direction));

        propulsorToActivate.Clear();

        if (Vector3.Dot(Vector3.up, direction) > 0)
        {
            propulsorToActivate.Add(propulsor_BDR);
            propulsorToActivate.Add(propulsor_BDR);
            propulsorToActivate.Add(propulsor_BDL);
            propulsorToActivate.Add(propulsor_FUR);
            propulsorToActivate.Add(propulsor_FUL);
        }

        if (Vector3.Dot(Vector3.down, direction) > 0)
        {
            propulsorToActivate.Add(propulsor_BUR);
            propulsorToActivate.Add(propulsor_BUL);
            propulsorToActivate.Add(propulsor_FDR);
            propulsorToActivate.Add(propulsor_FDL);
        }

        if (Vector3.Dot(Vector3.right, direction) > 0)
        {
            propulsorToActivate.Add(propulsor_BUR);
            propulsorToActivate.Add(propulsor_BDR);
            propulsorToActivate.Add(propulsor_FUL);
            propulsorToActivate.Add(propulsor_FDL);
        }

        if (Vector3.Dot(Vector3.left, direction) > 0)
        {
            propulsorToActivate.Add(propulsor_BUL);
            propulsorToActivate.Add(propulsor_BDL);
            propulsorToActivate.Add(propulsor_FUR);
            propulsorToActivate.Add(propulsor_FDR);
        }

        foreach(GameObject propulsor in propulsorToActivate)
        {
            activatePropulsor(propulsor);
        }
    }

    private void activatePropulsor(GameObject propulsor)
    {
        propulsor.SetActive(true);
        StartCoroutine(HideParticuleAfterSecond(propulsor));
    }

    private IEnumerator HideParticuleAfterSecond(GameObject propulsor)
    {
        yield return new WaitForSeconds(.5f);
        propulsor.SetActive(false);
    }
}
