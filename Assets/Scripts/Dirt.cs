using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Dirt : MonoBehaviour
{
    [SerializeField] Transform wheel;
    [SerializeField] Transform car;
    [SerializeField] ParticleSystem dirtParticles;

    Vector3 positionOffset;
    Vector3 rotationOffset;

    void Start()
    {
        positionOffset = transform.position - wheel.position;
        rotationOffset = transform.eulerAngles - car.eulerAngles;
    }

    void Update()
    {
        FollowWheel();
    }

    void FollowWheel()
	{
        transform.position = wheel.position + positionOffset;
        transform.eulerAngles = car.eulerAngles + rotationOffset;
	}
}
