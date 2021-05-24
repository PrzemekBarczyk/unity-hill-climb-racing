using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Death : MonoBehaviour
{
    [SerializeField] string groundTag = "Ground";
	[SerializeField] UnityEvent OnPlayerDeath;

	SceneManager sceneManager;

	void Start()
	{
		sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag(groundTag)) StartCoroutine(Die());
	}

	IEnumerator Die()
	{
		OnPlayerDeath.Invoke();
		yield return new WaitForSeconds(2f);
		sceneManager.ResetLevel();
	}
}
