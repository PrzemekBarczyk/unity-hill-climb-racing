using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Fuel : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";

    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(playerTag))
		{
            gameManager.Refuel();
            Destroy(gameObject);
		}
	}
}
