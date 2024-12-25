using System;
using UnityEngine;

public class House : MonoBehaviour
{
    public event Action<bool> WentHouse;

    private void OnTriggerEnter(Collider other)
    {
        ReportEntryOrExit(other, true);
    }

    private void OnTriggerStay(Collider other)
    {
        ReportEntryOrExit(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        ReportEntryOrExit(other,false);
    }

    private void ReportEntryOrExit(Collider other,bool value)
    {
        if (other.TryGetComponent<Rogue>(out Rogue rogue))
            WentHouse?.Invoke(value);
    }
}
