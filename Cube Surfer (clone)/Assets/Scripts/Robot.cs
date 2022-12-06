using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float forwardMs;
    [SerializeField] private float horizontalMs;
    [SerializeField] private float limit;

    private float newPositionX;

    private float horizontalValue;

    public float HorizontalValue
    {
        get { return horizontalValue; }
    }

    void Update()
    {
        HandleHeroHorizontalInput();
    }
    void FixedUpdate()
    {
        SetRobotForwardMovement();
        SetRobotHorizontalMovement();
    }

    private void SetRobotForwardMovement()
    {
        transform.Translate(Vector3.forward * forwardMs * Time.fixedDeltaTime);
    }

    private void SetRobotHorizontalMovement()
    {
        newPositionX = transform.position.x + HorizontalValue * horizontalMs * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -limit, limit);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }

    private void HandleHeroHorizontalInput()
    {
        if (Input.GetMouseButton(0))
        {
            horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizontalValue = 0;
        }
    }
}
