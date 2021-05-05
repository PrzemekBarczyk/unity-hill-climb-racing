using UnityEngine;
using sm = UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void ResetLevel()
	{
		sm.SceneManager.LoadScene(sm.SceneManager.GetActiveScene().buildIndex);
	}
}
