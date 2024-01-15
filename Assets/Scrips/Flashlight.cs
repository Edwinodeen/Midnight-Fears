using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            flashlight.SetActive(!flashlight.activeSelf);
        }
    }
}
