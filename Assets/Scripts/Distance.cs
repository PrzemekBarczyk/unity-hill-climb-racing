using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Distance : MonoBehaviour
{
    [SerializeField] Transform car;

    Text text;

    int currentDistance;
    int levelDistance = 100;
    int bestDistance;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        currentDistance = Mathf.RoundToInt(car.position.x - Vector2.zero.x);
        if (currentDistance > levelDistance) levelDistance += 100;
        text.text = currentDistance.ToString() + "m / " + levelDistance.ToString() + "m (best: " + bestDistance.ToString() + ")";
    }
}
