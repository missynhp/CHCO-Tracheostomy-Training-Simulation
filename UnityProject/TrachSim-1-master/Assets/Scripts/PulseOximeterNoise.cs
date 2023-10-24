using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseOximeterNoise : MonoBehaviour
{
    // The audio source the sound will originate from.
    public AudioSource audioSource;
    // The audio file being played.
    public AudioClip clip;
    // Controls the volume relative to the original sound sources volume.
    public float volume=0.5f;
    // Controls the pitch of the beep relative to the audiosources original pitch.
    public float pitch=0.5f;
    // Every int value is another second of waiting.
    public float frequency = 1.0f;

    // The internal timer for repititions. 
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Sets pitch for oximeter
        audioSource.pitch = pitch;
    }

    // Update is called once per frame
    void Update()
    {
        // Intermittenly plays the the provided audio file, frequency number of times per second.
        timer += Time.deltaTime;
        if( timer > frequency ){
            timer  = 0;
            audioSource.PlayOneShot(clip, volume);
        }
    }
}