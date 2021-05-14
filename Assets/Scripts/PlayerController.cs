using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(WheelJoint2D))]
[RequireComponent(typeof(WheelJoint2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Required components")]
    [SerializeField] Rigidbody2D carRigidbody;
    [SerializeField] WheelJoint2D driveWheelJoint;
    [SerializeField] CircleCollider2D backWheelCollider;
    [SerializeField] CircleCollider2D frontWheelCollider;

    [Header("Required layers")]
    [SerializeField] LayerMask groundLayer;

    [Header("Speed and power")]
    [SerializeField] float maxDriveSpeed = 2000f;
    [SerializeField] float power = 10000f;

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
        driveWheelJoint.useMotor = false;
    }

    void Stop()
	{
        driveWheelJoint.useMotor = true;
        driveWheelJoint.motor = new JointMotor2D { motorSpeed = 0f, maxMotorTorque = power };
    }

    void Move()
    {
        driveWheelJoint.useMotor = true;
        driveWheelJoint.motor = new JointMotor2D { motorSpeed = finalInput * maxDriveSpeed, maxMotorTorque = power };
    }

    void Rotate()
	{
		if (!OnGround()) carRigidbody.AddTorque(-finalRawInput * onAirRotationSpeed);
		else carRigidbody.AddTorque(-finalRawInput * onGroundRotationSpeed);
	}

    bool OnGround()
	{
        return backWheelCollider.IsTouchingLayers(groundLayer) || frontWheelCollider.IsTouchingLayers(groundLayer);
	}
}
