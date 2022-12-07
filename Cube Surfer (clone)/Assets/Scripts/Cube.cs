using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    [SerializeField] private Stack stack;

    private Vector3 direction = Vector3.back;

    private bool isStack = false;

    private RaycastHit hit;

    float max_distance = 1f;

    void Start()
    {
        stack = GameObject.FindObjectOfType<Stack>();
    }

    void FixedUpdate()
    {
        SetBoxcast();
    }

    private void SetBoxcast()
    {
        if (Physics.BoxCast(transform.position, transform.lossyScale / 101, direction, out hit, transform.rotation, max_distance))
        {
            if (!isStack)
            {
                isStack = true;
                stack.IncCubeStack(gameObject);
                SetDirection();
            }
        }
    }

    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}
