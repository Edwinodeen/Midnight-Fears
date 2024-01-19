using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Name of the scene to switch to
    public string targetSceneName;

    Camera cam;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    // Check for mouse click on the GameObject
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits this GameObject
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Change to the target scene
                SceneManager.LoadScene(targetSceneName);
            }
        }
    }
}
