using UnityEngine;

public static class ValueDamper
{
	public static float Damp(float current, float target, float smoothTime)
	{
		Vector2 currentVelocity = Vector2.zero;
		float dampedValue = Vector2.SmoothDamp(new Vector2(current, 0f), new Vector2(target, 0f), ref currentVelocity, smoothTime).x;
		return dampedValue;
	}
}
