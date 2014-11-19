using UnityEngine;
using System.Collections;

public class soundManager : MonoBehaviour {

	public AudioClip wet;
	public AudioClip burn;
	public AudioClip laugh;
	public AudioClip afraid;
	public AudioClip go;

	private AudioSource source;
	
	void Awake()
	{
		source = GetComponent<AudioSource> ();
	}
	
	void playBurn()
	{
		source.clip = burn;
		source.Play();
	}
	
	void playWet()
	{
		source.clip = wet;
		source.Play();
	}

	void playLaugh()
	{
		source.clip = laugh;
		source.Play();
	}
	
	void playAfraid()
	{
		source.clip = afraid;
		source.Play();
	}
	
	void playGo()
	{
		source.clip = go;
		source.Play();
	}
}