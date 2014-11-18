using UnityEngine;
using System.Collections;

public class UseIt : MonoBehaviour {
	public GameObject water;
	public float fireRate;
	private float nextFire;
	
	// Update is called once per frame
	void shoot () {
		if (Time.time > nextFire)
		{
				nextFire = Time.time + fireRate;
				Instantiate(water, this.transform.position, water.transform.rotation);
		}
	}
}
