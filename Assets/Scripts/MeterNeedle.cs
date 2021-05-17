using UnityEngine;

public class MeterNeedle : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    [SerializeField][Range(0f, 1f)] float multiplier = 0.5f;

    [SerializeField] float minRotation = 135f;
    [SerializeField] float maxRotation = -135f;

    void Update()
    {
        RotateNeedle(Mathf.Abs(playerController.GetInput()));
    }

    public void RotateNeedle(float percent)
	{
        percent = percent > 1f ? 1f : percent;
        percent = percent < 0f ? 0f : percent;
        transform.eulerAngles = Vector3.forward * (minRotation + percent * 2f * maxRotation * multiplier);
    }
}
