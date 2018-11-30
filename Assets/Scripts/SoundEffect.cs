using UnityEngine;
using System.Collections;

public class SoundEffect : MonoBehaviour {

    private float lifeTime;
    public AudioClip audioClip;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {

        audioSource = GetComponent<AudioSource>();
        lifeTime = audioClip.length;
        audioSource.clip = audioClip;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {

        Destroy(gameObject, lifeTime);
	}
}
