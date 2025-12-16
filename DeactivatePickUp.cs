using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePickUp : MonoBehaviour
{
    // Called when the object becomes active
    void Start()
    {
        // Randomly deactivate the pickup between 3 and 6 seconds
        Invoke("Deactivate", Random.Range(3f, 6f));
    }

    // Deactivate this pickup object
    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
