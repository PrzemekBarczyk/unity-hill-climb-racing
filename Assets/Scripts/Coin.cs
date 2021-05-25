using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
	[SerializeField] string playerTag = "Player";
	[SerializeField] int value = 5;
	[SerializeField] UnityEvent OnPickupEvent;

	GameManager gameManager;

	void Start()
	{
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(playerTag))
		{
			OnPickupEvent.Invoke();
			gameManager.AddCoins(value);
			Destroy(gameObject, 2f);
		}
	}
}
