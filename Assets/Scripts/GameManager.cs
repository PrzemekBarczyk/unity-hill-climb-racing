using UnityEngine;

public class GameManager : MonoBehaviour
{
	UIController uiController;

    int score;

	void Start()
	{
		uiController = GameObject.Find("UI").GetComponent<UIController>();
		uiController.UpdateScore(score.ToString());
	}

	public void AddScore(int scoreToAdd)
	{
		score += scoreToAdd;
		uiController.UpdateScore(score.ToString());
	}
}
