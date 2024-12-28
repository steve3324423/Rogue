using System;
using UnityEngine;

public class House : MonoBehaviour
{
    public event Action WentPremises;
    public event Action ExitPremises;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
            WentPremises?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
            ExitPremises?.Invoke();
    }
}
