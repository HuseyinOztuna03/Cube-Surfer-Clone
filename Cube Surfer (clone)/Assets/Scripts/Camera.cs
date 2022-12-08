using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform robot;

    private Vector3 offset, newPos;

    [SerializeField] private float lerpValue;
   
    void Start()
    {
        offset = transform.position - robot.position;
    }
    private void LateUpdate()
    {
        SetCamera();
    }

    private void SetCamera()
    {
        newPos = Vector3.Lerp(transform.position, new Vector3(0f, robot.position.y, robot.position.z) + offset, lerpValue * Time.deltaTime);
        transform.position = newPos;
    }
}
