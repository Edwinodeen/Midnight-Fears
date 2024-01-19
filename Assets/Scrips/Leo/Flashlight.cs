using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour ///Leos kod
{
    public GameObject flashlight;

    private void Start()
    {
        flashlight = GameObject.FindGameObjectWithTag("Flashlight");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            flashlight.SetActive(!flashlight.activeSelf);
        }
    }
}
