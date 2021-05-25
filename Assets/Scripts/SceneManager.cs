using System.Collections;
using UnityEngine;
using sm = UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
	[SerializeField] Animation transition;
	[SerializeField] float transitionTime = 0.1f;

	public void ResetLevel()
	{
		int currentSceneIndex = sm.SceneManager.GetActiveScene().buildIndex;
		StartCoroutine(LoadScene(currentSceneIndex));
	}

	public void PreviousScene()
	{
		int previousSceneIndex = sm.SceneManager.GetActiveScene().buildIndex - 1;
		StartCoroutine(LoadScene(previousSceneIndex));
	}

	public void NextScene()
	{
		int nextSceneIndex = sm.SceneManager.GetActiveScene().buildIndex + 1;
		StartCoroutine(LoadScene(nextSceneIndex));
	}

	public IEnumerator LoadScene(int sceneIndex)
	{
		transition.PlayQueued("Fade_Start");
		yield return new WaitForSeconds(transitionTime);
		sm.SceneManager.LoadScene(sceneIndex);
	}
}
