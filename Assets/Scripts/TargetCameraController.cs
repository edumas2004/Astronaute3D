using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCameraController : MonoBehaviour
{
    public float distanceMin = 30;
    public float distanceMax = 100;
    public float zoomSpeed = 1000;

    private GameObject player;
    private Vector3 playerPosition;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform.position;
        transform.position = playerPosition + new Vector3(0, 0, -distanceMax);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPosition = player.transform.position;

        // Read gamer input for zoom
        float input_z = Input.GetAxis("Zoom");

        // Compute new target camera location
        targetPosition = new Vector3(playerPosition.x, playerPosition.y, transform.position.z + input_z * zoomSpeed * Time.deltaTime);

        // Limit to distance range allowed
        if (targetPosition.z > -distanceMin)
        {
            targetPosition.z = -distanceMin;
        } else if (targetPosition.z < -distanceMax)
        {
            targetPosition.z = -distanceMax;
        }

        // and go
        transform.position = targetPosition;
    }
}
