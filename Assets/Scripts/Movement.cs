using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrust = 10;
    [SerializeField] float rotationAngle = 90;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }    
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationAngle);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotationAngle);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freeze Rot so we can manually rotate
        transform.Rotate(Vector3.forward, rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //Unfreeze the Rot so Physics system can take over
    }
}
