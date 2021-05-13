using System.Collections;
using UnityEngine;

public class PickupAnimation : MonoBehaviour
{
	[SerializeField] AnimationCurve verticalMovementCurve;
	[SerializeField] AnimationCurve disapperingCurve;

	bool started;
	float timeElapsed;
	Vector2 startPosition;
	Color currentColor;

	SpriteRenderer spriteRenderer;

	void Start()
	{
		startPosition = transform.localPosition;
		spriteRenderer = GetComponent<SpriteRenderer>();
		currentColor = spriteRenderer.color;
	}

	void Update()
	{
		if (started) timeElapsed += Time.deltaTime;
	}

	public void Play()
	{
		started = true;
		StartCoroutine(Rise());
		StartCoroutine(Disappear());
	}

	IEnumerator Rise()
	{
		while (true)
		{
			transform.localPosition = startPosition + Vector2.up * verticalMovementCurve.Evaluate(timeElapsed);
			yield return null;
		}
	}

	IEnumerator Disappear()
	{
		while (true)
		{
			currentColor.a = disapperingCurve.Evaluate(timeElapsed);
			spriteRenderer.color = currentColor;
			yield return null;
		}
	}
}
