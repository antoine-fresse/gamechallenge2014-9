using UnityEngine;
using System.Collections;

public class soundWithDistance : MonoBehaviour {
	public float warningLimit;
	public float dangerLimit;
	public GameObject firewall;

	private GameObject lenka;
	private GameObject papy;
	public AudioSource warningSource;
	public AudioSource dangerSource;

	// Use this for initialization
	void Start () {
		lenka = GameObject.FindGameObjectWithTag ("Player");
		papy = GameObject.FindGameObjectWithTag ("Papy");
	}

	// Update is called once per frame
	void Update () {
        if(!lenka)
            lenka = GameObject.FindGameObjectWithTag("Player");
        if (!papy)
            papy = GameObject.FindGameObjectWithTag("Papy");
	    if (!lenka || !papy)
	        return;
		float dist = Mathf.Min (lenka.transform.position.x - firewall.transform.position.x,
		                        papy.transform.position.x - firewall.transform.position.x);
		
		//Debug.Log(dist);
		if (dist < dangerLimit) {
			dangerSource.mute = false;
		}else if (dist < warningLimit) {
			warningSource.mute = false;
			dangerSource.mute = true;
		}else {
			dangerSource.mute = true;
			warningSource.mute = true;
		}
	}
}
