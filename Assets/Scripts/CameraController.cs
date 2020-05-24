using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float speed = 1f;
    private Transform targetCamera;

    private Vector3 to;

    // Start is called before the first frame update
    void Start()
    {
        targetCamera = GameObject.Find("Target Camera").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Se diriger vers l'emplacement cible de la camera
        transform.position = Vector3.Lerp(transform.position, targetCamera.position, speed * Time.deltaTime);
    }
}
