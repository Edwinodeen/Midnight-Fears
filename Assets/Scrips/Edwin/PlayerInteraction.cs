using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{

    public Camera mainCam;

    public float interactionDistance = 2f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;
    public LayerMask mask;

    Points score;

    private void Start()
    {
        score = FindObjectOfType<Points>();
    }

    private void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * interactionDistance);
        bool hitsomething = false;

        if (Physics.Raycast(ray, out hit, interactionDistance, mask))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                hitsomething = true;
                interactionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }

        interactionUI.SetActive(hitsomething);

    }

}
