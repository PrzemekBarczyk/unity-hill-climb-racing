using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CoinsAmount : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("coins").ToString();
    }
}
