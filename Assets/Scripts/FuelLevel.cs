using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelLevel : MonoBehaviour
{
    [SerializeField] Text distanceToFuel;
    [SerializeField] Transform car;
    [SerializeField] List<Transform> fuelPickups = new List<Transform>();

    void Update()
    {
        if (fuelPickups.Count > 0) distanceToFuel.text = Mathf.RoundToInt(fuelPickups[0].position.x - car.position.x).ToString();
    }

    public void RemoveFuelFromList(Transform pickedFuel)
    {
        fuelPickups.Remove(pickedFuel);
    }
}
