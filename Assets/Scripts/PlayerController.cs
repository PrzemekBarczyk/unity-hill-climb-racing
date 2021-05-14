using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(WheelJoint2D))]
[RequireComponent(typeof(WheelJoint2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Required components")]
    [SerializeField] Rigidbody2D carRigidbody;

    [SerializeField] Wheel driveWheel;
    [SerializeField] Wheel secondWheel;

    [Header("Rotation")]
    [SerializeField] float onAirRotationSpeed = 8f;
    [SerializeField] float onGroundRotationSpeed = 1f;

    float brakeInput;
    float gasInput;
    float finalInput;

    float brakeRawInput;
    float gasRawInput;
    float finalRawInput;

    GameManager gameManager;

	void Start()
	{
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

	void Update()
    {
        GetInput();
    }

	void FixedUpdate()
	{
        if (brakeRawInput == 1f && carRigidbody.velocity.x > 3f)
        {
            Stop();
        }
        else if (brakeRawInput == 0f && gasRawInput == 0f)
        {
            Idle();
        }
		else if (gameManager.IsFuel())
		{
			Move();
			Rotate();
		}
	}

    void GetInput()
	{
        brakeInput = TouchInput.GetDampedBrakeInput();
        gasInput = -TouchInput.GetDampedGasInput();
        brakeRawInput = TouchInput.GetRawBrakeInput();
        gasRawInput = -TouchInput.GetRawGasInput();

        finalInput = brakeRawInput > 0f ? brakeInput : gasInput;
        finalRawInput = brakeRawInput > 0f ? brakeRawInput : gasRawInput;
    }

    void Idle()
    {
        driveWheel.Idle();
        secondWheel.Idle();
    }

    void Stop()
	{
        driveWheel.Stop();
        secondWheel.Stop();
	}

    void Move()
    {
        driveWheel.Move(finalInput);
        secondWheel.Idle();
    }

    void Rotate()
	{
		if (!OnGround()) carRigidbody.AddTorque(-finalRawInput * onAirRotationSpeed);
		else carRigidbody.AddTorque(-finalRawInput * onGroundRotationSpeed);
	}

    bool OnGround()
	{
        return driveWheel.OnGround() || secondWheel.OnGround();
	}
}
