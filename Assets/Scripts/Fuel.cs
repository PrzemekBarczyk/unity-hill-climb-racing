using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Fuel : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
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
            gameManager.Refuel();
            Destroy(gameObject, 2f);
		}
	}
}
