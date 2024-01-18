using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;
    [Range(0.1f, 0.5f)]
    public float volumeChangeMultiplier = 0.2f;
    public float pitchChangeMultiplier = 0.2f;
    float timer;

    void Start()
    {
        source = GetComponent<AudioSource>(); //referens till audiosourcen. - Ludvig
    }

    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.volume = Random.Range(1 - volumeChangeMultiplier, 1);
            source.PlayOneShot(source.clip);
            source.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier);

            timer = Random.Range(15, 50);
        }
    }
}
