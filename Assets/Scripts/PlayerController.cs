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
        if (brakeInput == 0 && gasInput == 0)
		{
            StopMotor();
		}
		else
		{
            RunMotor();
            Rotate();
        }
	}

    void GetInput()
	{
        brakeInput = TouchInput.GetDampedBrakeInput();
        gasInput = -TouchInput.GetDampedGasInput();

        if (brakeInput > 0f) finalInput = brakeInput;
        else finalInput = gasInput;
    }

    void RunMotor()
	{
        if (gameManager.IsFuel())
		{
            driveWheelJoint.useMotor = true;
            driveWheelJoint.motor = new JointMotor2D { motorSpeed = finalInput * maxDriveSpeed, maxMotorTorque = power }; 
        }
    }

    void StopMotor()
	{
        driveWheelJoint.useMotor = false;
    }

    void Rotate()
	{
		if (!OnGround()) carRigidbody.AddTorque(-finalInput * onAirRotationSpeed);
		else carRigidbody.AddTorque(-finalInput * onGroundRotationSpeed);
	}

    bool OnGround()
	{
        return backWheelCollider.IsTouchingLayers(groundLayer) || frontWheelCollider.IsTouchingLayers(groundLayer);
	}
}
