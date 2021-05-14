using UnityEngine;

public static class ValueDamper
{
	public static float Damp(float current, float target, float smoothTime)
	{
		float currentVelocity = 0f;
		return Mathf.SmoothDamp(current, target, ref currentVelocity, smoothTime);
	}
}
