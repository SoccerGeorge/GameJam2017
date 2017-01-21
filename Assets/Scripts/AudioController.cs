using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {
	public AudioClip[] clips;
	new AudioSource audio;

	void Awake () {
		audio = GetComponent<AudioSource>();
	}

	public void PlayAudio (int index) {
		audio.clip = clips[index];
		audio.Play();
	}
}
