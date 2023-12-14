using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpPlayerTag : MonoBehaviour
{
    public DoorControllerPlayerTag DoorToUnlock;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            DoorToUnlock.Unlock();
        }
    }
}
