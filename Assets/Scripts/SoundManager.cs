using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviourSingleton<SoundManager>
{
    AudioSource audioSource;
    [SerializeField] AudioClip ballSound;
    [SerializeField] AudioClip successSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    public void BallSound()
    {
        audioSource.PlayOneShot(ballSound);
    }

    public void SuccessSound()
    {
        audioSource.PlayOneShot(successSound);
    }
}
