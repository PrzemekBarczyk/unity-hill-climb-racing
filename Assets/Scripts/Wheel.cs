using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Wheel : MonoBehaviour
{
    [Header("Required components")]
    [SerializeField] WheelJoint2D wheelJoint;

    [Header("Speed and power")]
    [SerializeField] float maxDriveSpeed = 2000f;
    [SerializeField] float power = 10000f;

    [SerializeField] string groundTag = "Ground";

    bool onGround;

    public void Move(float input)
	{
        wheelJoint.useMotor = true;
        wheelJoint.motor = new JointMotor2D { motorSpeed = input * maxDriveSpeed, maxMotorTorque = power };
    }

    public void Stop()
	{
        wheelJoint.useMotor = true;
        wheelJoint.motor = new JointMotor2D { motorSpeed = 0f, maxMotorTorque = power };
    }

    public void Idle()
	{
        wheelJoint.useMotor = false;
    }

    public bool OnGround()
	{
        return onGround;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag(groundTag))
		{
            onGround = true;
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
        if (collision.transform.CompareTag(groundTag))
        {
            onGround = false;
        }
    }
}
