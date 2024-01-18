using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour ///Leos kod
{
    PlayerMovement movementCode;
    public Transform cameraPosition;

    private void Start()
    {
        movementCode = FindObjectOfType<PlayerMovement>();
        cameraPosition = movementCode.transform.GetChild(1);
    }

    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
