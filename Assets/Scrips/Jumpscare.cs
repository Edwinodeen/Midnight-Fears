using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jumpscare : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject PlayerCam;
    public GameObject JumpCam;
    public GameObject FlashImg;

    void OnTriggerEnter()
    {
        Scream.Play(); // spelar jumpscare ljudet.
        JumpCam.SetActive(true); //
        PlayerCam.SetActive(false);
        FlashImg.SetActive(true);
        StartCoroutine(EndJump());

    }
    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2.03f);
        PlayerCam.SetActive(true);
        JumpCam.SetActive(false);
        FlashImg.SetActive(false);
    }
    
}