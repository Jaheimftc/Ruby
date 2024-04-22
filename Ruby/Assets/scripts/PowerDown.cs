using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PowerDown : MonoBehaviour
{
    public RubyController powerdown;

    public AudioClip zap;
    public AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            powerdown.speed = 1.0f;
            audioSource.clip = zap;
            audioSource.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlaySound(zap);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
