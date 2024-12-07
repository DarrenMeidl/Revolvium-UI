using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTween : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 10, 0); // Rotation speed in degrees per second
    void Update()
    {
        // Rotate the object based on rotation speed and time
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
