using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TouchDetector : MonoBehaviour
{
    bool isTouched;

    BoxCollider2D boxCollider2D;

	void Start()
	{
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

	void Update()
    {
        TouchDetection();
    }

    void TouchDetection()
	{
        isTouched = false;
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (boxCollider2D.OverlapPoint(Input.touches[i].position))
            {
                isTouched = true;
                break;
            }
        }
    }

    public bool IsTouched()
	{
        return isTouched;
	}
}
