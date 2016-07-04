using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class UnityChanSoundPlayer : MonoBehaviour {
    public AudioClip[] clips = new AudioClip[4];
    private AudioSource audioSource;
    private bool running = false;
    void Start() {
        audioSource = GetComponent<AudioSource>();

        running = true;
        audioSource.Stop();
    }

    public void Play(int clipnum) {
        audioSource.Stop();
        audioSource.clip = clips[clipnum];
        audioSource.Play();
    }

}