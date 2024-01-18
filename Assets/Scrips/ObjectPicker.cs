using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    // The range for the raycast
    public float interactRange = 2f;

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits an object within the interact range
            if (Physics.Raycast(ray, out hit, interactRange))
            {
                // Check if the object has a component that can be picked up (for example, a Rigidbody)
                PickableObject pickableObject = hit.collider.GetComponent<PickableObject>();

                if (pickableObject != null)
                {
                    // Perform the pick-up action
                    pickableObject.PickUp();

                    // You can optionally do something with the picked object, like destroying it
                    // Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
