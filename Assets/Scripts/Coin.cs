using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
	[SerializeField] string playerTag = "Player";
	[SerializeField] int value = 5;

	GameManager gameManager;

	void Start()
	{
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(playerTag))
		{
			gameManager.AddScore(value);
			Destroy(gameObject);
		}
	}
}
