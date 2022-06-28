using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour, IResetable
{
    public enum MovementType
    {
        Linear,
        Sin
    }

    [SerializeField] AnalysisTime timer;
                     
    [SerializeField] Vector2 startVelocity = Vector3.zero;
    [SerializeField] float gain = 1f;
    [SerializeField] float period = 1f;
                     
    [SerializeField] MovementType movementType = MovementType.Linear;

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
        rb.transform.position = startPosition; //necessary because rb.MovePosition only moves on next frame.
        rb.velocity = startVelocity;
    }

    public void ChangeMovement(int movementTypeId)
    {
        print("Changing Movement... " + movementTypeId);
        switch(movementTypeId)
        {
            case 0:
                {
                    movementType = MovementType.Linear;
                    break;
                }
            case 1:
                {
                    movementType = MovementType.Sin;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void ChangeGain(string value)
    {
        float newValue;

        if (float.TryParse(value,out newValue))
        {
            gain = newValue;
            print("Value Changed Successfully");
        }
    }

    public void ChangePeriod(string value)
    {
        float newValue;

        if (float.TryParse(value, out newValue))
        {
            period = newValue;
        }
    }
}
