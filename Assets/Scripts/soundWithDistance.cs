using UnityEngine;
using System.Collections;

public class soundWithDistance : MonoBehaviour {
	public float dangerLimit;
	public float warningLimit;
	public GameObject firewall;
	public GameObject danger;
	public GameObject warning;

	private GameObject lenka;
	private GameObject papy;
	private AudioSource dangerSource;
	private AudioSource warningSource;

	// Use this for initialization
	void Start () {
		lenka = GameObject.FindGameObjectWithTag ("Player");
		papy = GameObject.FindGameObjectWithTag ("Papy");
		dangerSource = danger.GetComponent<AudioSource> ();
		warningSource = warning.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		float dist = Mathf.Min (lenka.transform.position.x - firewall.transform.position.x,
		                        papy.transform.position.x - firewall.transform.position.x);
		
		Debug.Log(dist);
		if (dist < dangerLimit) {
			warningSource.Stop ();
			if(!dangerSource.isPlaying)
				dangerSource.Play ();
		}else if (dist < warningLimit) {
			dangerSource.Stop ();
			if(!warningSource.isPlaying)
				warningSource.Play ();
		}else {
			dangerSource.Stop ();
			warningSource.Stop ();
		}
	}
}
