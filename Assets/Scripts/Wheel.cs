using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Wheel : MonoBehaviour
{
    enum State { Moves, Braking, Idle};
    State state = State.Idle;

    [Header("Required components")]
    [SerializeField] WheelJoint2D wheelJoint;

    [SerializeField] ParticleSystem dirtParticles;

    [Header("Speed and power")]
    [SerializeField] float maxDriveSpeed = 2000f;
    [SerializeField] float power = 10000f;

    [SerializeField] string groundTag = "Ground";

    bool onGround;

    void Update()
    {
        HandleParticles();
    }

    void HandleParticles()
	{
        if (state == State.Idle || !OnGround()) { dirtParticles.Stop(); return; }
        else if (OnGround()) dirtParticles.Play();

		var velocityOverLifetime = dirtParticles.velocityOverLifetime;
		if (state == State.Moves)
		{
            if (wheelJoint.motor.motorSpeed < 0) velocityOverLifetime.xMultiplier = -7f;
            else if (wheelJoint.motor.motorSpeed > 0) velocityOverLifetime.xMultiplier = 7f;
        }
		else if (state == State.Braking) velocityOverLifetime.xMultiplier = 7f;
	}

    public void Move(float input)
	{
        state = State.Moves;
        wheelJoint.useMotor = true;
        wheelJoint.motor = new JointMotor2D { motorSpeed = input * maxDriveSpeed, maxMotorTorque = power };
    }

    public void Stop()
	{
        state = State.Braking;
        wheelJoint.useMotor = true;
        wheelJoint.motor = new JointMotor2D { motorSpeed = 0f, maxMotorTorque = power };
    }

    public void Idle()
	{
        state = State.Idle;
        wheelJoint.useMotor = false;
    }

    public bool OnGround()
	{
        return onGround;
	}

    public float GetMaxSpeed()
	{
        return maxDriveSpeed;
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
