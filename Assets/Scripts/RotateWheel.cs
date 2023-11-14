using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 30f; // Adjust the speed of rotation as needed
    [SerializeField] bool turnRotateDirection = false;
    [SerializeField] bool useVectorRight = false;


    // Update is called once per frame
    void Update()
    {
        if (useVectorRight)
        {
            transform.Rotate(-Vector3.right, rotationSpeed * Time.deltaTime);
        }
        else
        {
            if (turnRotateDirection)
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(-Vector3.up, rotationSpeed * Time.deltaTime);
            }
        }
     
    }
}
