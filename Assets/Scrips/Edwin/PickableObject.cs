using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    // Method to be called when the object is picked up
    public void PickUp()
    {
        Debug.Log("Picked up: " + gameObject.name);

        // Implement any additional logic for when the object is picked up
    }
}
