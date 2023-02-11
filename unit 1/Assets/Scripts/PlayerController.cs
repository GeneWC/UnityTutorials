using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private float turnSpeed = 25;
    public float horizontalInput;
    public float forwardInput;
    public Camera tpCam;
    public Camera fpCam;
    public KeyCode switchKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);

        if (Input.GetKeyDown(switchKey))
        {
            tpCam.enabled = !tpCam.enabled;
            fpCam.enabled = !fpCam.enabled;

        }
    }
}
