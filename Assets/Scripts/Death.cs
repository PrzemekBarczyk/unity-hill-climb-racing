using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    [SerializeField] string groundTag = "Ground";
	[SerializeField] UnityEvent OnPlayerDeath;

	SceneManager sceneManager;

	void Start()
	{
		sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(groundTag)) Die();
	}

	void Die()
	{
		OnPlayerDeath.Invoke();
		sceneManager.ResetLevel();
	}
}
