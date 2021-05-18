using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animation))]
public class LowFuelIndicator : MonoBehaviour
{
    [SerializeField][Range(0f, 1f)] float maxWarningLevel = 0.2f;

    Image image;
    Animation blinkingAnimation;

    GameManager gameManger;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        blinkingAnimation = GetComponent<Animation>();
        gameManger = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManger.GetFuelLevel() <= maxWarningLevel && gameManger.GetFuelLevel() > 0f) Blink(true);
        else Blink(false);
    }

    void Blink(bool blink)
    {
        Color color = image.color;
        if (blink)
		{
            color.a = 1f;
            blinkingAnimation.Play();
		}
        else
		{
            color.a = 0f;
            blinkingAnimation.Stop();
		}
        image.color = color;
    }
}
