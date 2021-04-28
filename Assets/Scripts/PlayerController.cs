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

    float input;

    void Update()
    {
        GetInput();
    }

	void FixedUpdate()
	{
        if (input == 0)
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
        input = Input.GetAxis("Horizontal");
    }

    void RunMotor()
	{
        driveWheelJoint.useMotor = true;
        driveWheelJoint.motor = new JointMotor2D { motorSpeed = -input * maxDriveSpeed, maxMotorTorque = power }; ;
    }

    void StopMotor()
	{
        driveWheelJoint.useMotor = false;
    }

    void Rotate()
	{
		if (!OnGround()) carRigidbody.AddTorque(input * onAirRotationSpeed);
		else carRigidbody.AddTorque(input * onGroundRotationSpeed);
	}

    bool OnGround()
	{
        return backWheelCollider.IsTouchingLayers(groundLayer) || frontWheelCollider.IsTouchingLayers(groundLayer);
	}
}
