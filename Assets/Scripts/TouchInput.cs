using UnityEngine;

public class TouchInput : MonoBehaviour
{
	[SerializeField] TouchDetector brakeButton;
	[SerializeField] TouchDetector gasButton;

	[SerializeField] float brakeSmoothTime = 0.01f;
	[SerializeField] float gasSmoothTime = 0.05f;

	static float rawBrakeInput;
	static float rawGasInput;

	static float dampedBrakeInput;
	static float dampedGasInput;

	void Update()
	{
		if (brakeButton.IsTouched())
		{
			rawBrakeInput = 1f;
			dampedBrakeInput = ValueDamper.Damp(dampedBrakeInput, rawBrakeInput, brakeSmoothTime);
		}
		else
		{
			rawBrakeInput = 0f;
			dampedBrakeInput = rawBrakeInput;
		}

		if (gasButton.IsTouched())
		{
			rawGasInput = 1f;
			dampedGasInput = ValueDamper.Damp(dampedGasInput, rawGasInput, gasSmoothTime);
		}
		else
		{
			rawGasInput = 0f;
			dampedGasInput = rawGasInput;
		}
	}

	public static float GetDampedBrakeInput()
	{
		return dampedBrakeInput;
	}

	public static float GetDampedGasInput()
	{
		return dampedGasInput;
	}

	public static float GetRawBrakeInput()
	{
		return rawBrakeInput;
	}

	public static float GetRawGasInput()
	{
		return rawGasInput;
	}
}
