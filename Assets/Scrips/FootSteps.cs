 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioSource footstepssound, sprintsound;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
        {
            footstepssound.enabled = true;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                footstepssound.enabled = false;
                sprintsound.enabled = true;
            }
            else
            {
                footstepssound.enabled = true;
                sprintsound.enabled = false;
            }
        }
        else
        {
            footstepssound.enabled = false;
            sprintsound.enabled = false;
        }
    }
}
