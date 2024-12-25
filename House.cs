using System;
using UnityEngine;

public class House : MonoBehaviour
{
    public event Action WentHouse;
    public event Action ExitHouse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
            WentHouse?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
            ExitHouse?.Invoke();
    }
}
