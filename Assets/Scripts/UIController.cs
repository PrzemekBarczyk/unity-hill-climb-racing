using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Fuel")]
    [SerializeField] Slider fuelLevelSlider;

    [Header("Score")]
    [SerializeField] Text scoreText;

    [Header("Pedals")]
    [SerializeField] GameObject brakeNormalImage;
    [SerializeField] GameObject brakePressedImage;
    [SerializeField] GameObject gasNormalImage;
    [SerializeField] GameObject gasPressedImage;

	void Update()
	{
        float brakeInput = TouchInput.GetRawBrakeInput();
        float gasInput = TouchInput.GetRawGasInput();

        if (brakeInput > 0) DisplayBrakePressed(true);
        else DisplayBrakePressed(false);
        if (gasInput > 0) DisplayGasPressed(true);
        else DisplayGasPressed(false);
	}

    public void UpdateFuelLevel(float newLevel)
	{
        fuelLevelSlider.value = newLevel;
	}

    public void UpdateScore(string newScore)
	{
        scoreText.text = newScore;
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
