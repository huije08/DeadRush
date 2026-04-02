using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailTrigger : MonoBehaviour
{
    public RailManager manager;

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            manager.SpawnRail();
        }
    }
}