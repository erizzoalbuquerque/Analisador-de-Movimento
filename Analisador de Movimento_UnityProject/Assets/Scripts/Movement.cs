using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour, IResetable
{
    public enum MovementType
    {
        Linear,
        Sin
    }

    public AnalysisTime timer;

    public Vector2 startVelocity = Vector3.zero;
    public float gain = 1f;
    public float period = 1f;

    public MovementType movementType = MovementType.Linear;

    Rigidbody rb;
    Vector3 startPosition;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        startPosition = transform.position;

        Reset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 accel;

        accel = CalculateAcceleration();
        
        rb.AddForce(rb.mass * accel);
    }

    Vector3 CalculateAcceleration()
    {
        float accelX = 0f;
        float accelY = 0f;
        float accelZ = 0f;

        switch (movementType)
        {
            case MovementType.Linear:
                {
                    accelY = gain;
                    break;
                }
            case MovementType.Sin:
                {
                    accelY = gain * Mathf.Sin(timer.TimeSinceLastReset / period * Mathf.PI * 2f);
                    break;
                }
            default:
                {
                    accelY = 0;
                    break;
                }


        }

        return new Vector3(accelX, accelY, accelZ);
    }

    public void Reset()
    {
        rb.MovePosition(startPosition);
        rb.velocity = startVelocity;
    }
}
