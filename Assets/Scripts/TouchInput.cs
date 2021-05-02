using UnityEngine;

public class TouchInput : MonoBehaviour
{
	[SerializeField] TouchDetector brakeButton;
	[SerializeField] TouchDetector gasButton;

	static float brakeInput;
	static float gasInput;

	void Update()
	{
		if (brakeButton.IsTouched()) brakeInput = 1f;
		else brakeInput = 0f;

		if (gasButton.IsTouched()) gasInput = 1f;
		else gasInput = 0f;
	}

	public static float GetBrakeInput()
	{
		return brakeInput;
	}

	public static float GetGasInput()
	{
		return gasInput;
	}
}
