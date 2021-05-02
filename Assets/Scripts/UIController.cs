using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject brakeNormalImage;
    [SerializeField] GameObject brakePressedImage;
    [SerializeField] GameObject gasNormalImage;
    [SerializeField] GameObject gasPressedImage;

	void Update()
	{
        float brakeInput = TouchInput.GetBrakeInput();
        float gasInput = TouchInput.GetGasInput();

        if (brakeInput > 0) DisplayBrakePressed(true);
        else DisplayBrakePressed(false);
        if (gasInput > 0) DisplayGasPressed(true);
        else DisplayGasPressed(false);
	}

	public void DisplayBrakePressed(bool isPressed)
	{
        brakeNormalImage.SetActive(!isPressed);
        brakePressedImage.SetActive(isPressed);
	}

    public void DisplayGasPressed(bool isPressed)
	{
        gasNormalImage.SetActive(!isPressed);
        gasPressedImage.SetActive(isPressed);
    }
}
