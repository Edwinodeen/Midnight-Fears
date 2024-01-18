using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour ///Leos kod
{
    PlayerMovement movementCode;

    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        movementCode = FindObjectOfType<PlayerMovement>();
        orientation = movementCode.transform.GetChild(0).transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;  ///Fixa detta
    }

    private void Update()
    {
        //F�r mus inputten
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotera camera och riktning
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
