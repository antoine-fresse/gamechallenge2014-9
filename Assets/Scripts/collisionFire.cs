using UnityEngine;
using System.Collections;

public class collisionFire : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.tag == "Eau") {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
		if(other.tag == "Player")
		{
			Destroy(other.gameObject);
		}
	}
}