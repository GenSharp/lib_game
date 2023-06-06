using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{

    public Transform target;
    public float rotationSpeed;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.position + offset;
    }

    void LateUpdate()
    {
        transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);
        transform.LookAt(target.position);
    }
}