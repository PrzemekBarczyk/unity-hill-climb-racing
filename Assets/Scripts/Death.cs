using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] string groundTag = "Ground";

	SceneManager sceneManager;

	void Start()
	{
		sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(groundTag)) sceneManager.ResetLevel();
	}
}
