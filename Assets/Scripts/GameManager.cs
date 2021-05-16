using UnityEngine;

public class GameManager : MonoBehaviour
{
	UIController uiController;

	[SerializeField] float fuelUsage = 0.05f;
	float fuelLevel = 1f;

    int score;

	void Start()
	{
		uiController = GameObject.Find("UI").GetComponent<UIController>();
		uiController.UpdateScore(score.ToString());
	}

	void Update()
	{
		UseFuel();
	}

	void UseFuel()
	{
		fuelLevel -= fuelUsage * Time.deltaTime;
		uiController.UpdateFuelLevel(fuelLevel);
	}

	public void Refuel()
	{
		fuelLevel = 1f;
	}

	public bool IsFuel()
	{
		return fuelLevel > 0 ? true : false;
	}

	public void AddScore(int scoreToAdd)
	{
		score += scoreToAdd;
		uiController.UpdateScore(score.ToString());
	}

	public void Pause()
	{
		Time.timeScale = 0f;
	}

	public void Resume()
	{
		Time.timeScale = 1f;
	}

	public void Exit()
	{
		Application.Quit();
	}
}
